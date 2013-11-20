
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
        private string m_range;
        private string m_range_en;
        private string m_rate;
        private string m_rate_en;
        private string m_mucao ="";

        private void resolveNameRange(string layer_name)
        {
            if(layer_name.IndexOf("省")>-1)
            {
                m_range = "省";
                m_range_en = "NAME";
            }
            else if (layer_name.IndexOf("市")>-1)
            {
                m_range = "市";
                m_range_en = "CITY";
            }
            else if (layer_name.IndexOf("县") > -1)
            {
                m_range = "县";
                m_range_en = "COUNTY";
            }
            else
            {
                MessageBox.Show("图层名错误！");
            }
        }
        private void resolveNameRate(string layer_name)
        {
            if (layer_name.IndexOf("次适宜") > -1)//必须先判断这个
            {
                m_rate = "次适宜";
                m_rate_en = "_cishi";
            }
            else if (layer_name.IndexOf("适宜") > -1)
            {
                m_rate = "适宜";
                m_rate_en = "_shiyi";
            }
            else
            {
                MessageBox.Show("图层名错误！");
            }
            
        }
        private void nw_query()
        {
            //axMapControl1
            ILayer layer = axMapControl1.get_Layer(m_selectedLayer);
            resolveNameRate(layer.Name);
            resolveNameRange(layer.Name);
            
            //layer_name[1];
            //
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
          
            QueryForm qf =new QueryForm(m_bin_path);
            qf.m_mapControl = axMapControl1;
            qf.m_featureLayer = featureLayer;
            qf.m_query_name = m_range_en;
            qf.m_mucao = m_mucao;

            System.Windows.Forms.ListView listView_data = qf.nw_getListView();
            listView_data.Columns.Add(m_range+"名", 120,HorizontalAlignment.Left);//省名,,
            listView_data.Columns.Add(m_rate + "度", 120, HorizontalAlignment.Left);
            listView_data.Columns.Add(m_rate+"面积", 130, HorizontalAlignment.Left);
            string area = "area" + m_rate_en;
            string rate = "rate" + m_rate_en;
            if(pFeature != null)
            {
                for (int i = 0; i < pFeature.Fields.FieldCount;++i )
                {
                    if (pFeature.Fields.Field[i].Name.IndexOf("area_") > -1)
                    {
                        area = pFeature.Fields.Field[i].Name;
                    }
                    else if(pFeature.Fields.Field[i].Name.IndexOf("rate_")>-1)
                    {
                        rate =  pFeature.Fields.Field[i].Name;
                    }
                   
                }
            }
            System.Collections.Generic.List<IFeature> pList = new System.Collections.Generic.List<IFeature>();
            while (pFeature != null)
            {

                // ESRI.ArcGIS.Geodatabase.IField filed = pFeature.Fields.FindField("rate_shiyi");
                //ESRI.ArcGIS.Geodatabase.IRowBuffer buff = (IRowBuffer)pFeature;
                //string str = buff.Value[pFeature.Fields.FindField("NAME")].ToString();
                //ESRI.ArcGIS.Geodatabase.IRow row = pFeature.Table.GetRow(pFeature.OID);
                //string str = row.Value[].ToString();
                //double a = System.Convert.ToDouble(row.get_Value(pFeature.Fields.FindField(nw_getQueryFiledName())));
                //pList.Add()
                //pList.Add(pFeature.);
               
                ListViewItem lvi = new ListViewItem();
               // ESRI.ArcGIS.Geodatabase.IRowBuffer buff = (IRowBuffer)pFeature;
                lvi.Text = pFeature.Value[pFeature.Fields.FindField(m_range_en)].ToString();
                lvi.SubItems.Add(pFeature.Value[pFeature.Fields.FindField(rate)].ToString());//rate_shiyi
              
                
                lvi.SubItems.Add(System.Convert.ToDecimal(pFeature.Value[pFeature.Fields.FindField(area)]).ToString("N"));//
                listView_data.Items.Add(lvi);

                pFeature = pFeatureCursor.NextFeature();
            }
            axMapControl1.MousePointer = ESRI.ArcGIS.Controls.esriControlsMousePointer.esriPointerDefault;
            qf.Show();
           /*  if (pFeature != null)
            {
                axMapControl1.Map.SelectFeature(axMapControl1.get_Layer(0), pFeature);
                axMapControl1.Refresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
            }
            axMapControl1.Map.SelectByShape(geometry, null, false);
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