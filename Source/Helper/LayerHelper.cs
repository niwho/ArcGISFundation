using System;
using System.Windows.Forms;
using System.Collections.Generic;
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
            IRasterClassifyColorRampRenderer pRClassRend = new RasterClassifyColorRampRendererClass();
            IRasterRenderer pRRend = pRClassRend as IRasterRenderer;

            IRaster pRaster = raslyr.Raster;
            IRasterBandCollection pRBandCol = pRaster as IRasterBandCollection;
            IRasterBand pRBand = pRBandCol.Item(0);
            if (pRBand.Histogram == null)
            {
                pRBand.ComputeStatsAndHist();
            }
            pRRend.Raster = pRaster;
            pRClassRend.ClassCount = 10;
            pRRend.Update();

            IRgbColor pFromColor = new RgbColorClass();
            pFromColor.Red = 255;
            pFromColor.Green = 0;
            pFromColor.Blue = 0;
            IRgbColor pToColor = new RgbColorClass();
            pToColor.Red = 0;
            pToColor.Green = 255;
            pToColor.Blue = 255;

            IAlgorithmicColorRamp colorRamp = new AlgorithmicColorRampClass();
            colorRamp.Size = 10;
            colorRamp.FromColor = pFromColor;
            colorRamp.ToColor = pToColor;
            bool createColorRamp;
            colorRamp.CreateRamp(out createColorRamp);

            IFillSymbol fillSymbol = new SimpleFillSymbolClass();
            for (int i = 0; i < pRClassRend.ClassCount; i++)
            {
                fillSymbol.Color = colorRamp.get_Color(i);
                pRClassRend.set_Symbol(i, fillSymbol as ISymbol);
                pRClassRend.set_Label(i, pRClassRend.get_Break(i).ToString("0.00"));
            }
            raslyr.Renderer = pRRend;
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
