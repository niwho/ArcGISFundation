
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.CartoUI;
using ESRI.ArcGIS.ArcMapUI;

namespace ArcGISFoundation
{
    public sealed class LayerProperty : BaseCommand
    {
        private IMapControl3 m_mapControl;

        public LayerProperty()
        {
            base.m_caption = "Õº≤„ Ù–‘";
        }

        public override void OnClick()
        {
            ILayer lyr = m_mapControl.CustomProperty as ILayer;

            if (lyr == null)
                return;

            SetLayerPropertySheet(lyr);

            m_mapControl.Refresh(esriViewDrawPhase.esriViewGeography, null, null);

        }

        public override void OnCreate(object hook)
        {
            m_mapControl = (IMapControl3)hook;
        }

        private bool SetLayerPropertySheet(ILayer layer)
        {
            if (layer == null) 
                return false;

            IComPropertySheet pComPropSheet;
            pComPropSheet = new ESRI.ArcGIS.Framework.ComPropertySheet();
            pComPropSheet.Title = layer.Name + " -  Ù–‘";

            ESRI.ArcGIS.esriSystem.UID pPPUID = new UIDClass();
            pComPropSheet.AddCategoryID(pPPUID);

            // General....
            ESRI.ArcGIS.Framework.IPropertyPage pGenPage = new GeneralLayerPropPageClass();
            pComPropSheet.AddPage(pGenPage);

            // Source
            ESRI.ArcGIS.Framework.IPropertyPage pSrcPage = new FeatureLayerSourcePropertyPageClass();
            pComPropSheet.AddPage(pSrcPage);

            // Selection...
            IPropertyPage pSelectPage = new FeatureLayerSelectionPropertyPageClass();
            pComPropSheet.AddPage(pSelectPage);

            // Display....
            IPropertyPage pDispPage = new FeatureLayerDisplayPropertyPageClass();
            pComPropSheet.AddPage(pDispPage);

            // Symbology....
            ESRI.ArcGIS.Framework.IPropertyPage pDrawPage = new LayerDrawingPropertyPageClass();
            pComPropSheet.AddPage(pDrawPage);

            // Fields... 
            ESRI.ArcGIS.Framework.IPropertyPage pFieldsPage = new LayerFieldsPropertyPageClass();
            pComPropSheet.AddPage(pFieldsPage);

            // Definition Query... 
            ESRI.ArcGIS.Framework.IPropertyPage pQueryPage = new LayerDefinitionQueryPropertyPageClass();
            pComPropSheet.AddPage(pQueryPage);

            // Labels....
            ESRI.ArcGIS.Framework.IPropertyPage pSelPage = new LayerLabelsPropertyPageClass();
            pComPropSheet.AddPage(pSelPage);

            // Joins & Relates....
            ESRI.ArcGIS.Framework.IPropertyPage pJoinPage = new JoinRelatePageClass();
            pComPropSheet.AddPage(pJoinPage);

            // Setup layer link
            ESRI.ArcGIS.esriSystem.ISet pMySet = new SetClass();
            pMySet.Add(layer);
            pMySet.Reset();

            // make the symbology tab active
            pComPropSheet.ActivePage = 4;

            // show the property sheet
            bool bOK = pComPropSheet.EditProperties(pMySet, 0);

           return bOK;
        }
    }
}

