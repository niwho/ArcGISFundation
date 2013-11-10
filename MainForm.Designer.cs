// Copyright 2010 ESRI
// 
// All rights reserved under the copyright laws of the United States
// and applicable international laws, treaties, and conventions.
// 
// You may freely redistribute and use this sample code, with or
// without modification, provided you include the original copyright
// notice and use restrictions.
// 
// See the use restrictions at &lt;your ArcGIS install location&gt;/DeveloperKit10.0/userestrictions.txt.
// 

namespace ArcGISFoundation
{
    partial class MainForm
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
            //Ensures that any ESRI libraries that have been used are unloaded in the correct order. 
            //Failure to do this may result in random crashes on exit due to the operating system unloading 
            //the libraries in the incorrect order. 
            ESRI.ArcGIS.ADF.COMSupport.AOUninitialize.Shutdown();

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.axTOCControl1 = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.axEditorToolbar = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.panel_map_tree = new BSE.Windows.Forms.Panel();
            this.xPanderPanelList1 = new BSE.Windows.Forms.XPanderPanelList();
            this.xPanderPanel_tree = new BSE.Windows.Forms.XPanderPanel();
            this.xPanderPanel_query = new BSE.Windows.Forms.XPanderPanel();
            this.panel_container = new System.Windows.Forms.Panel();
            this.panel_left = new System.Windows.Forms.Panel();
            this.axMapControl1 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.panel_title_bar = new System.Windows.Forms.Panel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox_querytitle = new System.Windows.Forms.PictureBox();
            this.pictureBox_query = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox_tools1 = new System.Windows.Forms.PictureBox();
            this.close = new System.Windows.Forms.PictureBox();
            this.max = new System.Windows.Forms.PictureBox();
            this.min = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axEditorToolbar)).BeginInit();
            this.panel_map_tree.SuspendLayout();
            this.xPanderPanelList1.SuspendLayout();
            this.xPanderPanel_tree.SuspendLayout();
            this.panel_container.SuspendLayout();
            this.panel_left.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).BeginInit();
            this.panel_title_bar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_querytitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_query)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_tools1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.close)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.max)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.min)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // axTOCControl1
            // 
            this.axTOCControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axTOCControl1.Location = new System.Drawing.Point(0, 25);
            this.axTOCControl1.Name = "axTOCControl1";
            this.axTOCControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl1.OcxState")));
            this.axTOCControl1.Size = new System.Drawing.Size(198, 400);
            this.axTOCControl1.TabIndex = 12;
            this.axTOCControl1.OnMouseDown += new ESRI.ArcGIS.Controls.ITOCControlEvents_Ax_OnMouseDownEventHandler(this.axTOCControl1_OnMouseDown);
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(680, 206);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 5;
            // 
            // axEditorToolbar
            // 
            this.axEditorToolbar.Location = new System.Drawing.Point(209, 22);
            this.axEditorToolbar.Margin = new System.Windows.Forms.Padding(2);
            this.axEditorToolbar.Name = "axEditorToolbar";
            this.axEditorToolbar.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axEditorToolbar.OcxState")));
            this.axEditorToolbar.Size = new System.Drawing.Size(466, 28);
            this.axEditorToolbar.TabIndex = 12;
            // 
            // panel_map_tree
            // 
            this.panel_map_tree.BackColor = System.Drawing.Color.Transparent;
            this.panel_map_tree.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.panel_map_tree.CaptionFont = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Bold);
            this.panel_map_tree.CaptionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel_map_tree.CloseIconForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel_map_tree.CollapsedCaptionForeColor = System.Drawing.SystemColors.ControlText;
            this.panel_map_tree.ColorCaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.panel_map_tree.ColorCaptionGradientEnd = System.Drawing.SystemColors.ButtonShadow;
            this.panel_map_tree.ColorCaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.panel_map_tree.ColorContentPanelGradientBegin = System.Drawing.Color.Empty;
            this.panel_map_tree.ColorContentPanelGradientEnd = System.Drawing.Color.Empty;
            this.panel_map_tree.Controls.Add(this.xPanderPanelList1);
            this.panel_map_tree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_map_tree.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel_map_tree.Image = null;
            this.panel_map_tree.InnerBorderColor = System.Drawing.Color.White;
            this.panel_map_tree.Location = new System.Drawing.Point(0, 0);
            this.panel_map_tree.Name = "panel_map_tree";
            this.panel_map_tree.PanelStyle = BSE.Windows.Forms.PanelStyle.Office2007;
            this.panel_map_tree.Size = new System.Drawing.Size(200, 477);
            this.panel_map_tree.TabIndex = 10;
            this.panel_map_tree.Text = "功能菜单";
            // 
            // xPanderPanelList1
            // 
            this.xPanderPanelList1.CaptionStyle = BSE.Windows.Forms.CaptionStyle.Normal;
            this.xPanderPanelList1.Controls.Add(this.xPanderPanel_tree);
            this.xPanderPanelList1.Controls.Add(this.xPanderPanel_query);
            this.xPanderPanelList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xPanderPanelList1.GradientBackground = System.Drawing.Color.Empty;
            this.xPanderPanelList1.Location = new System.Drawing.Point(1, 26);
            this.xPanderPanelList1.Name = "xPanderPanelList1";
            this.xPanderPanelList1.PanelStyle = BSE.Windows.Forms.PanelStyle.Office2007;
            this.xPanderPanelList1.ShowExpandIcon = true;
            this.xPanderPanelList1.Size = new System.Drawing.Size(198, 450);
            this.xPanderPanelList1.TabIndex = 0;
            this.xPanderPanelList1.Text = "xPanderPanelList1";
            // 
            // xPanderPanel_tree
            // 
            this.xPanderPanel_tree.BackColor = System.Drawing.Color.Transparent;
            this.xPanderPanel_tree.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.xPanderPanel_tree.CaptionFont = new System.Drawing.Font("Microsoft YaHei", 8F, System.Drawing.FontStyle.Bold);
            this.xPanderPanel_tree.CaptionForeColor = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel_tree.CloseIconForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.xPanderPanel_tree.ColorCaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.xPanderPanel_tree.ColorCaptionGradientEnd = System.Drawing.SystemColors.ButtonShadow;
            this.xPanderPanel_tree.ColorCaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.xPanderPanel_tree.ColorFlatCaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.xPanderPanel_tree.ColorFlatCaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.xPanderPanel_tree.Controls.Add(this.axTOCControl1);
            this.xPanderPanel_tree.Expand = true;
            this.xPanderPanel_tree.ForeColor = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel_tree.Image = null;
            this.xPanderPanel_tree.InnerBorderColor = System.Drawing.Color.White;
            this.xPanderPanel_tree.Name = "xPanderPanel_tree";
            this.xPanderPanel_tree.PanelStyle = BSE.Windows.Forms.PanelStyle.Office2007;
            this.xPanderPanel_tree.Size = new System.Drawing.Size(198, 425);
            this.xPanderPanel_tree.TabIndex = 0;
            this.xPanderPanel_tree.Text = "图层管理";
            // 
            // xPanderPanel_query
            // 
            this.xPanderPanel_query.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.xPanderPanel_query.CaptionFont = new System.Drawing.Font("Microsoft YaHei", 8F, System.Drawing.FontStyle.Bold);
            this.xPanderPanel_query.CaptionForeColor = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel_query.CloseIconForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.xPanderPanel_query.ColorCaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.xPanderPanel_query.ColorCaptionGradientEnd = System.Drawing.SystemColors.ButtonShadow;
            this.xPanderPanel_query.ColorCaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.xPanderPanel_query.ColorFlatCaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.xPanderPanel_query.ColorFlatCaptionGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.xPanderPanel_query.ForeColor = System.Drawing.SystemColors.ControlText;
            this.xPanderPanel_query.Image = null;
            this.xPanderPanel_query.InnerBorderColor = System.Drawing.Color.White;
            this.xPanderPanel_query.Name = "xPanderPanel_query";
            this.xPanderPanel_query.PanelStyle = BSE.Windows.Forms.PanelStyle.Office2007;
            this.xPanderPanel_query.Size = new System.Drawing.Size(198, 25);
            this.xPanderPanel_query.TabIndex = 1;
            this.xPanderPanel_query.Text = "牧草查询";
            // 
            // panel_container
            // 
            this.panel_container.BackColor = System.Drawing.Color.Transparent;
            this.panel_container.Controls.Add(this.panel_left);
            this.panel_container.Controls.Add(this.axEditorToolbar);
            this.panel_container.Controls.Add(this.axMapControl1);
            this.panel_container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_container.Location = new System.Drawing.Point(0, 102);
            this.panel_container.Name = "panel_container";
            this.panel_container.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.panel_container.Size = new System.Drawing.Size(974, 480);
            this.panel_container.TabIndex = 0;
            this.panel_container.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_container_Paint);
            // 
            // panel_left
            // 
            this.panel_left.Controls.Add(this.panel_map_tree);
            this.panel_left.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_left.Location = new System.Drawing.Point(3, 0);
            this.panel_left.Name = "panel_left";
            this.panel_left.Size = new System.Drawing.Size(200, 477);
            this.panel_left.TabIndex = 0;
            // 
            // axMapControl1
            // 
            this.axMapControl1.Location = new System.Drawing.Point(209, 63);
            this.axMapControl1.Name = "axMapControl1";
            this.axMapControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl1.OcxState")));
            this.axMapControl1.Size = new System.Drawing.Size(728, 292);
            this.axMapControl1.TabIndex = 20;
            // 
            // panel_title_bar
            // 
            this.panel_title_bar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(164)))), ((int)(((byte)(228)))));
            this.panel_title_bar.BackgroundImage = global::ArcGISFoundation.Properties.Resources.banners;
            this.panel_title_bar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel_title_bar.Controls.Add(this.pictureBox5);
            this.panel_title_bar.Controls.Add(this.pictureBox4);
            this.panel_title_bar.Controls.Add(this.pictureBox_querytitle);
            this.panel_title_bar.Controls.Add(this.pictureBox_query);
            this.panel_title_bar.Controls.Add(this.pictureBox3);
            this.panel_title_bar.Controls.Add(this.pictureBox_tools1);
            this.panel_title_bar.Controls.Add(this.close);
            this.panel_title_bar.Controls.Add(this.max);
            this.panel_title_bar.Controls.Add(this.min);
            this.panel_title_bar.Controls.Add(this.pictureBox2);
            this.panel_title_bar.Controls.Add(this.pictureBox1);
            this.panel_title_bar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_title_bar.Location = new System.Drawing.Point(0, 0);
            this.panel_title_bar.Name = "panel_title_bar";
            this.panel_title_bar.Size = new System.Drawing.Size(974, 102);
            this.panel_title_bar.TabIndex = 1;
            this.panel_title_bar.DoubleClick += new System.EventHandler(this.panel_title_bar_DoubleClick);
            this.panel_title_bar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_title_bar_MouseDown);
            this.panel_title_bar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_title_bar_MouseMove);
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox5.Image = global::ArcGISFoundation.Properties.Resources.tools_help_title;
            this.pictureBox5.Location = new System.Drawing.Point(850, 35);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(47, 50);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox5.TabIndex = 10;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox4.Image = global::ArcGISFoundation.Properties.Resources.tools_help;
            this.pictureBox4.Location = new System.Drawing.Point(785, 27);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(60, 60);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 9;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox_querytitle
            // 
            this.pictureBox_querytitle.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_querytitle.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox_querytitle.Image = global::ArcGISFoundation.Properties.Resources.tools_query_title;
            this.pictureBox_querytitle.Location = new System.Drawing.Point(689, 35);
            this.pictureBox_querytitle.Name = "pictureBox_querytitle";
            this.pictureBox_querytitle.Size = new System.Drawing.Size(47, 50);
            this.pictureBox_querytitle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox_querytitle.TabIndex = 8;
            this.pictureBox_querytitle.TabStop = false;
            // 
            // pictureBox_query
            // 
            this.pictureBox_query.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_query.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_query.Image = global::ArcGISFoundation.Properties.Resources.tools_query;
            this.pictureBox_query.Location = new System.Drawing.Point(624, 27);
            this.pictureBox_query.Name = "pictureBox_query";
            this.pictureBox_query.Size = new System.Drawing.Size(60, 60);
            this.pictureBox_query.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_query.TabIndex = 7;
            this.pictureBox_query.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::ArcGISFoundation.Properties.Resources.tools_query_title;
            this.pictureBox3.Location = new System.Drawing.Point(523, 35);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(47, 50);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox_tools1
            // 
            this.pictureBox_tools1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_tools1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_tools1.Image = global::ArcGISFoundation.Properties.Resources.tools1;
            this.pictureBox_tools1.Location = new System.Drawing.Point(457, 27);
            this.pictureBox_tools1.Name = "pictureBox_tools1";
            this.pictureBox_tools1.Size = new System.Drawing.Size(60, 60);
            this.pictureBox_tools1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_tools1.TabIndex = 5;
            this.pictureBox_tools1.TabStop = false;
            // 
            // close
            // 
            this.close.BackColor = System.Drawing.Color.Transparent;
            this.close.Image = global::ArcGISFoundation.Properties.Resources.close;
            this.close.Location = new System.Drawing.Point(937, 0);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(27, 22);
            this.close.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.close.TabIndex = 4;
            this.close.TabStop = false;
            this.close.Click += new System.EventHandler(this.close_Click);
            this.close.MouseEnter += new System.EventHandler(this.close_MouseEnter);
            this.close.MouseLeave += new System.EventHandler(this.close_MouseLeave);
            // 
            // max
            // 
            this.max.BackColor = System.Drawing.Color.Transparent;
            this.max.Image = global::ArcGISFoundation.Properties.Resources.max;
            this.max.Location = new System.Drawing.Point(905, 0);
            this.max.Name = "max";
            this.max.Size = new System.Drawing.Size(27, 22);
            this.max.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.max.TabIndex = 3;
            this.max.TabStop = false;
            this.max.Click += new System.EventHandler(this.max_Click);
            this.max.MouseEnter += new System.EventHandler(this.max_MouseEnter);
            this.max.MouseLeave += new System.EventHandler(this.max_MouseLeave);
            // 
            // min
            // 
            this.min.BackColor = System.Drawing.Color.Transparent;
            this.min.Image = global::ArcGISFoundation.Properties.Resources.min;
            this.min.Location = new System.Drawing.Point(873, 0);
            this.min.Name = "min";
            this.min.Size = new System.Drawing.Size(27, 22);
            this.min.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.min.TabIndex = 2;
            this.min.TabStop = false;
            this.min.Click += new System.EventHandler(this.min_Click);
            this.min.MouseEnter += new System.EventHandler(this.min_MouseEnter);
            this.min.MouseLeave += new System.EventHandler(this.min_MouseLeave);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::ArcGISFoundation.Properties.Resources.logo_title;
            this.pictureBox2.Location = new System.Drawing.Point(76, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(287, 104);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(93, 102);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(974, 582);
            this.Controls.Add(this.panel_container);
            this.Controls.Add(this.panel_title_bar);
            this.Controls.Add(this.axLicenseControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Custom Editing Application";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axEditorToolbar)).EndInit();
            this.panel_map_tree.ResumeLayout(false);
            this.xPanderPanelList1.ResumeLayout(false);
            this.xPanderPanel_tree.ResumeLayout(false);
            this.panel_container.ResumeLayout(false);
            this.panel_left.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).EndInit();
            this.panel_title_bar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_querytitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_query)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_tools1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.close)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.max)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.min)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ESRI.ArcGIS.Controls.AxTOCControl axTOCControl1;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private ESRI.ArcGIS.Controls.AxToolbarControl axEditorToolbar;
        private BSE.Windows.Forms.Panel panel_map_tree;
        private BSE.Windows.Forms.XPanderPanelList xPanderPanelList1;
        private BSE.Windows.Forms.XPanderPanel xPanderPanel_tree;
        private BSE.Windows.Forms.XPanderPanel xPanderPanel_query;
        private System.Windows.Forms.Panel panel_title_bar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox min;
        private System.Windows.Forms.Panel panel_container;
        private System.Windows.Forms.PictureBox max;
        private System.Windows.Forms.PictureBox close;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl1;
        private System.Windows.Forms.Panel panel_left;
        private System.Windows.Forms.PictureBox pictureBox_tools1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox_query;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox_querytitle;
        private System.Windows.Forms.PictureBox pictureBox5;
    }
}

