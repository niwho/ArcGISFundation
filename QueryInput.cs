using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ArcGISFoundation
{
    public partial class QueryInput : Form
    {
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(int hWnd, int Msg, int wParam, int lParam);
        [DllImport("User32.dll", EntryPoint = "ReleaseCapture")]
        private static extern int ReleaseCapture();

        //临时位置
        private System.Drawing.Point temp_point;
        private string m_bin_path;
        public ArcGISFoundation.Source.Query.DecisionMaking_query m_dmq;
        public ArcGISFoundation.QueryForm m_qf;

        public QueryInput(string path)
        {
            m_bin_path = path;
            InitializeComponent();
            

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

        private void queryBtn_Click(object sender, EventArgs e)//行政区域
        {
            if (textBox1.Text.Trim() == "")
                /*{
                    MessageBox.Show("NULL");
                }*/
                return;
            m_dmq.m_qf = m_qf;
           // m_qf.QueryForm_SetText(textBox1.Text.Trim());
            m_dmq.Query(textBox1.Text.Trim());
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)//牧草名称
        {
           // textBox2.Text;
            if (textBox2.Text.Trim() == "")
                /*{
                    MessageBox.Show("NULL");
                }*/
                return;
            m_dmq.m_qf = m_qf;
            m_dmq.Query2(textBox2.Text.Trim());
            this.Close();
        
        }


    }
}
