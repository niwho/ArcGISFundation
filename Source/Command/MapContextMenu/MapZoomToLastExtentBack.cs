
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geodatabase;

namespace ArcGISFoundation
{
    public sealed class MapZoomToLastExtentBack : BaseCommand
    {
        private IMapControl3 m_mapControl;

        public MapZoomToLastExtentBack()
        {
            base.m_caption = "иор╩йсм╪";
        }

        public override void OnClick()
        {
            ICommand cmd = new ControlsMapZoomToLastExtentBackCommandClass();
            cmd.OnCreate(m_mapControl);
            cmd.OnClick();
        }

        public override void OnCreate(object hook)
        {
            m_mapControl = (IMapControl3)hook;
        }
    }
}

