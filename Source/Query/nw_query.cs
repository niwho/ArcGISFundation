
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
using ESRI.ArcGIS.Geometry;
namespace ArcGISFoundation
{
    public sealed partial class MainForm : Form
    {
        private bool m_isQuery = false;
        private string m_range;
        private string m_range_en;
        private string m_rate;
        private string m_rate_en;
        private string m_mucao ="";

        private string m_nactcn = "";
        QueryForm m_qf ;

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
        private void getLayer(int tp,ref ILayer layer_shiyi, ref ILayer layer_cishi)
        {
            int n = 0;
            ESRI.ArcGIS.Carto.IMap map = m_datasource.GetActivePastureMap();
            switch (tp)
            {
            case 0://省
                    m_range = "省";
                m_range_en = "NAME";
                    for (int i = 0; i < map.LayerCount; ++i)
                    {
                        if (n > 1) break;
                        if (map.get_Layer(i).Name.IndexOf("省") > -1)
                        {
                            if (map.get_Layer(i).Name.IndexOf("次适宜") > -1)//必须先判断这个
                            {
                                layer_cishi = map.get_Layer(i);
                                ++n;
                            }
                            else if (map.get_Layer(i).Name.IndexOf("适宜") > -1)
                            {
                                layer_shiyi = map.get_Layer(i);
                                ++n;
                            }
                        }
                    }
            	break;
            case 1://市
                     m_range = "市";
                m_range_en = "CITY";
                for (int i = 0; i < map.LayerCount; ++i)
                {
                    if (n > 1) break;
                    if (map.get_Layer(i).Name.IndexOf("市") > -1)
                    {
                        if (map.get_Layer(i).Name.IndexOf("次适宜") > -1)//必须先判断这个
                        {
                            layer_cishi = map.get_Layer(i);
                            ++n;
                        }
                        else if (map.get_Layer(i).Name.IndexOf("适宜") > -1)
                        {
                            layer_shiyi = map.get_Layer(i);
                            ++n;
                        }
                    }
                }
                break;
            case 2://县
                    m_range = "县";
                m_range_en = "COUNTY";
                for (int i = 0; i < map.LayerCount; ++i)
                {
                    if (n > 1) break;
                    if (map.get_Layer(i).Name.IndexOf("县") > -1)
                    {
                        if (map.get_Layer(i).Name.IndexOf("次适宜") > -1)//必须先判断这个
                        {
                            layer_cishi = map.get_Layer(i);
                            ++n;
                        }
                        else if (map.get_Layer(i).Name.IndexOf("适宜") > -1)
                        {
                            layer_shiyi = map.get_Layer(i);
                            ++n;
                        }
                    }
                }
                break;
            default:
                break;
            }
        }

