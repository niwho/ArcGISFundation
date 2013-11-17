namespace ArcGISFoundation
{
    partial class QueryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QueryForm));
            this.query_panel = new BSE.Windows.Forms.Panel();
            this.listView_data = new System.Windows.Forms.ListView();
            this.query_panel_container = new System.Windows.Forms.Panel();
            this.panel_title_bar = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.close = new System.Windows.Forms.PictureBox();
            this.min = new System.Windows.Forms.PictureBox();
            this.query_panel.SuspendLayout();
            this.query_panel_container.SuspendLayout();
            this.panel_title_bar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.close)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.min)).BeginInit();
            this.SuspendLayout();
            // 
            // query_panel
            // 
            this.query_panel.BackColor = System.Drawing.Color.Transparent;
            this.query_panel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.query_panel.CaptionFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold);
            this.query_panel.CaptionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.query_panel.CloseIconForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.query_panel.CollapsedCaptionForeColor = System.Drawing.SystemColors.ControlText;
            this.query_panel.ColorCaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.query_panel.ColorCaptionGradientEnd = System.Drawing.SystemColors.ButtonShadow;
            this.query_panel.ColorCaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.query_panel.ColorContentPanelGradientBegin = System.Drawing.Color.Empty;
            this.query_panel.ColorContentPanelGradientEnd = System.Drawing.Color.Empty;
            this.query_panel.Controls.Add(this.listView_data);
            this.query_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.query_panel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.query_panel.Image = null;
            this.query_panel.InnerBorderColor = System.Drawing.Color.White;
            this.query_panel.Location = new System.Drawing.Point(3, 3);
            this.query_panel.Name = "query_panel";
            this.query_panel.PanelStyle = BSE.Windows.Forms.PanelStyle.Office2007;
            this.query_panel.Size = new System.Drawing.Size(665, 378);
            this.query_panel.TabIndex = 0;
            this.query_panel.Text = "牧草查询结果";
            // 
            // listView_data
            // 
            this.listView_data.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView_data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_data.FullRowSelect = true;
            this.listView_data.GridLines = true;
            this.listView_data.Location = new System.Drawing.Point(1, 26);
            this.listView_data.Name = "listView_data";
            this.listView_data.Size = new System.Drawing.Size(663, 351);
            this.listView_data.TabIndex = 0;
            this.listView_data.UseCompatibleStateImageBehavior = false;
            this.listView_data.View = System.Windows.Forms.View.Details;
            this.listView_data.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_data_ColumnClick);
            this.listView_data.SelectedIndexChanged += new System.EventHandler(this.listView_data_SelectedIndexChanged);
            // 
            // query_panel_container
            // 
            this.query_panel_container.BackColor = System.Drawing.Color.Transparent;
            this.query_panel_container.Controls.Add(this.query_panel);
            this.query_panel_container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.query_panel_container.Location = new System.Drawing.Point(0, 65);
            this.query_panel_container.Name = "query_panel_container";
            this.query_panel_container.Padding = new System.Windows.Forms.Padding(3);
            this.query_panel_container.Size = new System.Drawing.Size(671, 384);
            this.query_panel_container.TabIndex = 2;
            // 
            // panel_title_bar
            // 
            this.panel_title_bar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(164)))), ((int)(((byte)(228)))));
            this.panel_title_bar.BackgroundImage = global::ArcGISFoundation.Properties.Resources.banners;
            this.panel_title_bar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_title_bar.Controls.Add(this.pictureBox2);
            this.panel_title_bar.Controls.Add(this.pictureBox1);
            this.panel_title_bar.Controls.Add(this.close);
            this.panel_title_bar.Controls.Add(this.min);
            this.panel_title_bar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_title_bar.Location = new System.Drawing.Point(0, 0);
            this.panel_title_bar.Name = "panel_title_bar";
            this.panel_title_bar.Size = new System.Drawing.Size(671, 65);
            this.panel_title_bar.TabIndex = 1;
            this.panel_title_bar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_title_bar_MouseDown);
            this.panel_title_bar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_title_bar_MouseMove);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::ArcGISFoundation.Properties.Resources.query_logo_title;
            this.pictureBox2.Location = new System.Drawing.Point(66, 17);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(213, 34);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(72, 65);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // close
            // 
            this.close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.close.BackColor = System.Drawing.Color.Transparent;
            this.close.Image = global::ArcGISFoundation.Properties.Resources.close;
            this.close.Location = new System.Drawing.Point(632, -1);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(27, 22);
            this.close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.close.TabIndex = 7;
            this.close.TabStop = false;
            this.close.Click += new System.EventHandler(this.close_Click);
            this.close.MouseEnter += new System.EventHandler(this.close_MouseEnter);
            this.close.MouseLeave += new System.EventHandler(this.close_MouseLeave);
            // 
            // min
            // 
            this.min.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.min.BackColor = System.Drawing.Color.Transparent;
            this.min.Image = global::ArcGISFoundation.Properties.Resources.min;
            this.min.Location = new System.Drawing.Point(598, -1);
            this.min.Name = "min";
            this.min.Size = new System.Drawing.Size(27, 22);
            this.min.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.min.TabIndex = 5;
            this.min.TabStop = false;
            this.min.Click += new System.EventHandler(this.min_Click);
            this.min.MouseEnter += new System.EventHandler(this.min_MouseEnter);
            this.min.MouseLeave += new System.EventHandler(this.min_MouseLeave);
            // 
            // QueryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 449);
            this.Controls.Add(this.query_panel_container);
            this.Controls.Add(this.panel_title_bar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "QueryForm";
            this.Text = "QueryForm";
            this.Load += new System.EventHandler(this.QueryForm_Load);
            this.query_panel.ResumeLayout(false);
            this.query_panel_container.ResumeLayout(false);
            this.panel_title_bar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.close)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.min)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BSE.Windows.Forms.Panel query_panel;
        private System.Windows.Forms.Panel panel_title_bar;
        private System.Windows.Forms.PictureBox close;
        private System.Windows.Forms.PictureBox min;
        private System.Windows.Forms.Panel query_panel_container;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListView listView_data;
    }
}