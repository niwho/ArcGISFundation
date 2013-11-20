using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Runtime.InteropServices;

namespace ArcGISFoundation
{
    public partial class ExcelImportForm : Form
    {

        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(int hWnd, int Msg, int wParam, int lParam);
        [DllImport("User32.dll", EntryPoint = "ReleaseCapture")]
        private static extern int ReleaseCapture();

        private string m_bin_path;
        //临时位置
        private System.Drawing.Point temp_point;

        public ExcelImportForm(string path)
        {
            InitializeComponent();
            m_bin_path = path;
        }
        //Excel连接
        OleDbConnection m_connection;

        private void ExcelImportForm_Load(object sender, EventArgs e)
        {
        }

        private void OpenExcel_Click(object sender, EventArgs e)
        {
            try
            {
                openExcelDialog.Title = "打开Excel表格";
                openExcelDialog.Filter = "Excel表格(*.xls)|*.xls|CSV格式(*.csv)|*.csv";
                openExcelDialog.ShowDialog();
                string FileName = openExcelDialog.FileName;
                string strConn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" 
                    + FileName + ";Extended Properties=Excel 8.0";

                m_connection = new OleDbConnection(strConn);
                DataTable table = new DataTable();

                m_connection.Open();

                table = m_connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, 
                    new object[] { null, null, null, "Table" });

                excelCmbBox.Items.Clear();
                foreach (DataRow dr in table.Rows)
                {
                    excelCmbBox.Items.Add(dr["TABLE_NAME"].ToString());
                }
                excelCmbBox.Text = excelCmbBox.Items[0].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Open_Click(object sender, EventArgs e)
        {
            try
            {
                string sheetName = excelCmbBox.Text;
                string strCom = @"Select * from [" + sheetName + "]";
                OleDbDataAdapter Command = new OleDbDataAdapter(strCom, m_connection);
                DataSet dataSet = new DataSet();
                Command.Fill(dataSet, "[" + sheetName + "]");
                excelGridView.DataMember = "[" + sheetName + "]";
                excelGridView.DataSource = dataSet;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CreateShpFile_Click(object sender, EventArgs e)
        {
            CreateShpFileForm form = new CreateShpFileForm(axMapControl1, excelGridView);
            form.ShowDialog(this);
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Visible = true;
                this.WindowState = FormWindowState.Normal;
            }
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

        private void panel_title_bar_MouseDown(object sender, MouseEventArgs e)
        {
            temp_point = new System.Drawing.Point(e.X, e.Y);
        }

        private void panel_title_bar_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && (e.X - temp_point.X != 0 || e.Y - temp_point.Y != 0))
            {
                ReleaseCapture();
                SendMessage(this.Handle.ToInt32(), 0x0112, 0xF012, 0);
            }
        }
    }
}
