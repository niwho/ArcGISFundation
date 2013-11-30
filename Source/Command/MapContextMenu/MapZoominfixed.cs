
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geodatabase;

namespace ArcGISFoundation
{
    public sealed class MapZoominFixed : BaseCommand
    {
        private IMapControl3 m_mapControl;

        public MapZoominFixed()
        {
            base.m_caption = "¹Ì¶¨·Å´ó";
        }

        public override void OnClick()
        {
            ICommand cmd = new ControlsMapZoomInToolClass();
            cmd.OnCreate(m_mapControl);
            m_mapControl.CurrentTool = cmd as ITool;
        }

        public override void OnCreate(object hook)
        {
            m_mapControl = (IMapControl3)hook;
        }
    }
}

