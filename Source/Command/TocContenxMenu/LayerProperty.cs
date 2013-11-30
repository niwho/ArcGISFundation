
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Framework;

namespace ArcGISFoundation
{
	public sealed class LayerAnnotation : BaseCommand, ICommandSubType
	{
		private IMapControl3 m_mapControl;
		private long m_subType;

		public LayerAnnotation()
		{
		}
	
		public override void OnClick()
		{
            IFeatureLayer    lyr = m_mapControl.CustomProperty as IFeatureLayer;
            IGeoFeatureLayer geolyr = lyr as IGeoFeatureLayer;

            if (geolyr == null)
                return;

            if (m_subType == 1)
            {
                string strField = @"NAME";
                ITable table = geolyr as ITable;
                IField field = null;
                for (int i = 0; i < table.Fields.FieldCount; i++)
                {
                    field = table.Fields.get_Field(i);
                    if (field.Name == @"NAME" ||
                        field.Name == @"CITY" ||
                        field.Name == @"COUNTY")
                    {
                        strField = field.Name;
                    }
                }

                SetLayerAnnotation(geolyr, strField);

                geolyr.DisplayAnnotation = true;
                m_mapControl.Refresh(esriViewDrawPhase.esriViewGeography, null, null);
            }
            else if (m_subType == 2)
            {
                geolyr.DisplayAnnotation = false;
                m_mapControl.Refresh(esriViewDrawPhase.esriViewGeography, null, null);
            }
		}
	
		public override void OnCreate(object hook)
		{
			m_mapControl = (IMapControl3) hook;
		}
		
		public override bool Enabled
		{
			get
			{
                IFeatureLayer lyr = m_mapControl.CustomProperty as IFeatureLayer;
                IGeoFeatureLayer geolyr = lyr as IGeoFeatureLayer;

                if (geolyr == null)
                    return false;

				if (m_subType == 1)
                    return !geolyr.DisplayAnnotation;
				else
                    return geolyr.DisplayAnnotation;
			}
		}
	
		public int GetCount()
		{
			return 2;
		}
	
		public void SetSubType(int SubType)
		{
			m_subType = SubType;
		}
	
		public override string Caption
		{
			get
			{
                 return "Í¼²ãÊôÐÔ";
			}
		}

        private bool SetupFeaturePropertySheet(ILayer layer)
        {
            if (layer == null) return false;
            .IComPropertySheet pComPropSheet;
            pComPropSheet = new ESRI.ArcGIS.Framework.ComPropertySheet();
            pComPropSheet.Title = layer.Name + " - ÊôÐÔ";

            ESRI.ArcGIS.esriSystem.UID pPPUID = new ESRI.ArcGIS.esriSystem.UIDClass();
            pComPropSheet.AddCategoryID(pPPUID);

            // General....
            ESRI.ArcGIS.Framework.IPropertyPage pGenPage = new ESRI.ArcGIS.CartoUI.GeneralLayerPropPageClass();
            pComPropSheet.AddPage(pGenPage);

            // Source
            ESRI.ArcGIS.Framework.IPropertyPage pSrcPage = new ESRI.ArcGIS.CartoUI.FeatureLayerSourcePropertyPageClass();
            pComPropSheet.AddPage(pSrcPage);

            // Selection...
            ESRI.ArcGIS.Framework.IPropertyPage pSelectPage = new ESRI.ArcGIS.CartoUI.FeatureLayerSelectionPropertyPageClass();
            pComPropSheet.AddPage(pSelectPage);

            // Display....
            ESRI.ArcGIS.Framework.IPropertyPage pDispPage = new ESRI.ArcGIS.CartoUI.FeatureLayerDisplayPropertyPageClass();
            pComPropSheet.AddPage(pDispPage);

            // Symbology....
            ESRI.ArcGIS.Framework.IPropertyPage pDrawPage = new ESRI.ArcGIS.CartoUI.LayerDrawingPropertyPageClass();
            pComPropSheet.AddPage(pDrawPage);

            // Fields... 
            ESRI.ArcGIS.Framework.IPropertyPage pFieldsPage = new ESRI.ArcGIS.CartoUI.LayerFieldsPropertyPageClass();
            pComPropSheet.AddPage(pFieldsPage);

            // Definition Query... 
            ESRI.ArcGIS.Framework.IPropertyPage pQueryPage = new ESRI.ArcGIS.CartoUI.LayerDefinitionQueryPropertyPageClass();
            pComPropSheet.AddPage(pQueryPage);

            // Labels....
            ESRI.ArcGIS.Framework.IPropertyPage pSelPage = new ESRI.ArcGIS.CartoUI.LayerLabelsPropertyPageClass();
            pComPropSheet.AddPage(pSelPage);

            // Joins & Relates....
            ESRI.ArcGIS.Framework.IPropertyPage pJoinPage = new ESRI.ArcGIS.ArcMapUI.JoinRelatePageClass();
            pComPropSheet.AddPage(pJoinPage);

            // Setup layer link
            ESRI.ArcGIS.esriSystem.ISet pMySet = new ESRI.ArcGIS.esriSystem.SetClass();
            pMySet.Add(layer);
            pMySet.Reset();

            // make the symbology tab active
            pComPropSheet.ActivePage = 4;

            // show the property sheet
            bool bOK = pComPropSheet.EditProperties(pMySet, 0);

            m_activeView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, m_activeView.Extent);
            return (bOK);
        }
	}
}

