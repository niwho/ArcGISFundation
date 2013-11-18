
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Runtime.InteropServices;

using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.ADF;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Display;

namespace ArcGISFoundation
{
    public sealed partial class MainForm : Form
    {
        private bool m_isQuery ;

        private void nw_query()
        {
            ILayerEffectProperties pLayerEffectProperties = new CommandsEnvironmentClass();
           ILayer ly=  pLayerEffectProperties.FlickerLayer;
            ILayer layer1 = (ILayer)axMapControl1.CustomProperty; 
            //axMapControl1
            ILayer layer = axMapControl1.get_Layer(0);
            axMapControl1.MousePointer = ESRI.ArcGIS.Controls.esriControlsMousePointer.esriPointerCrosshair;
            
            ESRI.ArcGIS.Geometry.IGeometry geometry = null;
            geometry = axMapControl1.TrackRectangle();
            IFeatureLayer featureLayer = layer as IFeatureLayer;
            //获取featureLayer的featureClass 
            IFeatureClass featureClass = featureLayer.FeatureClass;
            ISpatialFilter pSpatialFilter = new SpatialFilterClass();
            IQueryFilter pQueryFilter = pSpatialFilter as ISpatialFilter;
            //设置过滤器的Geometry
            pSpatialFilter.Geometry = geometry;
            //设置空间关系类型
            pSpatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;//esriSpatialRelContains;
            //获取FeatureCursor游标
            IFeatureCursor pFeatureCursor = featureClass.Search(pQueryFilter, true);
            //遍历FeatureCursor
            IFeature pFeature = pFeatureCursor.NextFeature(); 
          
              ESRI.ArcGIS.Controls.ControlsLayerListToolControl dfsafdsfa =
                        (ESRI.ArcGIS.Controls.ControlsLayerListToolControl)(maintoolbar.GetItem(maintoolbar.Find("esriControls.ControlsLayerListToolControl"))).Command;
              string ss = dfsafdsfa.ToString();
            QueryForm qf =new QueryForm(m_bin_path);
            qf.m_mapControl = axMapControl1;
            qf.m_featureLayer = featureLayer;
            System.Windows.Forms.ListView listView_data = qf.nw_getListView();
            listView_data.Columns.Add("省名", 120,HorizontalAlignment.Left);//省名,,
            listView_data.Columns.Add("适宜度", 120, HorizontalAlignment.Left);
            listView_data.Columns.Add("面积", 120, HorizontalAlignment.Left);

            System.Collections.Generic.List<IFeature> pList = new System.Collections.Generic.List<IFeature>();
            while (pFeature != null)
            {

                // ESRI.ArcGIS.Geodatabase.IField filed = pFeature.Fields.FindField("rate_shiyi");
                ESRI.ArcGIS.Geodatabase.IRowBuffer buff = (IRowBuffer)pFeature;
                string str = buff.Value[pFeature.Fields.FindField("NAME")].ToString();
                ESRI.ArcGIS.Geodatabase.IRow row = pFeature.Table.GetRow(pFeature.OID);
                //string str = row.Value[].ToString();
                double a = System.Convert.ToDouble(row.get_Value(pFeature.Fields.FindField(nw_getQueryFiledName())));
                //pList.Add()
                //pList.Add(pFeature.);

                ListViewItem lvi = new ListViewItem();
               // ESRI.ArcGIS.Geodatabase.IRowBuffer buff = (IRowBuffer)pFeature;
                lvi.Text = buff.Value[pFeature.Fields.FindField("NAME")].ToString();
                lvi.SubItems.Add(buff.Value[pFeature.Fields.FindField("rate_shiyi")].ToString());//rate_shiyi
                lvi.SubItems.Add(buff.Value[pFeature.Fields.FindField("PERIMETER")].ToString());//
                listView_data.Items.Add(lvi);

                pFeature = pFeatureCursor.NextFeature();
            }
            axMapControl1.MousePointer = ESRI.ArcGIS.Controls.esriControlsMousePointer.esriPointerDefault;
            qf.Show();
            if (pFeature != null)
            {
                axMapControl1.Map.SelectFeature(axMapControl1.get_Layer(0), pFeature);
                axMapControl1.Refresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
            }
            /* axMapControl1.Map.SelectByShape(geometry, null, false);
             axMapControl1.Refresh(esriViewDrawPhase.esriViewGeoSelection, null, null);*/
        }
        private string nw_getQueryFiledName(int ty = 0)
        {
            //根据当前的查询，适宜，次适宜
            switch (ty)
            {
                case 0:
                    return "rate_shiyi";
                case 1:
                    return "rate_cishiyi";
                default:
                    return "rate_shiyi";
            }

        }


    }
}