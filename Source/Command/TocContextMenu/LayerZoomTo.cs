
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;

namespace ArcGISFoundation
{
	public sealed class LayerZoomTo : BaseCommand  
	{
		private IMapControl3 m_mapControl;

		public LayerZoomTo()
		{
			base.m_caption = "缩放至当前图层";
		}
	
		public override void OnClick()
		{
            ILayer lyr = m_mapControl.CustomProperty as ILayer;

            m_mapControl.Extent = lyr.AreaOfInterest;
		}
	
		public override void OnCreate(object hook)
		{
			m_mapControl = (IMapControl3) hook;
		}
	}
}

