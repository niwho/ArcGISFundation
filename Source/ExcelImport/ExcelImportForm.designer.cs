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
            ((System.ComponentModel.ISupportInitialize)(this.excelGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).BeginInit();
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
            this.OpenExcel.Location = new System.Drawing.Point(12, 12);
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
            this.excelCmbBox.Location = new System.Drawing.Point(150, 15);
            this.excelCmbBox.Name = "excelCmbBox";
            this.excelCmbBox.Size = new System.Drawing.Size(244, 20);
            this.excelCmbBox.TabIndex = 1;
            // 
            // Open
            // 
            this.Open.Location = new System.Drawing.Point(408, 13);
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
            this.excelGridView.Location = new System.Drawing.Point(4, 41);
            this.excelGridView.Name = "excelGridView";
            this.excelGridView.RowTemplate.Height = 23;
            this.excelGridView.Size = new System.Drawing.Size(479, 273);
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
            this.CreateShpFile.Location = new System.Drawing.Point(395, 333);
            this.CreateShpFile.Name = "CreateShpFile";
            this.CreateShpFile.Size = new System.Drawing.Size(88, 23);
            this.CreateShpFile.TabIndex = 6;
            this.CreateShpFile.Text = "创建Shape文件";
            this.CreateShpFile.UseVisualStyleBackColor = true;
            this.CreateShpFile.Click += new System.EventHandler(this.CreateShpFile_Click);
            // 
            // axMapControl1
            // 
            this.axMapControl1.Location = new System.Drawing.Point(504, 12);
            this.axMapControl1.Name = "axMapControl1";
            this.axMapControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl1.OcxState")));
            this.axMapControl1.Size = new System.Drawing.Size(482, 302);
            this.axMapControl1.TabIndex = 4;
            // 
            // ExcelImportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 368);
            this.Controls.Add(this.CreateShpFile);
            this.Controls.Add(this.axLicenseControl1);
            this.Controls.Add(this.axMapControl1);
            this.Controls.Add(this.excelGridView);
            this.Controls.Add(this.Open);
            this.Controls.Add(this.excelCmbBox);
            this.Controls.Add(this.OpenExcel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ExcelImportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "导入Excel";
            this.Load += new System.EventHandler(this.ExcelImportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.excelGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).EndInit();
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
    }
}