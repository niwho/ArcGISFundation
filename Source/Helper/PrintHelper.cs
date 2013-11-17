using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;

using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.ADF;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Output;
using ESRI.ArcGIS.Geometry;

namespace ArcGISFoundation
{
    class PrintHelper
    {
        [DllImport("GDI32.dll")]
        public static extern int GetDeviceCaps(int hdc, int nIndex);

        [DllImport("User32.dll")]
        public static extern int GetDC(int hWnd);
        [DllImport("User32.dll")]
        public static extern int ReleaseDC(int hWnd, int hDC);
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool SystemParametersInfo(uint uiAction, uint uiParam, ref int pvParam, uint fWinIni);

        const uint SPI_GETFONTSMOOTHING = 74;
        const uint SPI_SETFONTSMOOTHING = 75;
        const uint SPIF_UPDATEINIFILE = 0x1;

        /// <summary>
        /// 将Map上指定范围（该范围为规则区域）内的内容输出到Image,注意，当图片的行数或列数超过10000左右时，出现原因示知的失败
        /// </summary>
        /// <param name="pMap">需转出的MAP</param>
        /// <param name="outRect">输出的图片大小</param>
        /// <param name="pEnvelope">指定的输出范围（为Envelope类型）</param>
        /// <returns>输出的Image 具体需要保存为什么格式，可通过Image对象来实现</returns>
        public static Image SaveCurrentToImage(IMap pMap, Size outRect, IEnvelope pEnvelope)
        {
            //赋值
            tagRECT rect = new tagRECT();
            rect.left = rect.top = 0;
            rect.right = outRect.Width;
            rect.bottom = outRect.Height;
            try
            {
                //转换成activeView，若为ILayout，则将Layout转换为IActiveView
                IActiveView pActiveView = (IActiveView)pMap;
                // 创建图像,为24位色
                Image image = new Bitmap(outRect.Width, outRect.Height); //, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(image);

                // 填充背景色(白色)
                g.FillRectangle(Brushes.White, 0, 0, outRect.Width, outRect.Height);

                int dpi = (int)(outRect.Width / pEnvelope.Width);

                pActiveView.Output(g.GetHdc().ToInt32(), dpi, ref rect, pEnvelope, null);

                g.ReleaseHdc();

                return image;
            }

            catch (Exception e)
            {
                return null;
            }
        }

        //输出当前地图至指定的文件    
        public static void ExportActiveView(IActiveView pView, Size outRect, string outPath)
        {
            try
            {
                //参数检查
                if (pView == null)
                {
                    throw new Exception("输入参数错误,无法生成图片文件!");
                }

                //根据给定的文件扩展名，来决定生成不同类型的对象
                ESRI.ArcGIS.Output.IExport export = null;
                if (outPath.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase))
                {
                    export = new ESRI.ArcGIS.Output.ExportJPEGClass();
                }
                else if (outPath.EndsWith(".tiff", StringComparison.OrdinalIgnoreCase))
                {
                    export = new ESRI.ArcGIS.Output.ExportTIFFClass();
                }
                else if (outPath.EndsWith(".bmp", StringComparison.OrdinalIgnoreCase))
                {
                    export = new ESRI.ArcGIS.Output.ExportBMPClass();
                }
                else if (outPath.EndsWith(".emf", StringComparison.OrdinalIgnoreCase))
                {
                    export = new ESRI.ArcGIS.Output.ExportEMFClass();
                }
                else if (outPath.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
                {
                    export = new ESRI.ArcGIS.Output.ExportPNGClass();
                }
                else if (outPath.EndsWith(".gif", StringComparison.OrdinalIgnoreCase))
                {
                    export = new ESRI.ArcGIS.Output.ExportGIFClass();
                }

                SetOutputQuality(pView, 1);

                export.ExportFileName = outPath;
                IEnvelope pEnvelope = pView.Extent;
                //导出参数           
                export.Resolution = 300;

                tagRECT exportRect = new tagRECT();
                exportRect.left = exportRect.top = 0;
                exportRect.right = outRect.Width;
                exportRect.bottom = (int)(exportRect.right * pEnvelope.Height / pEnvelope.Width);
                ESRI.ArcGIS.Geometry.IEnvelope envelope = new ESRI.ArcGIS.Geometry.EnvelopeClass();
                //输出范围
                envelope.PutCoords(exportRect.left, exportRect.top, exportRect.right, exportRect.bottom);
                export.PixelBounds = envelope;
                //可用于取消操作
                ITrackCancel pCancel = new CancelTrackerClass();
                export.TrackCancel = pCancel;
                pCancel.Reset();
                //点击ESC键时，中止转出
                pCancel.CancelOnKeyPress = true;
                pCancel.CancelOnClick = false;
                pCancel.ProcessMessages = true;
                //获取handle
                System.Int32 hDC = export.StartExporting();
                //开始转出
                pView.Output(hDC, (System.Int32)export.Resolution, ref exportRect, pEnvelope, pCancel);
                bool bContinue = pCancel.Continue();
                //捕获是否继续
                if (bContinue)
                {
                    export.FinishExporting();
                    export.Cleanup();
                }
                else
                {
                    export.Cleanup();
                }

                bContinue = pCancel.Continue();
            }
            catch (Exception e)
            {
                //错误信息提示
            }
        }

