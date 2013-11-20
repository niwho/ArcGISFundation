namespace ArcGISFoundation
{
    partial class ExcelImportForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExcelImportForm));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.OpenExcel = new System.Windows.Forms.Button();
            this.openExcelDialog = new System.Windows.Forms.OpenFileDialog();
            this.excelCmbBox = new System.Windows.Forms.ComboBox();
            this.Open = new System.Windows.Forms.Button();
            this.excelGridView = new System.Windows.Forms.DataGridView();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.CreateShpFile = new System.Windows.Forms.Button();
            this.axMapControl1 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.panel_title_bar = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.close = new System.Windows.Forms.PictureBox();
            this.min = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.excelGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).BeginInit();
            this.panel_title_bar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.close)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.min)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "ExcelToLayer";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // OpenExcel
            // 
            this.OpenExcel.Location = new System.Drawing.Point(7, 80);
            this.OpenExcel.Name = "OpenExcel";
            this.OpenExcel.Size = new System.Drawing.Size(115, 23);
            this.OpenExcel.TabIndex = 0;
            this.OpenExcel.Text = "打开Excel";
            this.OpenExcel.UseVisualStyleBackColor = true;
            this.OpenExcel.Click += new System.EventHandler(this.OpenExcel_Click);
            // 
            // excelCmbBox
            // 
            this.excelCmbBox.FormattingEnabled = true;
            this.excelCmbBox.Location = new System.Drawing.Point(132, 82);
            this.excelCmbBox.Name = "excelCmbBox";
            this.excelCmbBox.Size = new System.Drawing.Size(244, 20);
            this.excelCmbBox.TabIndex = 1;
            // 
            // Open
            // 
            this.Open.Location = new System.Drawing.Point(408, 82);
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(75, 23);
            this.Open.TabIndex = 2;
            this.Open.Text = "打开";
            this.Open.UseVisualStyleBackColor = true;
            this.Open.Click += new System.EventHandler(this.Open_Click);
            // 
            // excelGridView
            // 
            this.excelGridView.AllowUserToAddRows = false;
            this.excelGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.excelGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.excelGridView.Location = new System.Drawing.Point(4, 111);
            this.excelGridView.Name = "excelGridView";
            this.excelGridView.RowTemplate.Height = 23;
            this.excelGridView.Size = new System.Drawing.Size(479, 283);
            this.excelGridView.TabIndex = 3;
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(649, 210);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 5;
            // 
            // CreateShpFile
            // 
            this.CreateShpFile.Location = new System.Drawing.Point(395, 400);
            this.CreateShpFile.Name = "CreateShpFile";
            this.CreateShpFile.Size = new System.Drawing.Size(88, 23);
            this.CreateShpFile.TabIndex = 6;
            this.CreateShpFile.Text = "创建Shape文件";
            this.CreateShpFile.UseVisualStyleBackColor = true;
            this.CreateShpFile.Click += new System.EventHandler(this.CreateShpFile_Click);
            // 
            // axMapControl1
            // 
            this.axMapControl1.Location = new System.Drawing.Point(504, 82);
            this.axMapControl1.Name = "axMapControl1";
            this.axMapControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl1.OcxState")));
            this.axMapControl1.Size = new System.Drawing.Size(482, 312);
            this.axMapControl1.TabIndex = 4;
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
            this.panel_title_bar.Size = new System.Drawing.Size(998, 65);
            this.panel_title_bar.TabIndex = 7;
            this.panel_title_bar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_title_bar_MouseDown);
            this.panel_title_bar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_title_bar_MouseMove);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::ArcGISFoundation.Properties.Resources.import_logo_title;
            this.pictureBox2.Location = new System.Drawing.Point(66, 14);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(142, 39);
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
            this.close.Location = new System.Drawing.Point(959, -1);
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
            this.min.Location = new System.Drawing.Point(925, -1);
            this.min.Name = "min";
            this.min.Size = new System.Drawing.Size(27, 22);
            this.min.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.min.TabIndex = 5;
            this.min.TabStop = false;
            this.min.Click += new System.EventHandler(this.min_Click);
            this.min.MouseEnter += new System.EventHandler(this.min_MouseEnter);
            this.min.MouseLeave += new System.EventHandler(this.min_MouseLeave);
            // 
            // ExcelImportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 435);
            this.Controls.Add(this.panel_title_bar);
            this.Controls.Add(this.CreateShpFile);
            this.Controls.Add(this.axLicenseControl1);
            this.Controls.Add(this.axMapControl1);
            this.Controls.Add(this.excelGridView);
            this.Controls.Add(this.Open);
            this.Controls.Add(this.excelCmbBox);
            this.Controls.Add(this.OpenExcel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ExcelImportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "导入Excel";
            this.Load += new System.EventHandler(this.ExcelImportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.excelGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).EndInit();
            this.panel_title_bar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.close)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.min)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button OpenExcel;
        private System.Windows.Forms.OpenFileDialog openExcelDialog;
        private System.Windows.Forms.ComboBox excelCmbBox;
        private System.Windows.Forms.Button Open;
        private System.Windows.Forms.DataGridView excelGridView;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl1;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private System.Windows.Forms.Button CreateShpFile;
        private System.Windows.Forms.Panel panel_title_bar;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox close;
        private System.Windows.Forms.PictureBox min;
    }
}