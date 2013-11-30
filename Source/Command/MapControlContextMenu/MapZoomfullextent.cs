
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geodatabase;

namespace ArcGISFoundation
{
    public sealed class MapZoomfullextent : BaseCommand
    {
        private IMapControl3 m_mapControl;

        public MapZoomfullextent()
        {
            base.m_caption = "¸´Î»";
        }

        public override void OnClick()
        {
            ICommand cmd = new ControlsMapFullExtentCommandClass();
            cmd.OnCreate(m_mapControl);
            cmd.OnClick();
        }

        public override void OnCreate(object hook)
        {
            m_mapControl = (IMapControl3)hook;
        }
    }
}

