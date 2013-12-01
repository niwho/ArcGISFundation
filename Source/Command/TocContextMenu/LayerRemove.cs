
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;

namespace ArcGISFoundation
{
	public sealed class LayerRemove : BaseCommand  
	{
		private IMapControl3 m_mapControl;

		public LayerRemove()
		{
			base.m_caption = "ÒÆ³ý";
		}
	
		public override void OnClick()
		{
			ILayer layer =  (ILayer) m_mapControl.CustomProperty;
			m_mapControl.Map.DeleteLayer(layer);
		}
	
		public override void OnCreate(object hook)
		{
			m_mapControl = (IMapControl3) hook;
		}
	}
}


