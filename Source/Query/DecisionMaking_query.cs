using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
namespace ArcGISFoundation.Source.Query
{
    public class DecisionMaking_query
    {
        public string m_connStr;
        public string m_connStrci;
        public OleDbConnection m_conn;
        public OleDbConnection m_connci;
        OleDbDataAdapter da = new OleDbDataAdapter();//(sql, m_conn);
        public DataSet ds = new DataSet();

        public ArcGISFoundation.QueryForm m_qf;
        String m_sql = "SELECT * FROM  [Sheet1$] where 行政区名称 like \"%{0}%\"";//Sheet1$
        String m_sql2 = "SELECT * FROM  [Sheet1$] where 牧草名称 like \"%{0}%\"";//Sheet1$

        public void init(string fileName,string cifilename)
        {
            m_connStr = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + fileName + ";" + ";Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\"";
            //m_connStrci = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + cifilename + ";" + ";Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\"";
            try
            {
                m_conn = new OleDbConnection(m_connStr);
                m_conn.Open();
               // m_connci = new OleDbConnection(m_connStrci);
               // m_connci.Open();
               // String sql = "SELECT * FROM  [Sheet1$]";//可是更改Sheet名称，比如sheet2，等等   
                //OleDbDataAdapter da = new OleDbDataAdapter(sql, m_conn);

                da.SelectCommand = new OleDbCommand("SELECT * FROM  [Sheet1$]", m_conn);
                da.Fill(ds, "sheet1");
               m_conn.Close();

                //遍历一个表多行多列
               /* foreach (DataRow mDr in ds.Tables[0].Rows)
                {
                    foreach (DataColumn mDc in ds.Tables[0].Columns)
                    {
                        Console.WriteLine(mDc.ColumnName);
                        Console.WriteLine(mDr[mDc].ToString());
                    }
                }
                ds.Clear();*/
                /*
                DataTable dtSheetName = m_conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

                string sql_F = "Select * FROM [{0}]";
                for (int i = 0; i < dtSheetName.Rows.Count; i++)
                {
                    string SheetName = (string)dtSheetName.Rows[i]["TABLE_NAME"];

                    if (SheetName.Contains("$") && !SheetName.Replace("'", "").EndsWith("$"))
                    {
                        continue;
                    }
                    OleDbDataAdapter daa = new OleDbDataAdapter();
                    daa.SelectCommand = new OleDbCommand(String.Format(sql_F, SheetName), m_conn);
                    DataSet dsItem = new DataSet();
                    daa.Fill(dsItem, SheetName);

                    //ds.Tables.Add(dsItem.Tables[0].Copy());
                }*/
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
        public  void Query(string str )//按行政区域
        {

           
            // ds.Merge()
            ArcGISFoundation.QueryForm m_qf = new ArcGISFoundation.QueryForm(true);
            System.Windows.Forms.ListView listView_data = m_qf.nw_getListView();
            listView_data.Items.Clear(); listView_data.Clear();
            //MessageBox.Show("clear完成");
            listView_data.Columns.Clear();

            listView_data.Columns.Add("行政区域名", 120, HorizontalAlignment.Left);//省名,,
            listView_data.Columns.Add("牧草名", 120, HorizontalAlignment.Left);//省名,,
            listView_data.Columns.Add("适宜面积比", 120, HorizontalAlignment.Left);
            listView_data.Columns.Add("适宜面积", 120, HorizontalAlignment.Left);
            listView_data.Columns.Add("次适宜面积比", 120, HorizontalAlignment.Left);
            listView_data.Columns.Add("次适宜面积", 120, HorizontalAlignment.Left);

            m_qf.QueryForm_SetText(str);
            //MessageBox.Show(str);
            DataRow[] rows = ds.Tables[0].Select("行政区名称 like '%"+str+"%'");
            //MessageBox.Show("ds查询完成");
            foreach (DataRow mDr in rows)
            {
                ListViewItem lvi = new ListViewItem();//null;
                lvi.Text = mDr[1].ToString();//ds.Tables[0].Columns[0].ToString();//str;
                try
                {
                    lvi.SubItems.Add(mDr[0].ToString());//ds.Tables[0].Columns[2].ToString()
                    lvi.SubItems.Add(mDr[3].ToString());//ds.Tables[0].Columns[2].ToString()
                    lvi.SubItems.Add(mDr[2].ToString());//ds.Tables[0].Columns[3].ToString()
                    lvi.SubItems.Add(mDr[5].ToString());//ds.Tables[0].Columns[2].ToString()
                    lvi.SubItems.Add(mDr[4].ToString());//ds.Tables[0].Columns[3].ToString()
                    
                }
                catch (System.Exception ex)
                {

                    System.Console.WriteLine(ex.Message);
                }
                finally
                {
                    listView_data.Items.Add(lvi);
                }
            }
            //MessageBox.Show("插入列表完成");
           // m_conn.Close();
            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("暂无数据");
                return;
            }
          //  ds.Clear();
            m_qf.Show();

            return;

            /*m_conn.Open();
            da.SelectCommand = new OleDbCommand(String.Format(m_sql, str), m_conn);
            da.Fill(ds, "sheet1");
            // ds.Merge()
            System.Windows.Forms.ListView listView_data = m_qf.nw_getListView();
            listView_data.Items.Clear();
            listView_data.Columns.Clear();

            listView_data.Columns.Add("行政区域名", 120, HorizontalAlignment.Left);//省名,,
            listView_data.Columns.Add("牧草名", 120, HorizontalAlignment.Left);//省名,,
            listView_data.Columns.Add("适宜面积比", 120, HorizontalAlignment.Left);
            listView_data.Columns.Add("适宜面积", 120, HorizontalAlignment.Left);
            listView_data.Columns.Add("次适宜面积比", 120, HorizontalAlignment.Left);
            listView_data.Columns.Add("次适宜面积", 120, HorizontalAlignment.Left);

            m_qf.QueryForm_SetText(str);
            //MessageBox.Show(str);

            foreach (DataRow mDr in ds.Tables[0].Rows)
            {
                ListViewItem lvi = new ListViewItem();//null;
                lvi.Text = mDr[1].ToString();//ds.Tables[0].Columns[0].ToString();//str;
                try
                {
                    lvi.SubItems.Add(mDr[0].ToString());//ds.Tables[0].Columns[2].ToString()
                    lvi.SubItems.Add(mDr[3].ToString());//ds.Tables[0].Columns[2].ToString()
                    lvi.SubItems.Add(mDr[2].ToString());//ds.Tables[0].Columns[3].ToString()
                    lvi.SubItems.Add(mDr[5].ToString());//ds.Tables[0].Columns[2].ToString()
                    lvi.SubItems.Add(mDr[4].ToString());//ds.Tables[0].Columns[3].ToString()
                    
                }
                catch (System.Exception ex)
                {

                    System.Console.WriteLine(ex.Message);
                }
                finally
                {
                    listView_data.Items.Add(lvi);
                }
            }
            m_conn.Close();
            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("暂无数据");
                return;
            }
            ds.Clear();
            m_qf.Show();*/
           

        }

        public  void Query2(string str )//按牧草查询yy
        {
            
            ArcGISFoundation.QueryForm m_qf = new ArcGISFoundation.QueryForm(true);
            System.Windows.Forms.ListView listView_data = m_qf.nw_getListView();
            listView_data.Items.Clear();
            listView_data.Columns.Clear();
            listView_data.Columns.Add("牧草名", 120, HorizontalAlignment.Left);
            listView_data.Columns.Add("行政区域名", 120, HorizontalAlignment.Left);//省名,,
            listView_data.Columns.Add("适宜面积比", 120, HorizontalAlignment.Left);
            listView_data.Columns.Add("适宜面积", 120, HorizontalAlignment.Left);
            listView_data.Columns.Add("次适宜面积比", 120, HorizontalAlignment.Left);
            listView_data.Columns.Add("次适宜面积", 120, HorizontalAlignment.Left);

            m_qf.QueryForm_SetText(str);
            //MessageBox.Show(str);

            DataRow[] rows = ds.Tables[0].Select("牧草名称 like '%"+str+"%'");
            foreach (DataRow mDr in rows)
            {
                ListViewItem lvi = new ListViewItem();//null;
                lvi.Text = mDr[0].ToString();//ds.Tables[0].Columns[0].ToString();//str;
                try
                {
                    lvi.SubItems.Add(mDr[1].ToString());//ds.Tables[0].Columns[2].ToString()
                    lvi.SubItems.Add(mDr[3].ToString());//ds.Tables[0].Columns[2].ToString()
                    lvi.SubItems.Add(mDr[2].ToString());//ds.Tables[0].Columns[3].ToString()
                    lvi.SubItems.Add(mDr[5].ToString());//ds.Tables[0].Columns[2].ToString()
                    lvi.SubItems.Add(mDr[4].ToString());//ds.Tables[0].Columns[3].ToString()
                }
                catch (System.Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
                finally
                {
                    listView_data.Items.Add(lvi);
                }
            }
            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("暂无数据");
                return;
            }
            m_qf.Show();
        }
        public  void Query3(string str )//按牧草查询yy
        {
            m_conn.Open();
            da.SelectCommand = new OleDbCommand(String.Format(m_sql2, str), m_conn);
            da.Fill(ds, "sheet1");
           // ds.Merge()
            System.Windows.Forms.ListView listView_data = m_qf.nw_getListView();
            listView_data.Items.Clear();
            listView_data.Columns.Clear();
            listView_data.Columns.Add("牧草名", 120, HorizontalAlignment.Left);
            listView_data.Columns.Add("行政区域名", 120, HorizontalAlignment.Left);//省名,,
            listView_data.Columns.Add("适宜面积比", 120, HorizontalAlignment.Left);
            listView_data.Columns.Add("适宜面积", 120, HorizontalAlignment.Left);
            listView_data.Columns.Add("次适宜面积比", 120, HorizontalAlignment.Left);
            listView_data.Columns.Add("次适宜面积", 120, HorizontalAlignment.Left);

            m_qf.QueryForm_SetText(str);
            //MessageBox.Show(str);

            foreach (DataRow mDr in ds.Tables[0].Rows)
            {
                ListViewItem lvi = new ListViewItem();//null;
                lvi.Text = mDr[0].ToString();//ds.Tables[0].Columns[0].ToString();//str;
                try
                {
                    lvi.SubItems.Add(mDr[1].ToString());//ds.Tables[0].Columns[2].ToString()
                    lvi.SubItems.Add(mDr[3].ToString());//ds.Tables[0].Columns[2].ToString()
                    lvi.SubItems.Add(mDr[2].ToString());//ds.Tables[0].Columns[3].ToString()
                    lvi.SubItems.Add(mDr[5].ToString());//ds.Tables[0].Columns[2].ToString()
                    lvi.SubItems.Add(mDr[4].ToString());//ds.Tables[0].Columns[3].ToString()
                }
                catch (System.Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
                finally
                {
                    listView_data.Items.Add(lvi);
                }
            }
            m_conn.Close();
            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("暂无数据");
                return;
            }
            ds.Clear();
            m_qf.Show();
        }
    }
}
