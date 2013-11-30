
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geodatabase;

namespace ArcGISFoundation
{
    public sealed class MapZoompan : BaseCommand
    {
        private IMapControl3 m_mapControl;

        public MapZoompan()
        {
            base.m_caption = "ÒÆ¶¯";
        }

        public override void OnClick()
        {
            ICommand cmd = new ControlsMapPanToolClass();
            cmd.OnCreate(m_mapControl);
            m_mapControl.CurrentTool = cmd as ITool;
        }

        public override void OnCreate(object hook)
        {
            m_mapControl = (IMapControl3)hook;
        }
    }
}

