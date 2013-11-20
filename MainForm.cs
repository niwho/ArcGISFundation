
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
        #region private members
        private IMapControl3 m_mapControl = null;
        TocMapContextMenu m_tocMapContextMenu = null;
        TocLayerContextMenu m_tocLayerContextMenu = null;
        MapControlContextMenu m_mapControlContextMenu = null;
        DataSource m_datasource = null;
        int m_selectedLayer = 0;
        #endregion

        #region For UI
        //临时位置
        private Point temp_point;
        private Form queryForm;

        //当前路径
        private string currPath = "";

        const int CS_DropSHADOW = 0x20000;
        const int GCL_STYLE = (-26);
        //声明Win32 API
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SetClassLong(IntPtr hwnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetClassLong(IntPtr hwnd, int nIndex);

        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(int hWnd, int Msg, int wParam, int lParam);
        [DllImport("User32.dll", EntryPoint = "ReleaseCapture")]
        private static extern int ReleaseCapture();
        #endregion

        #region Ctor
        public MainForm()
        {
            InitializeComponent();
            //this.MyFormMouseDown += new MouseEventHandler(panel_title_bar_MouseDown);
            SetClassLong(this.Handle, GCL_STYLE, GetClassLong(this.Handle, GCL_STYLE) | CS_DropSHADOW); //API函数加载，实现窗体边框阴影效果

            //
            currPath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            //MessageBox.Show("获取和设置包括该应用程序的目录的名称:" + currPath);
        }
        #endregion

        #region MainForm Function
        #region MainForm_Load
        //MainForm_Load
        private string m_bin_path;
        private void MainForm_Load(object sender, EventArgs e)
        {
            m_mapControl = (IMapControl3)axMapControl1.Object;
            m_isQuery = false;
            m_bin_path = System.Environment.CurrentDirectory +'\\';

            //init toc context menu
            InitTocContextMenu();

            //init data source 
            InitDataSouce();

            //init main tool bar
            InitMainToolbar();
            // open map tree
            this.xPanderPanel_tree.Expand = true;

            m_LayerList.Items.Clear();
            for (int i = 0; i < m_mapControl.LayerCount; ++i)
            {
                //string layername = m_mapControl.Layer[i].Name;
                m_LayerList.Items.Add(m_mapControl.Layer[i].Name);
            }
            m_LayerList.SelectedIndex = 0;

        }

        //toc context menu
        private void InitTocContextMenu()
        {
            //Add map menu
            m_tocMapContextMenu = new TocMapContextMenu(m_mapControl);

            //Add layer menu
            m_tocLayerContextMenu = new TocLayerContextMenu(m_mapControl);
        }

        //axMapControl1 context menu
        private void InitMapControlContextMenu()
        {
            //Add map menu
            m_mapControlContextMenu = new MapControlContextMenu(m_mapControl);
        }

        //init data source
        private void InitDataSouce()
        {
            string strDataRoot = m_bin_path + @"..\data\牧草数据\";
            string strInitData =  @"白三叶";
            m_datasource = new DataSource();
            m_datasource.Init(strDataRoot, m_mapControl, treeView_all_cao);
            m_datasource.Refresh();

            if (m_datasource.Switch(strInitData))
            {
                this.xPanderPanel_tree.Text =
               "图层管理--" + strInitData;
            }
        }

        //toc context menu
        private void InitMainToolbar()
        {
            // 增加打开档命令
            string progID;
            progID = "esriControlToolsGeneric.ControlsOpenDocCommand";
            maintoolbar.AddItem(progID, -1, -1, true, 0,
                esriCommandStyles.esriCommandStyleIconOnly);

            progID = "esriControlToolsGeneric.ControlsSaveAsDocCommand";
            maintoolbar.AddItem(progID, -1, -1, false, 0,
                esriCommandStyles.esriCommandStyleIconOnly);

            progID = "esriControlToolsGeneric.ControlsAddDataCommand";
            maintoolbar.AddItem(progID, -1, -1, false, 0,
                esriCommandStyles.esriCommandStyleIconOnly);

            // 增加地图导航命令
            progID = "esriControls.ControlsMapZoomInTool";
            maintoolbar.AddItem(progID, -1, -1, true, 0,
                esriCommandStyles.esriCommandStyleIconOnly);

            progID = "esriControls.ControlsMapZoomOutTool";
            maintoolbar.AddItem(progID, -1, -1, false, 0,
                esriCommandStyles.esriCommandStyleIconOnly);

            progID = "esriControls.ControlsMapPanTool";
            maintoolbar.AddItem(progID, -1, -1, false, 0,
                esriCommandStyles.esriCommandStyleIconOnly);

            progID = "esriControls.ControlsMapFullExtentCommand";
            maintoolbar.AddItem(progID, -1, -1, false, 0,
                esriCommandStyles.esriCommandStyleIconOnly);

            progID = "esriControls.ControlsMapHyperlinkTool";
            maintoolbar.AddItem(progID, -1, -1, false, 0,
                esriCommandStyles.esriCommandStyleIconOnly);

            progID = "esriControls.ControlsMapIdentifyTool";
            maintoolbar.AddItem(progID, -1, -1, false, 0,
                esriCommandStyles.esriCommandStyleIconOnly);

            //
           /* progID = "esriControls.ControlsLayerListToolControl";
            maintoolbar.AddItem(progID, -1, -1, true, 0,
                esriCommandStyles.esriCommandStyleIconOnly);*/

           /* progID = "ArcGISFoundation.Source.Query.Command1";
            maintoolbar.AddItem(progID, -1, -1, true, 0,
               esriCommandStyles.esriCommandStyleIconOnly);            progID = "nw_query.nw_query";
            ICommand command = new nw_query.nw_query(axMapControl1);
            maintoolbar.AddItem(progIDcommand, -1, -1, true, 0,
               esriCommandStyles.esriCommandStyleIconOnly);*/
        }
        #endregion

        private void MainForm_Shown(object sender, EventArgs e)
        {
           
        }
        //窗体改变大小时
        private void MainForm_Resize(object sender, EventArgs e)
        {
            Point min_point = new Point(this.Width - 100, 0);
            this.min.Location = min_point;
            Point max_point = new Point(this.Width - 70, 0);
            this.max.Location = max_point;
            Point close_point = new Point(this.Width - 40, 0);
            this.close.Location = close_point;
            //刷新
            this.Refresh();
        }
        #endregion

        #region public properties

        // Returns the MapControl
        public IMapControl3 MapControl
        {
            get { return m_mapControl; }
        }

        #endregion

        #region Main UI Event
        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void close_MouseEnter(object sender, EventArgs e)
        {
            this.close.Image = Image.FromFile(m_bin_path+@"..\images\close_hover.png");
        }

        private void close_MouseLeave(object sender, EventArgs e)
        {
            this.close.Image = Image.FromFile(m_bin_path+@"..\images\close.png");
        }

        private void max_MouseEnter(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.max.Image = Image.FromFile(m_bin_path+@"..\images\max_hover.png");
            }
            else
            {
                this.max.Image = Image.FromFile(m_bin_path+@"..\images\yuan_hover.png");
            }
        }

        private void max_MouseLeave(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.max.Image = Image.FromFile(m_bin_path+@"..\images\max.png");
            }
            else
            {
                this.max.Image = Image.FromFile(m_bin_path+@"..\images\yuan.png ");
            }
        }

        private void max_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.MaximumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void min_MouseEnter(object sender, EventArgs e)
        {
            this.min.Image = Image.FromFile(m_bin_path+@"..\images\min_hover.png");
        }

        private void min_MouseLeave(object sender, EventArgs e)
        {
            this.min.Image = Image.FromFile(m_bin_path+@"..\images\min.png");
        }

        private void panel_title_bar_MouseDown(object sender, MouseEventArgs e)
        {
            temp_point = new Point(e.X, e.Y);
        }

        private void panel_title_bar_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.MaximumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
                //设置还原图片
                this.max.Image = Image.FromFile(m_bin_path+@"..\images\yuan.png");
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.max.Image = Image.FromFile(m_bin_path+@"..\images\max.png");
                this.WindowState = FormWindowState.Normal;
            }

        }

        private void panel_title_bar_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && (e.X - temp_point.X != 0 || e.Y - temp_point.Y != 0))
            {
                ReleaseCapture();
                SendMessage(this.Handle.ToInt32(), 0x0112, 0xF012, 0);
            }
        }

        //边框的绘制
        private void panel_container_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics,
                                this.panel_container.ClientRectangle,
                                Color.LightSeaGreen,         //left
                                1,
                                ButtonBorderStyle.None,
                                Color.LightSeaGreen,         //top
                                0,
                                ButtonBorderStyle.Solid,
                                Color.LightSeaGreen,        //right
                                1,
                                ButtonBorderStyle.Solid,
                                Color.LightSeaGreen,        //bottom
                                1,
                                ButtonBorderStyle.Solid);

        }

        private void panel_right_map_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox_tools1_Click(object sender, EventArgs e)
        {
            this.axMapControl1.CurrentTool = null;
          //  this.axMapControl1.ActiveView.Selection.
            m_isQuery = true;
            return;
        }

        private void pictureBox_query_Click(object sender, EventArgs e)
        {
            string strImageName = @"MapPrameter";
            string strImageType = @"JPG";
            string strImageDir = m_bin_path + @"../Output";
            string localFilePath = "";

            string strImagePath = m_bin_path + @"../Output/Map.JPG";

            Size size = new Size(3474,1479);

            //this.folderBrowserDialog_printer.Filter = "Special Files(*.png)|*.jpg|All files (*.*)|*.*";

            //this.openFileDialog_printer.Description = "请选择路径";
            this.saveFileDialog_printer.Filter = "jpg files (*.jpg)|*.jpg|png files (*.png)|*.png|gif files(*.gif)|*.gif|bmp files (*.bmp)|*.bmp|tiff files (*.tiff)|*.tiff";
            this.saveFileDialog_printer.FilterIndex = 1;
            //this.openFileDialog_printer.RootFolder = Environment.SpecialFolder.Desktop;
            DialogResult result = this.saveFileDialog_printer.ShowDialog();
            //保存对话框是否记忆上次打开的目录  
            this.saveFileDialog_printer.RestoreDirectory = true;

            if (result == DialogResult.OK)
            {
                //获得文件路径
                localFilePath = this.saveFileDialog_printer.FileName.ToString();  
                //获取文件名，不带路径  
                strImageName = localFilePath.Substring(localFilePath.LastIndexOf("\\") + 1);

                strImageType = strImageName.Substring(strImageName.LastIndexOf(".") + 1);
                strImageName = strImageName.Substring(0,strImageName.LastIndexOf("."));
                //获取文件路径，不带文件名  
                strImageDir = localFilePath.Substring(0, localFilePath.LastIndexOf("\\")); 

                //this.folderBrowserDialog_printer.
                PrintHelper.ExportActiveView(m_mapControl.ActiveView, 300, 5, strImageType, strImageDir, strImageName, true, m_mapControl.ActiveView.Extent);
            }
           
            //PrintHelper.ExportActiveView(m_mapControl.ActiveView, size, strImagePath);        
        }


        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ExcelImportForm form = new ExcelImportForm(m_bin_path);
            form.ShowDialog(this);
        }

        private void maintoolbar_OnItemClick(object sender, IToolbarControlEvents_OnItemClickEvent e)
        {
            m_isQuery = false;
        }

        private void treeView_all_cao_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Left &&
                e.Node.Level > 1 &&
                m_datasource.Switch(e.Node.Text))
            {
                e.Node.ForeColor = Color.BlueViolet;
                Pasture pasture= m_datasource.GetActivePasture();

                this.xPanderPanel_tree.Text = "图层管理--" + pasture.strPasture;
                this.xPanderPanel_tree.Expand = true;
                this.xPanderPanel_query.Expand = false;

                m_LayerList.Items.Clear();
                for (int i = 0; i < m_mapControl.LayerCount; ++i)
                {
                    //string layername = m_mapControl.Layer[i].Name;
                    m_LayerList.Items.Add(m_mapControl.Layer[i].Name);
                }
                m_LayerList.SelectedIndex = 0;
                m_mucao = pasture.strPasture;
            }
        }

        #endregion

        #region Control Event
        private void axTOCControl1_OnMouseDown(object sender, ITOCControlEvents_OnMouseDownEvent e)
        {
            //make sure that the user right clicked
            if (2 != e.button)
                return;

            //use HitTest in order to test whether the user has selected a featureLayer
            esriTOCControlItem item = esriTOCControlItem.esriTOCControlItemNone;
            IBasicMap map = null;
            ILayer layer = null;
            object other = null;
            object index = null;

            //do the HitTest
            toccontrol.HitTest(e.x, e.y, ref item, ref map, ref layer, ref other, ref index);

            //set the featurelayer as the custom property of the MapControl
            axMapControl1.CustomProperty = layer;

            //Ensure the item gets selected 
            if (item == esriTOCControlItem.esriTOCControlItemMap)
                toccontrol.SelectItem(map, null);
            else
                toccontrol.SelectItem(layer, null);

            //Set the layer into the CustomProperty (this is used by the custom layer commands)			
            axMapControl1.CustomProperty = layer;

            //Popup the correct context menu
            if (item == esriTOCControlItem.esriTOCControlItemMap)
                m_tocMapContextMenu.PopupMenu(e.x, e.y, toccontrol.hWnd);

            if (item == esriTOCControlItem.esriTOCControlItemLayer)
                m_tocLayerContextMenu.PopupMenu(e.x, e.y, toccontrol.hWnd);
        }

        private void axMapControl1_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            //make sure that the user right clicked
            if (m_isQuery && 1 == e.button)
            {
                m_isQuery = false;//暂时这样处理
                nw_query();
                return;
            }
            if (2 != e.button)
                return;

            m_mapControlContextMenu.PopupMenu(e.x, e.y, axMapControl1.hWnd);

        }

        private void axMapControl1_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            this.coorText.Text = string.Format("{0}{1}{2}{3} {4}", "坐标：", e.mapX.ToString("#######.###"), "，", e.mapY.ToString("#######.###"), axMapControl1.MapUnits.ToString().Substring(4));
        }

        #endregion

        private void m_LayerList_DropDown(object sender, EventArgs e)
        {
            m_LayerList.Items.Clear();
            for(int i =0;i<m_mapControl.LayerCount;++i)
            {
                //string layername = m_mapControl.Layer[i].Name;
                m_LayerList.Items.Add(m_mapControl.Layer[i].Name);
            }
        }

        private void m_LayerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_selectedLayer = m_LayerList.SelectedIndex;
        }

    }
}