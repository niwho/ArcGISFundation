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
            this.openExcelDialog = new System.Windows.Forms.OpenFileDialog();
            this.panel_title_bar = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.close = new System.Windows.Forms.PictureBox();
            this.min = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CreateShpFile = new System.Windows.Forms.Button();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.axMapControl1 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.excelGridView = new System.Windows.Forms.DataGridView();
            this.Open = new System.Windows.Forms.Button();
            this.excelCmbBox = new System.Windows.Forms.ComboBox();
            this.OpenExcel = new System.Windows.Forms.Button();
            this.panel_title_bar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.close)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.min)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.excelGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "ExcelToLayer";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.CreateShpFile);
            this.panel1.Controls.Add(this.axLicenseControl1);
            this.panel1.Controls.Add(this.axMapControl1);
            this.panel1.Controls.Add(this.excelGridView);
            this.panel1.Controls.Add(this.Open);
            this.panel1.Controls.Add(this.excelCmbBox);
            this.panel1.Controls.Add(this.OpenExcel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 65);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3);
            this.panel1.Size = new System.Drawing.Size(998, 379);
            this.panel1.TabIndex = 8;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // CreateShpFile
            // 
            this.CreateShpFile.BackgroundImage = global::ArcGISFoundation.Properties.Resources.banner;
            this.CreateShpFile.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CreateShpFile.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.CreateShpFile.Location = new System.Drawing.Point(362, 336);
            this.CreateShpFile.Name = "CreateShpFile";
            this.CreateShpFile.Size = new System.Drawing.Size(125, 32);
            this.CreateShpFile.TabIndex = 13;
            this.CreateShpFile.Text = "创建Shape文件";
            this.CreateShpFile.UseVisualStyleBackColor = true;
            this.CreateShpFile.Click += new System.EventHandler(this.CreateShpFile_Click);
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(653, 146);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 12;
            // 
            // axMapControl1
            // 
            this.axMapControl1.Location = new System.Drawing.Point(508, 18);
            this.axMapControl1.Name = "axMapControl1";
            this.axMapControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl1.OcxState")));
            this.axMapControl1.Size = new System.Drawing.Size(482, 312);
            this.axMapControl1.TabIndex = 11;
            // 
            // excelGridView
            // 
            this.excelGridView.AllowUserToAddRows = false;
            this.excelGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.excelGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.excelGridView.Location = new System.Drawing.Point(8, 47);
            this.excelGridView.Name = "excelGridView";
            this.excelGridView.RowTemplate.Height = 23;
            this.excelGridView.Size = new System.Drawing.Size(479, 283);
            this.excelGridView.TabIndex = 10;
            // 
            // Open
            // 
            this.Open.BackgroundImage = global::ArcGISFoundation.Properties.Resources.banner;
            this.Open.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Open.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Open.Location = new System.Drawing.Point(396, 10);
            this.Open.Margin = new System.Windows.Forms.Padding(0);
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(62, 30);
            this.Open.TabIndex = 9;
            this.Open.Text = "打开";
            this.Open.UseVisualStyleBackColor = true;
            this.Open.Click += new System.EventHandler(this.Open_Click);
            // 
            // excelCmbBox
            // 
            this.excelCmbBox.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.excelCmbBox.FormattingEnabled = true;
            this.excelCmbBox.Location = new System.Drawing.Point(136, 13);
            this.excelCmbBox.Name = "excelCmbBox";
            this.excelCmbBox.Size = new System.Drawing.Size(244, 25);
            this.excelCmbBox.TabIndex = 8;
            // 
            // OpenExcel
            // 
            this.OpenExcel.BackgroundImage = global::ArcGISFoundation.Properties.Resources.banner;
            this.OpenExcel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.OpenExcel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.OpenExcel.Location = new System.Drawing.Point(11, 10);
            this.OpenExcel.Name = "OpenExcel";
            this.OpenExcel.Size = new System.Drawing.Size(115, 29);
            this.OpenExcel.TabIndex = 7;
            this.OpenExcel.Text = "打开Excel";
            this.OpenExcel.UseVisualStyleBackColor = true;
            this.OpenExcel.Click += new System.EventHandler(this.OpenExcel_Click);
            // 
            // ExcelImportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(998, 444);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel_title_bar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ExcelImportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "导入Excel";
            this.Load += new System.EventHandler(this.ExcelImportForm_Load);
            this.panel_title_bar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.close)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.min)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.excelGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.OpenFileDialog openExcelDialog;
        private System.Windows.Forms.Panel panel_title_bar;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox close;
        private System.Windows.Forms.PictureBox min;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button CreateShpFile;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl1;
        private System.Windows.Forms.DataGridView excelGridView;
        private System.Windows.Forms.Button Open;
        private System.Windows.Forms.ComboBox excelCmbBox;
        private System.Windows.Forms.Button OpenExcel;
    }
}