
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
        #endregion

        #region For UI
        //临时位置
        private Point temp_point;
        private Form queryForm;

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
        }
        #endregion

        #region MainForm Function
        #region MainForm_Load
        //MainForm_Load
        private void MainForm_Load(object sender, EventArgs e)
        {
            m_mapControl = (IMapControl3)axMapControl1.Object;

            //init toc context menu
            InitTocContextMenu();

            //init map doc
            InitMapDoc();

            //init main tool bar
            InitMainToolbar();
            // open map tree
            this.xPanderPanel_tree.Expand = true;
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

        //toc context menu
        private void InitMapDoc()
        {
            //map doc file path
            string filePath = @"..\data\白三叶\白三叶.mxd";
            IMapDocument mapDoc = new MapDocumentClass();
            if (mapDoc.get_IsPresent(filePath) &&
                !mapDoc.get_IsPasswordProtected(filePath))
            {
                mapDoc.Open(filePath, string.Empty);

                // set the first map as the active view
                IMap map = mapDoc.get_Map(0);
                mapDoc.SetActiveView((IActiveView)map);

                //assign the opened map to the MapControl
                m_mapControl.DocumentFilename = filePath;
                m_mapControl.Map = map;

                mapDoc.Close();
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
            progID = "esriControlToolsMapNavigation.ControlsMapZoomInTool";
            maintoolbar.AddItem(progID, -1, -1, true, 0,
                esriCommandStyles.esriCommandStyleIconOnly);

            progID = "esriControlToolsMapNavigation.ControlsMapZoomOutTool";
            maintoolbar.AddItem(progID, -1, -1, false, 0,
                esriCommandStyles.esriCommandStyleIconOnly);

            progID = "esriControlToolsMapNavigation.ControlsMapPanTool";
            maintoolbar.AddItem(progID, -1, -1, false, 0,
                esriCommandStyles.esriCommandStyleIconOnly);

            progID = "esriControlToolsMapNavigation.ControlsMapFullExtentCommand";
            maintoolbar.AddItem(progID, -1, -1, false, 0,
                esriCommandStyles.esriCommandStyleIconOnly);

            //
            progID = "esriControls.ControlsLayerListToolControl";
            maintoolbar.AddItem(progID, -1, -1, true, 0,
                esriCommandStyles.esriCommandStyleIconOnly);
        }
        #endregion

        private void MainForm_Shown(object sender, EventArgs e)
        {
            //Warn users if the ArcGIS Engine samples used by this application have not been compiled
            ArrayList checkList = new ArrayList();
            checkList.Add("ReshapePolylineEditTask_CS.ReshapePolylineEditTask");
            checkList.Add("VertexCommands_CS.UsingOutOfBoxVertexCommands");

            Type t = null;
            bool success = true;

            foreach (string item in checkList)
            {
                t = Type.GetTypeFromProgID(item);

                if (t == null)
                {
                    success = false;
                    break;
                }
            }
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
            this.close.Image = Image.FromFile(@"..\images\close_hover.png");
        }

        private void close_MouseLeave(object sender, EventArgs e)
        {
            this.close.Image = Image.FromFile(@"..\images\close.png");
        }

        private void max_MouseEnter(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.max.Image = Image.FromFile(@"..\images\max_hover.png");
            }
            else
            {
                this.max.Image = Image.FromFile(@"..\images\yuan_hover.png");
            }
        }

        private void max_MouseLeave(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.max.Image = Image.FromFile(@"..\images\max.png");
            }
            else
            {
                this.max.Image = Image.FromFile(@"..\images\yuan.png ");
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
            this.min.Image = Image.FromFile(@"..\images\min_hover.png");
        }

        private void min_MouseLeave(object sender, EventArgs e)
        {
            this.min.Image = Image.FromFile(@"..\images\min.png");
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
                this.max.Image = Image.FromFile(@"..\images\yuan.png");
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.max.Image = Image.FromFile(@"..\images\max.png");
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
            if (2 != e.button)
                return;

            m_mapControlContextMenu.PopupMenu(e.x, e.y, axMapControl1.hWnd);

        }

        private void axMapControl1_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            this.coorText.Text = string.Format("{0}{1}{2}{3} {4}","坐标：", e.mapX.ToString("#######.###"),"，", e.mapY.ToString("#######.###"), axMapControl1.MapUnits.ToString().Substring(4));
        }

        #endregion

        private void panel_right_map_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox_tools1_Click(object sender, EventArgs e)
        {
            queryForm = new QueryForm();
            queryForm.Show();
        }

        private void treeView_all_cao_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            this.xPanderPanel_tree.Expand = true;
            this.xPanderPanel_query.Expand = false;
        }
    }
}