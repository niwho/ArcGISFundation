using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
namespace ArcGISFoundation
{
    public partial class QueryForm : Form
    {

        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(int hWnd, int Msg, int wParam, int lParam);
        [DllImport("User32.dll", EntryPoint = "ReleaseCapture")]
        private static extern int ReleaseCapture();
       
        //临时位置
        private System.Drawing.Point temp_point;
        private string m_bin_path;
        private sortListView.ListViewColumnSorter lvwColumnSorter;

        public ESRI.ArcGIS.Controls.AxMapControl m_mapControl;
        public ESRI.ArcGIS.Carto.IFeatureLayer m_featureLayer;
        public IFeature m_feature;
        public string m_query_name;
        public string m_mucao;
        public string m_layername;

        public QueryForm(string path)
        {
            m_bin_path = path;
            InitializeComponent();
            lvwColumnSorter = new sortListView.ListViewColumnSorter();
            this.listView_data.ListViewItemSorter = lvwColumnSorter;
        }
       
        public System.Windows.Forms.ListView nw_getListView()
        {
            return listView_data;
        }
        private void QueryForm_Load(object sender, EventArgs e)
        {
            query_panel.Text =m_layername+ "    牧草：" +m_mucao;
        }

        private void min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void min_MouseEnter(object sender, EventArgs e)
        {
            this.min.Image = Image.FromFile(m_bin_path + @"..\images\min_hover.png");
        }

        private void min_MouseLeave(object sender, EventArgs e)
        {
            this.min.Image = Image.FromFile(m_bin_path + @"..\images\min.png");
        }

        private void close_Click(object sender, EventArgs e)
        {
            m_mapControl.Refresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
            m_mapControl.Map.ClearSelection();      
            m_mapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
            this.Close();
        }

        private void close_MouseEnter(object sender, EventArgs e)
        {
            this.close.Image = Image.FromFile(m_bin_path + @"..\images\close_hover.png");
        }

        private void close_MouseLeave(object sender, EventArgs e)
        {
            this.close.Image = Image.FromFile(m_bin_path + @"..\images\close.png");
        }

        private void panel_title_bar_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && (e.X - temp_point.X != 0 || e.Y - temp_point.Y != 0))
            {
                ReleaseCapture();
                SendMessage(this.Handle.ToInt32(), 0x0112, 0xF012, 0);
            }
        }

        private void panel_title_bar_MouseDown(object sender, MouseEventArgs e)
        {
            temp_point = new System.Drawing.Point(e.X, e.Y);
        }

        private void listView_data_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 1 ||e.Column == 2)
            {
                lvwColumnSorter.SortColumn = e.Column;
                // 重新设置此列的排序方法.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                } 
                // 用新的排序方法对ListView排序
                this.listView_data.Sort();    
            }
            
                 
        }

        private void listView_data_SelectedIndexChanged(object sender, EventArgs e)
        {
            return;
            if (listView_data.SelectedIndices != null && listView_data.SelectedIndices.Count > 0)
            {
                ListView.SelectedIndexCollection c = listView_data.SelectedIndices;
                string str = this.listView_data.SelectedItems[0].SubItems[1].Text;
                //MessageBox.Show( listView_data.Items[c[0]].Text);

                IFeatureClass featureClass = m_featureLayer.FeatureClass;
                IFeatureSelection sel = m_featureLayer as IFeatureSelection; 
                
                IFeature feature = null;

                m_mapControl.Refresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
                m_mapControl.Map.ClearSelection();
                m_mapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);

                IQueryFilter queryFilter = new QueryFilterClass();
                IFeatureCursor featureCusor;
                queryFilter.WhereClause = m_query_name +" = '" + this.listView_data.SelectedItems[0].SubItems[0].Text + "'";
                featureCusor = featureClass.Search(queryFilter, true);
                //search的参数第一个为过滤条件，第二个为是否重复执行。
                //feature = featureCusor.NextFeature();
                IFeature pFeat = null;
                IEnvelope pEnve = new EnvelopeClass();
                while ((pFeat = featureCusor.NextFeature()) != null)
                {
                    pEnve.Union(pFeat.Extent);
                }

                if (pEnve != null)
                {
                    pEnve.Expand(2, 2, true);
                    (m_mapControl.Map as IActiveView).Extent = pEnve;
                    (m_mapControl.Map as IActiveView).Refresh();
                }
                sel.SelectFeatures(queryFilter, ESRI.ArcGIS.Carto.esriSelectionResultEnum.esriSelectionResultXOR, false);
                if (feature != null)
                {
                    //m_feature = feature;
                   // m_mapControl.Refresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
                   // sel.Clear();
                    //m_mapControl.Map.FeatureSelection.Clear();
                    sel.SelectFeatures(queryFilter, ESRI.ArcGIS.Carto.esriSelectionResultEnum.esriSelectionResultNew, false);
                    //m_mapControl.Map.SelectFeature(m_featureLayer as ILayer, feature);
                    m_mapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
                    m_mapControl.CenterAt(feature.Extent.LowerLeft);

                    //m_mapControl.MapScale = 0.1;
                    //m_mapControl.Map.SelectFeature(m_featureLayer as ILayer, null);
                }

            }
        }

        private void listView_data_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           // MessageBox.Show(this.listView_data.SelectedItems[0].SubItems[0].Text);
            if (listView_data.SelectedIndices != null && listView_data.SelectedIndices.Count > 0)
            {
                ListView.SelectedIndexCollection c = listView_data.SelectedIndices;
                string str = this.listView_data.SelectedItems[0].SubItems[1].Text;
                //MessageBox.Show( listView_data.Items[c[0]].Text);

                IFeatureClass featureClass = m_featureLayer.FeatureClass;
                IFeatureSelection sel = m_featureLayer as IFeatureSelection;

                IFeature feature = null;

                m_mapControl.Refresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
                m_mapControl.Map.ClearSelection();
                m_mapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);

                IQueryFilter queryFilter = new QueryFilterClass();
                IFeatureCursor featureCusor;
                queryFilter.WhereClause = m_query_name + " = '" + this.listView_data.SelectedItems[0].SubItems[0].Text + "'";
                featureCusor = featureClass.Search(queryFilter, true);
                //search的参数第一个为过滤条件，第二个为是否重复执行。
                //feature = featureCusor.NextFeature();
                IFeature pFeat = null;
                IEnvelope pEnve = new EnvelopeClass();
                while ((pFeat = featureCusor.NextFeature()) != null)
                {
                    pEnve.Union(pFeat.Extent);
                }

                if (pEnve != null)
                {
                    pEnve.Expand(2, 2, true);
                    (m_mapControl.Map as IActiveView).Extent = pEnve;
                    (m_mapControl.Map as IActiveView).Refresh();
                }
                sel.SelectFeatures(queryFilter, ESRI.ArcGIS.Carto.esriSelectionResultEnum.esriSelectionResultXOR, false);
                if (feature != null)
                {
                    //m_feature = feature;
                    // m_mapControl.Refresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
                    // sel.Clear();
                    //m_mapControl.Map.FeatureSelection.Clear();
                    sel.SelectFeatures(queryFilter, ESRI.ArcGIS.Carto.esriSelectionResultEnum.esriSelectionResultNew, false);
                    //m_mapControl.Map.SelectFeature(m_featureLayer as ILayer, feature);
                    m_mapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
                    m_mapControl.CenterAt(feature.Extent.LowerLeft);

                    //m_mapControl.MapScale = 0.1;
                    //m_mapControl.Map.SelectFeature(m_featureLayer as ILayer, null);
                }

            }
        }
    }
}
