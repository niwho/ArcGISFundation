
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geodatabase;

namespace ArcGISFoundation
{
    public sealed class MapZoomout : BaseCommand
    {
        private IMapControl3 m_mapControl;

        public MapZoomout()
        {
            base.m_caption = "��С";
        }

        public override void OnClick()
        {
            ICommand cmd = new ControlsMapZoomOutToolClass();
            cmd.OnCreate(m_mapControl);
            m_mapControl.CurrentTool = cmd as ITool;
        }

        public override void OnCreate(object hook)
        {
            m_mapControl = (IMapControl3)hook;
        }
    }
}

