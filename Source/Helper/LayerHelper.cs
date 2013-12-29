using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Collections;
using System.Text;

using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.DataSourcesRaster;

namespace ArcGISFoundation
{
    class LayerHelper
    {
        public static void SetLayerAnnotation(IGeoFeatureLayer geolyr, string field)
        {
            geolyr.AnnotationProperties.Clear();
            IBasicOverposterLayerProperties pBasic = new BasicOverposterLayerPropertiesClass();
            ILabelEngineLayerProperties pLableEngine = new LabelEngineLayerPropertiesClass();
            ITextSymbol textSymbol = new TextSymbolClass();

            string lable = "[" + field + "]";
            pLableEngine.Expression = lable;
            pLableEngine.IsExpressionSimple = true;
            pBasic.NumLabelsOption = esriBasicNumLabelsOption.esriOneLabelPerShape;
            pLableEngine.BasicOverposterLayerProperties = pBasic;
            pLableEngine.Symbol = textSymbol;
            geolyr.AnnotationProperties.Add(pLableEngine as IAnnotateLayerProperties);
        }

        public static void SetLayerColor(IGeoFeatureLayer geolyr, int r, int g, int b)
        {
            //ILineSymbol pLineSymbol = new SimpleLineSymbolClass();
            //pLineSymbol.Color = CvtRGB(r, g, b);

            ISimpleFillSymbol pFillSymbol = new SimpleFillSymbolClass();
            pFillSymbol.Color = CvtRGB(r, g, b);
            //pFillSymbol.Outline = pLineSymbol;

            ISimpleRenderer pSimpleRenderer;
            pSimpleRenderer = new SimpleRendererClass();
            pSimpleRenderer.Symbol = (ISymbol)pFillSymbol;
            geolyr.Renderer = pSimpleRenderer as IFeatureRenderer;
        }

        public static void SetLayerColor(IRasterLayer raslyr)
        { 
            IRasterRenderer rasterRenderer = null;
            
            rasterRenderer = UniqueValueRenderer(raslyr,"RATE");

            if (rasterRenderer != null)
                raslyr.Renderer = rasterRenderer;
        }

        public static IRasterRenderer ClassifyRenderer(IRasterLayer raslyr,IRgbColor start_clr,IRgbColor end_clr,int count)
        {
            IRasterClassifyColorRampRenderer pRClassRend = new RasterClassifyColorRampRendererClass();
            IRasterRenderer rasterRenderer = pRClassRend as IRasterRenderer;

            IRaster pRaster = raslyr.Raster;
            IRasterBandCollection pRBandCol = pRaster as IRasterBandCollection;
            IRasterBand pRBand = pRBandCol.Item(0);
            if (pRBand.Histogram == null)
            {
                pRBand.ComputeStatsAndHist();
            }
            rasterRenderer.Raster = pRaster;
            pRClassRend.ClassCount = count;
            rasterRenderer.Update();

            IAlgorithmicColorRamp colorRamp = new AlgorithmicColorRampClass();
            colorRamp.Size = count;
            colorRamp.FromColor = start_clr;
            colorRamp.ToColor = end_clr;
            bool createColorRamp;
            colorRamp.CreateRamp(out createColorRamp);

            IFillSymbol fillSymbol = new SimpleFillSymbolClass();
            for (int i = 0; i < pRClassRend.ClassCount; i++)
            {
                fillSymbol.Color = colorRamp.get_Color(i);
                pRClassRend.set_Symbol(i, fillSymbol as ISymbol);
                pRClassRend.set_Label(i, pRClassRend.get_Break(i).ToString("0.00"));
            }
            return rasterRenderer;
        }

        public static IRasterRenderer UniqueValueRenderer(IRasterLayer pRLayer, string strfield)
        {
            try
            {
                //Get the raster attribute table and the size of the table.
                IRaster2 raster = pRLayer.Raster as IRaster2;
                ITable rasterTable = (pRLayer as IAttributeTable) as ITable;
                if (rasterTable == null)
                {
                    return null;
                }
                int tableRows = rasterTable.RowCount(null);
                //Create colors for each unique value.
                ArrayList arr = new ArrayList();
                for (int i = 0; i < rasterTable.RowCount(null); i++)
                {
                    IRow row1 = rasterTable.GetRow(i);
                    string aa = row1.get_Value(row1.Fields.FindField(strfield)).ToString();
                    if (arr.Contains(aa))
                    {
                        ;
                    }
                    else
                    {
                        arr.Add(aa);
                    }
                }
               
                //Create a unique value renderer.
                IRasterUniqueValueRenderer uvRenderer = new RasterUniqueValueRendererClass();
                IRasterRenderer rasterRenderer = (IRasterRenderer)uvRenderer;
                rasterRenderer.Raster = raster as IRaster;
                rasterRenderer.Update();
                //Set the renderer properties.
                uvRenderer.HeadingCount = 1;
                //uvRenderer.set_Heading(0, "所有类别");
                uvRenderer.set_ClassCount(0, arr.Count);
                uvRenderer.Field = "VALUE"; //Or any other field in the table.
                IRow row;
                ISimpleFillSymbol fillSymbol;
                for (int i = 0; i < tableRows; i++)
                {
                    row = rasterTable.GetRow(i);
                    for (int nm = 0; nm < arr.Count; nm++)
                    {
                        string aa = arr[nm].ToString();
                        string bb = row.get_Value((row.Fields.FindField(strfield))).ToString();

                        if (aa == bb)
                        {
                            uvRenderer.AddValue(0, nm, row.get_Value(1));

                            uvRenderer.set_Label(0, nm, row.get_Value(row.Fields.FindField(strfield)).ToString());
                            fillSymbol = new SimpleFillSymbolClass();

                            if (aa == "不适宜区")
                                fillSymbol.Color = CvtRGB(255, 255, 255);
                            else if (aa == "次适宜区")
                                fillSymbol.Color = CvtRGB(76, 230, 0);             
                            else
                                fillSymbol.Color = CvtRGB(38, 115, 0);

                            uvRenderer.set_Symbol(0, nm, (ISymbol)fillSymbol);
                        }
                    }
                }

                return rasterRenderer;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return null;
            }

        }
 
        public static void ShowLayerAttribute(IRasterLayer raslyr)
        {
            IRaster pRaster = raslyr.Raster;
            IRasterBandCollection pRasterBC = pRaster as IRasterBandCollection;
            IRasterBand pRasterBand = pRasterBC.Item(0);
            ITable pTable = pRasterBand.AttributeTable;
            IQueryFilter pQueryFilter = new QueryFilterClass();

            pQueryFilter.WhereClause = "";

            ICursor pCursor = pTable.Search(pQueryFilter, false);
            IRow pRow = pCursor.NextRow();

            for (int i = 0; i < pTable.Fields.FieldCount; i++)
            {
                MessageBox.Show(pTable.Fields.get_Field(i).Name);
            }

            while (pRow != null)
            {
                MessageBox.Show(Convert.ToString(pRow.get_Value(pTable.Fields.FindField("COUNT"))));
                pRow = pCursor.NextRow();
            }
        }

        private static IRgbColor CvtRGB(int r, int g, int b)
        {
            IRgbColor pColor;
            pColor = new RgbColorClass();
            pColor.Red = r;
            pColor.Green = g;
            pColor.Blue = b;
            return pColor;
        }
    }
}
