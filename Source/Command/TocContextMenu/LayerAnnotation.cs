
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geodatabase;

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
				if (m_subType == 1) 
                    return "±ê×¢";
				else
                    return "²»±ê×¢";
			}
		}
	}
}