        public static void ExportActiveView(IActiveView pView, long iOutputResolution, long lResampleRatio, 
                    string sExportType, string sOutputDir, string sOutputName,
                    Boolean bClipToGraphicsExtent = true, IEnvelope pEnvelope = null)
        {
            //解决文件名错误
            IActiveView docActiveView = pView;
            IExport docExport;
            long iPrevOutputImageQuality;
            IOutputRasterSettings docOutputRasterSettings;
            IEnvelope PixelBoundsEnv;
            tagRECT exportRECT;
            tagRECT DisplayBounds;
            IDisplayTransformation docDisplayTransformation;
            IPageLayout docPageLayout;
            IEnvelope docMapExtEnv;

            if (pEnvelope == null)
                pEnvelope = GetGraphicsExtent(pView);

            long hdc;
            long tmpDC;
            //string sNameRoot;
            long iScreenResolution;
            bool bReenable = false;

            IEnvelope docGraphicsExtentEnv;
            IUnitConverter pUnitConvertor;
            if (GetFontSmoothing())
            {
                bReenable = true;
                DisableFontSmoothing();
                if (GetFontSmoothing())
                {
                    //font smoothing is NOT successfully disabled, error out.
                    return;
                }
                //else font smoothing was successfully disabled.
            }

            // The Export*Class() type initializes a new export class of the desired type.
            if (String.Compare(sExportType,"PDF",true) == 0)
            {
                docExport = new ExportPDFClass();
            }
            else if (String.Compare(sExportType,"EPS",true) == 0)
            {
                docExport = new ExportPSClass();
            }
            else if (String.Compare(sExportType,"AI",true) == 0)
            {
                docExport = new ExportAIClass();
            }
            else if (String.Compare(sExportType,"BMP",true) == 0)
            {
                docExport = new ExportBMPClass();
            }
            else if (String.Compare(sExportType,"TIFF",true) == 0)
            {
                docExport = new ExportTIFFClass();
            }
            else if (String.Compare(sExportType,"SVG",true) == 0)
            {
                docExport = new ExportSVGClass();
            }
            else if (String.Compare(sExportType,"PNG",true) == 0)
            {
                docExport = new ExportPNGClass();
            }
            else if (String.Compare(sExportType,"GIF",true) == 0)
            {
                docExport = new ExportGIFClass();
            }
            else if (String.Compare(sExportType,"EMF",true) == 0)
            {
                docExport = new ExportEMFClass();
            }
            else if (String.Compare(sExportType,"JPEG",true) == 0 ||
                     String.Compare(sExportType,"JPG",true) == 0)
            {
                docExport = new ExportJPEGClass();
            }
            else
            {
                MessageBox.Show("！！不支持的格式 " + sExportType + ", 默认导出 EMF.");
                sExportType = "EMF";
                docExport = new ExportEMFClass();
            }

            //  save the previous output image quality, so that when the export is complete it will be set back.
            docOutputRasterSettings = docActiveView.ScreenDisplay.DisplayTransformation as IOutputRasterSettings;
            iPrevOutputImageQuality = docOutputRasterSettings.ResampleRatio;

            if (docExport is IExportImage)
            {
                // always set the output quality of the DISPLAY to 1 for image export formats
                SetOutputQuality(docActiveView, 1);
            }
            else
            {
                // for vector formats, assign the desired ResampleRatio to control drawing of raster layers at export time  
                SetOutputQuality(docActiveView, lResampleRatio);
            }
            //set the name root for the export
            // sNameRoot = "ExportActiveViewSampleOutput";
            //set the export filename (which is the nameroot + the appropriate file extension)
            docExport.ExportFileName = sOutputDir + "\\" + sOutputName + "." + docExport.Filter.Split('.')[1].Split('|')[0].Split(')')[0];

            tmpDC = GetDC(0);

            iScreenResolution = GetDeviceCaps((int)tmpDC, 88); //88 is the win32 const for Logical pixels/inch in X)

            ReleaseDC(0, (int)tmpDC);
            docExport.Resolution = iOutputResolution;

            if (docActiveView is IPageLayout)
            {
                //get the bounds of the "exportframe" of the active view.
                DisplayBounds = docActiveView.ExportFrame;
                //set up pGraphicsExtent, used if clipping to graphics extent.
                docGraphicsExtentEnv = pEnvelope;
            }
            else
            {
                //Get the bounds of the deviceframe for the screen.
                docDisplayTransformation = docActiveView.ScreenDisplay.DisplayTransformation;
                DisplayBounds = docDisplayTransformation.get_DeviceFrame();
            }
            PixelBoundsEnv = new Envelope() as IEnvelope;
            if (bClipToGraphicsExtent && (docActiveView is IPageLayout))
            {
                docGraphicsExtentEnv = pEnvelope;
                docPageLayout = docActiveView as PageLayout;
                pUnitConvertor = new UnitConverter();
                //assign the x and y values representing the clipped area to the PixelBounds envelope
                PixelBoundsEnv.XMin = 0;
                PixelBoundsEnv.YMin = 0;
                PixelBoundsEnv.XMax = pUnitConvertor.ConvertUnits(docGraphicsExtentEnv.XMax, docPageLayout.Page.Units, esriUnits.esriInches) * docExport.Resolution - pUnitConvertor.ConvertUnits(docGraphicsExtentEnv.XMin, docPageLayout.Page.Units, esriUnits.esriInches) * docExport.Resolution;
                PixelBoundsEnv.YMax = pUnitConvertor.ConvertUnits(docGraphicsExtentEnv.YMax, docPageLayout.Page.Units, esriUnits.esriInches) * docExport.Resolution - pUnitConvertor.ConvertUnits(docGraphicsExtentEnv.YMin, docPageLayout.Page.Units, esriUnits.esriInches) * docExport.Resolution;
                //'assign the x and y values representing the clipped export extent to the exportRECT
                exportRECT.bottom = (int)(PixelBoundsEnv.YMax) + 1;
                exportRECT.left = (int)(PixelBoundsEnv.XMin);
                exportRECT.top = (int)(PixelBoundsEnv.YMin);
                exportRECT.right = (int)(PixelBoundsEnv.XMax) + 1;
                //since we're clipping to graphics extent, set the visible bounds.
                docMapExtEnv = docGraphicsExtentEnv;
            }
            else
            {
                double tempratio = iOutputResolution / iScreenResolution;
                double tempbottom = DisplayBounds.bottom * tempratio;
                double tempright = DisplayBounds.right * tempratio;
                //'The values in the exportRECT tagRECT correspond to the width
                //and height to export, measured in pixels with an origin in the top left corner.
                exportRECT.bottom = (int)Math.Truncate(tempbottom);
                exportRECT.left = 0;
                exportRECT.top = 0;
                exportRECT.right = (int)Math.Truncate(tempright);

                //populate the PixelBounds envelope with the values from exportRECT.
                // We need to do this because the exporter object requires an envelope object
                // instead of a tagRECT structure.
                PixelBoundsEnv.PutCoords(exportRECT.left, exportRECT.top, exportRECT.right, exportRECT.bottom);
                //since it's a page layout or an unclipped page layout we don't need docMapExtEnv.
                docMapExtEnv = null;
            }
            // Assign the envelope object to the exporter object's PixelBounds property.  The exporter object
            // will use these dimensions when allocating memory for the export file.
            docExport.PixelBounds = PixelBoundsEnv;
            // call the StartExporting method to tell docExport you're ready to start outputting.
            hdc = docExport.StartExporting();
            // Redraw the active view, rendering it to the exporter object device context instead of the app display.
            // We pass the following values:
            //  * hDC is the device context of the exporter object.
            //  * exportRECT is the tagRECT structure that describes the dimensions of the view that will be rendered.
            // The values in exportRECT should match those held in the exporter object's PixelBounds property.
            //  * docMapExtEnv is an envelope defining the section of the original image to draw into the export object.
            docActiveView.Output((int)hdc, (int)docExport.Resolution, ref exportRECT, docMapExtEnv, null);
            //finishexporting, then cleanup.
            docExport.FinishExporting();
            docExport.Cleanup();
            MessageBox.Show("成功导出地图： " + docExport.ExportFileName, "提示");
            //set the output quality back to the previous value
            SetOutputQuality(docActiveView, iPrevOutputImageQuality);

            if (bReenable)
            {
                EnableFontSmoothing();
                bReenable = false;
                if (!GetFontSmoothing())
                {
                    //error: cannot reenable font smoothing.
                    MessageBox.Show("Unable to reenable Font Smoothing", "Font Smoothing error");
                }
            }

            docMapExtEnv = null;
            PixelBoundsEnv = null;
        }