        private void nw_query(IMapControlEvents2_OnMouseDownEvent e)
        {
           
            //axMapControl1
            ILayer layer = m_datasource.GetAdministrativeMap().get_Layer(m_query_area_detail);
            ILayer layer_shiyi =null;// = axMapControl1.Map.get_Layer (m_selectedLayer);
            ILayer layer_cishi = null;//= axMapControl1.Map.get_Layer(m_selectedLayer);
            getLayer(m_query_area_detail, ref layer_shiyi, ref layer_cishi);
            //resolveNameRate(layer.Name);
            //resolveNameRange(layer.Name);
            
            //layer_name[1];
            //
            axMapControl1.MousePointer = ESRI.ArcGIS.Controls.esriControlsMousePointer.esriPointerCrosshair;
            
            ESRI.ArcGIS.Geometry.IGeometry geometry = null;
            ESRI.ArcGIS.Geometry.Point pt = new ESRI.ArcGIS.Geometry.Point();
            pt.X = e.mapX;
            pt.Y = e.mapY;
            geometry = pt as ESRI.ArcGIS.Geometry.IGeometry;
           // geometry = axMapControl1.TrackRectangle();
          
            ISpatialFilter pSpatialFilter = new SpatialFilterClass();
            IQueryFilter pQueryFilter = pSpatialFilter as ISpatialFilter;
            //设置过滤器的Geometry
            pSpatialFilter.Geometry = geometry;
            //设置空间关系类型
            pSpatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;//esriSpatialRelContains;
            
            //获取FeatureCursor游标
            IFeatureLayer featureLayer = layer as IFeatureLayer;
            //获取featureLayer的featureClass 
            IFeatureClass featureClass = featureLayer.FeatureClass;
            IFeatureCursor pFeatureCursor = featureClass.Search(pQueryFilter, true);
            //遍历FeatureCursor
            IFeature pFeature = pFeatureCursor.NextFeature();

            //获取FeatureCursor游标
            IFeatureLayer featureLayer1 = layer_shiyi as IFeatureLayer;
            //获取featureLayer的featureClass 
            IFeatureClass featureClass1 = featureLayer1.FeatureClass;
            IFeatureCursor pFeatureCursor1 = featureClass1.Search(pQueryFilter, true);
            //遍历FeatureCursor
            IFeature pFeature1 = pFeatureCursor1.NextFeature();

            //获取FeatureCursor游标
            IFeatureLayer featureLayer2 = layer_cishi as IFeatureLayer;
            //获取featureLayer的featureClass 
            IFeatureClass featureClass2 = featureLayer2.FeatureClass;
            IFeatureCursor pFeatureCursor2 = featureClass2.Search(pQueryFilter, true);
            //遍历FeatureCursor
            IFeature pFeature2 = pFeatureCursor2.NextFeature(); 
          
            //QueryForm qf =new QueryForm(m_bin_path);
            m_qf.m_mapControl = axMapControl1;
            m_qf.m_featureLayer = featureLayer;
            m_qf.m_query_name = m_range_en;
            m_qf.m_mucao = m_mucao;
            
            //qf.m_layername = "当前图层：" + layer.Name;

            System.Windows.Forms.ListView listView_data = m_qf.nw_getListView();
            listView_data.Items.Clear();
            m_qf.m_range = m_range;

            listView_data.Columns.Clear();
            listView_data.Columns.Add(m_range + "名", 120, HorizontalAlignment.Left);//省名,,
            listView_data.Columns.Add("适宜面积比", 120, HorizontalAlignment.Left);
            listView_data.Columns.Add("适宜面积", 120, HorizontalAlignment.Left);
            listView_data.Columns.Add("次适宜面积比", 120, HorizontalAlignment.Left);
            listView_data.Columns.Add("次适宜面积", 120, HorizontalAlignment.Left);

            string area1 = "area" + m_rate_en;
            string rate1 = "rate" + m_rate_en;
            string area2 = "area" + m_rate_en;
            string rate2 = "rate" + m_rate_en;
            if(pFeature1 != null)
            {
                for (int i = 0; i < pFeature1.Fields.FieldCount;++i )
                {
                    if (pFeature1.Fields.Field[i].Name.IndexOf("area_") > -1)
                    {
                        area1 = pFeature1.Fields.Field[i].Name;
                    }
                    else if(pFeature1.Fields.Field[i].Name.IndexOf("rate_")>-1)
                    {
                        rate1 =  pFeature1.Fields.Field[i].Name;
                    }
                   
                }
            }
            if (pFeature2 != null)
            {
                for (int i = 0; i < pFeature2.Fields.FieldCount; ++i)
                {
                    if (pFeature2.Fields.Field[i].Name.IndexOf("area_") > -1)
                    {
                        area2 = pFeature2.Fields.Field[i].Name;
                    }
                    else if (pFeature2.Fields.Field[i].Name.IndexOf("rate_") > -1)
                    {
                        rate2 = pFeature2.Fields.Field[i].Name;
                    }

                }
            }
            System.Collections.Generic.List<IFeature> pList = new System.Collections.Generic.List<IFeature>();

           
            while(pFeature != null)
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
               m_nactcn= lvi.Text = pFeature.Value[pFeature.Fields.FindField(m_range_en)].ToString();
                if (pFeature1!= null)
                {
                    lvi.SubItems.Add(pFeature1.Value[pFeature1.Fields.FindField(rate1)].ToString());//rate_shiyi
                    lvi.SubItems.Add(System.Convert.ToDecimal(pFeature1.Value[pFeature1.Fields.FindField(area1)]).ToString("N"));//
                }

                if (pFeature2 != null)
                {
                    lvi.SubItems.Add(pFeature2.Value[pFeature2.Fields.FindField(rate2)].ToString());//rate_shiyi
                    lvi.SubItems.Add(System.Convert.ToDecimal(pFeature2.Value[pFeature2.Fields.FindField(area2)]).ToString("N"));//
                }
                bool isNotAllNull = false;
                for (int i=1;i<lvi.SubItems.Count;++i)
                {
                    if(lvi.SubItems[i].Text.Trim() != "")
                    {
                        //MessageBox.Show(lvi.SubItems[i].Text.Trim());
                        isNotAllNull = true;
                        break;
                    }
                }
                
                if(isNotAllNull)
                    listView_data.Items.Add(lvi);

               pFeature = pFeatureCursor.NextFeature();
                if(pFeature1 != null)
                pFeature1 = pFeatureCursor1.NextFeature();
                if (pFeature2 != null)
                pFeature2 = pFeatureCursor2.NextFeature(); 

            }
            if (listView_data.Items.Count == 0)
            {
                MessageBox.Show("暂无数据！");
                return; 
            }
            axMapControl1.MousePointer = ESRI.ArcGIS.Controls.esriControlsMousePointer.esriPointerDefault;
            m_qf.Show();
            highLight(featureLayer);
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
        private void highLight(IFeatureLayer featurelayer)
        {

            if(m_nactcn == "")
                return;
            IFeatureClass featureClass = featurelayer.FeatureClass;
            IFeatureSelection sel = featurelayer as IFeatureSelection;

                IFeature feature = null;

                axMapControl1.Refresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
                axMapControl1.Map.ClearSelection();
                axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);

