
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geodatabase;

namespace ArcGISFoundation
{
    public sealed class MapZoomin : BaseCommand
    {
        private IMapControl3 m_mapControl;

        public MapZoomin()
        {
            base.m_caption = "·Å´ó";
        }

        public override void OnClick()
        {
            ILayer lyr = m_mapControl.CustomProperty as ILayer;

            m_mapControl.Extent = lyr.AreaOfInterest;
        }

        public override void OnCreate(object hook)
        {
            m_mapControl = (IMapControl3)hook;
        }
    }
}

