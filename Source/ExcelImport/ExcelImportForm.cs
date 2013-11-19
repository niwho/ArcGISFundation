using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace ArcGISFoundation
{
    public partial class ExcelImportForm : Form
    {
        public ExcelImportForm()
        {
            InitializeComponent();
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
    }
}
