using System.Windows.Forms;

using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;

namespace ArcGISFoundation
{
    public sealed class LayerColor : BaseCommand
    {
        private IMapControl3 m_mapControl;

        public LayerColor()
        {
            base.m_caption = "…Ë÷√—’…´";
        }

        public override void OnClick()
        {
            IRasterLayer     raslyr = m_mapControl.CustomProperty as IRasterLayer;
            IFeatureLayer    fealyr = m_mapControl.CustomProperty as IFeatureLayer;

            if (raslyr != null )
            {
                LayerHelper.SetLayerColor(raslyr);
                //LayerHelper.ShowLayerAttribute(raslyr);
                m_mapControl.Refresh(esriViewDrawPhase.esriViewGeography, null, null);
            }
            else
            {
                IGeoFeatureLayer geolyr = fealyr as IGeoFeatureLayer;

                ColorDialog clrDlg = new ColorDialog();
                //clrDlg.AllowFullOpen = false;
                //clrDlg.ShowHelp = true;

                if (clrDlg.ShowDialog() == DialogResult.OK)
                {
                    LayerHelper.SetLayerColor(geolyr, clrDlg.Color.R, clrDlg.Color.G, clrDlg.Color.B);

                    m_mapControl.Refresh(esriViewDrawPhase.esriViewGeography, null, null);
                }
            }
           
        }

        public override void OnCreate(object hook)
        {
            m_mapControl = (IMapControl3)hook;
        }
    }
}