        public static void SetOutputQuality(IActiveView docActiveView, long iResampleRatio)
        {
            IGraphicsContainer oiqGraphicsContainer;
            IElement oiqElement;
            IOutputRasterSettings docOutputRasterSettings;
            IMapFrame docMapFrame;
            IActiveView TmpActiveView;
            if (docActiveView is IMap)
            {
                docOutputRasterSettings = docActiveView.ScreenDisplay.DisplayTransformation as IOutputRasterSettings;
                docOutputRasterSettings.ResampleRatio = (int)iResampleRatio;
            }
            else if (docActiveView is IPageLayout)
            {
                //assign ResampleRatio for PageLayout
                docOutputRasterSettings = docActiveView.ScreenDisplay.DisplayTransformation as IOutputRasterSettings;
                docOutputRasterSettings.ResampleRatio = (int)iResampleRatio;
                //and assign ResampleRatio to the Maps in the PageLayout
                oiqGraphicsContainer = docActiveView as IGraphicsContainer;
                oiqGraphicsContainer.Reset();
                oiqElement = oiqGraphicsContainer.Next();
                while (oiqElement != null)
                {
                    if (oiqElement is IMapFrame)
                    {
                        docMapFrame = oiqElement as IMapFrame;
                        TmpActiveView = docMapFrame.Map as IActiveView;
                        docOutputRasterSettings = TmpActiveView.ScreenDisplay.DisplayTransformation as IOutputRasterSettings;
                        docOutputRasterSettings.ResampleRatio = (int)iResampleRatio;
                    }
                    oiqElement = oiqGraphicsContainer.Next();
                }
                docMapFrame = null;
                oiqGraphicsContainer = null;
                TmpActiveView = null;
            }
            docOutputRasterSettings = null;
        }
        public static IEnvelope GetGraphicsExtent(IActiveView docActiveView)
        {
            IEnvelope GraphicsBounds;
            IEnvelope GraphicsEnvelope;
            IGraphicsContainer oiqGraphicsContainer;
            IPageLayout docPageLayout;
            IDisplay GraphicsDisplay;
            IElement oiqElement;
            GraphicsBounds = new EnvelopeClass();
            GraphicsEnvelope = new EnvelopeClass();
            docPageLayout = docActiveView as IPageLayout;
            GraphicsDisplay = docActiveView.ScreenDisplay;
            oiqGraphicsContainer = docActiveView as IGraphicsContainer;
            oiqGraphicsContainer.Reset();
            oiqElement = oiqGraphicsContainer.Next();
            while (oiqElement != null)
            {
                oiqElement.QueryBounds(GraphicsDisplay, GraphicsEnvelope);
                GraphicsBounds.Union(GraphicsEnvelope);
                oiqElement = oiqGraphicsContainer.Next();
            }
            return GraphicsBounds;
        }

        private static void DisableFontSmoothing()
        {
            bool iResult;
            int pv = 0;

            iResult = SystemParametersInfo(SPI_SETFONTSMOOTHING, 0, ref pv, SPIF_UPDATEINIFILE);
        }

        private static void EnableFontSmoothing()
        {
            bool iResult;
            int pv = 0;

            iResult = SystemParametersInfo(SPI_SETFONTSMOOTHING, 1, ref pv, SPIF_UPDATEINIFILE);
        }

        private static Boolean GetFontSmoothing()
        {
            bool iResult;
            int pv = 0;

            iResult = SystemParametersInfo(SPI_GETFONTSMOOTHING, 0, ref pv, 0);
            if (pv > 0)
            {
                //pv > 0 means font smoothing is ON.
                return true;
            }
            else
            {
                //pv == 0 means font smoothing is OFF.
                return false;
            }
        }
    }
}
