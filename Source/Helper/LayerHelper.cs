using System;
using System.Collections.Generic;
using System.Text;

using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geodatabase;

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
    }
}