                IQueryFilter queryFilter = new QueryFilterClass();
                IFeatureCursor featureCusor;
                queryFilter.WhereClause = m_range_en + " = '" + m_nactcn + "'";

                featureCusor = featureClass.Search(queryFilter, true);
                //search的参数第一个为过滤条件，第二个为是否重复执行。
                //feature = featureCusor.NextFeature();
                IFeature pFeat = null;
                IEnvelope pEnve = new EnvelopeClass();
                while ((pFeat = featureCusor.NextFeature()) != null)
                {
                    pEnve.Union(pFeat.Extent);
                }
                
                if (!pEnve.IsEmpty)
                {
                    pEnve.Expand(4.9, 4.9, true);
                    (axMapControl1.Map as IActiveView).Extent = pEnve;
                    (axMapControl1.Map as IActiveView).Refresh();
                }
                else
                    return;
                sel.SelectFeatures(queryFilter, ESRI.ArcGIS.Carto.esriSelectionResultEnum.esriSelectionResultXOR, false);
                if (feature != null)
                {
                    //m_feature = feature;
                    // m_mapControl.Refresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
                    // sel.Clear();
                    //m_mapControl.Map.FeatureSelection.Clear();
                    sel.SelectFeatures(queryFilter, ESRI.ArcGIS.Carto.esriSelectionResultEnum.esriSelectionResultNew, false);
                    //m_mapControl.Map.SelectFeature(m_featureLayer as ILayer, feature);
                    axMapControl1.Refresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
                   // axMapControl1.CenterAt(feature.Extent.LowerLeft);

                    //m_mapControl.MapScale = 0.1;
                    //m_mapControl.Map.SelectFeature(m_featureLayer as ILayer, null);
                }

             
        }
    }
}