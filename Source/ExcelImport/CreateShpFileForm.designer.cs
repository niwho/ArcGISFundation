namespace ArcGISFoundation
{
    partial class CreateShpFileForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateShpFileForm));
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.shpTypeComboBox = new System.Windows.Forms.ComboBox();
            this.fileNameTextBox = new System.Windows.Forms.TextBox();
            this.filePathTextBox = new System.Windows.Forms.TextBox();
            this.addFieldListBox = new System.Windows.Forms.ListBox();
            this.fieldListBox = new System.Windows.Forms.ListBox();
            this.yComboBoxEx = new System.Windows.Forms.ComboBox();
            this.xComboBoxEx = new System.Windows.Forms.ComboBox();
            this.saveFileButton = new System.Windows.Forms.Button();
            this.OpenExcel = new System.Windows.Forms.Button();
            this.Create = new System.Windows.Forms.Button();
            this.delFieldButtonX = new System.Windows.Forms.Button();
            this.addFieldButtonX = new System.Windows.Forms.Button();
            this.panel_title_bar = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.close = new System.Windows.Forms.PictureBox();
            this.min = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel_title_bar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.close)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.min)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.shpTypeComboBox);
            this.panel1.Controls.Add(this.fileNameTextBox);
            this.panel1.Controls.Add(this.saveFileButton);
            this.panel1.Controls.Add(this.filePathTextBox);
            this.panel1.Controls.Add(this.OpenExcel);
            this.panel1.Controls.Add(this.Create);
            this.panel1.Controls.Add(this.delFieldButtonX);
            this.panel1.Controls.Add(this.addFieldButtonX);
            this.panel1.Controls.Add(this.addFieldListBox);
            this.panel1.Controls.Add(this.fieldListBox);
            this.panel1.Controls.Add(this.yComboBoxEx);
            this.panel1.Controls.Add(this.xComboBoxEx);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 65);
            this.panel1.Margin = new System.Windows.Forms.Padding(7);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.panel1.Size = new System.Drawing.Size(434, 465);
            this.panel1.TabIndex = 16;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 29;
            this.label3.Text = "属性：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(234, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 12);
            this.label2.TabIndex = 28;
            this.label2.Text = "Y：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 12);
            this.label1.TabIndex = 27;
            this.label1.Text = "X：";
            // 
            // shpTypeComboBox
            // 
            this.shpTypeComboBox.FormattingEnabled = true;
            this.shpTypeComboBox.Items.AddRange(new object[] {
            "Point",
            "Polyline",
            "polygon"});
            this.shpTypeComboBox.Location = new System.Drawing.Point(15, 80);
            this.shpTypeComboBox.Name = "shpTypeComboBox";
            this.shpTypeComboBox.Size = new System.Drawing.Size(405, 20);
            this.shpTypeComboBox.TabIndex = 26;
            // 
            // fileNameTextBox
            // 
            this.fileNameTextBox.Enabled = false;
            this.fileNameTextBox.Location = new System.Drawing.Point(15, 48);
            this.fileNameTextBox.Name = "fileNameTextBox";
            this.fileNameTextBox.Size = new System.Drawing.Size(405, 21);
            this.fileNameTextBox.TabIndex = 25;
            this.fileNameTextBox.TextChanged += new System.EventHandler(this.fileNameTextBox_TextChanged);
            // 
            // filePathTextBox
            // 
            this.filePathTextBox.Enabled = false;
            this.filePathTextBox.Location = new System.Drawing.Point(15, 11);
            this.filePathTextBox.Name = "filePathTextBox";
            this.filePathTextBox.Size = new System.Drawing.Size(349, 21);
            this.filePathTextBox.TabIndex = 23;
            this.filePathTextBox.TextChanged += new System.EventHandler(this.filePathTextBox_TextChanged);
            // 
            // addFieldListBox
            // 
            this.addFieldListBox.FormattingEnabled = true;
            this.addFieldListBox.ItemHeight = 12;
            this.addFieldListBox.Location = new System.Drawing.Point(263, 194);
            this.addFieldListBox.Name = "addFieldListBox";
            this.addFieldListBox.Size = new System.Drawing.Size(157, 208);
            this.addFieldListBox.TabIndex = 18;
            // 
            // fieldListBox
            // 
            this.fieldListBox.FormattingEnabled = true;
            this.fieldListBox.ItemHeight = 12;
            this.fieldListBox.Location = new System.Drawing.Point(34, 193);
            this.fieldListBox.Name = "fieldListBox";
            this.fieldListBox.Size = new System.Drawing.Size(157, 208);
            this.fieldListBox.TabIndex = 17;
            // 
            // yComboBoxEx
            // 
            this.yComboBoxEx.FormattingEnabled = true;
            this.yComboBoxEx.Location = new System.Drawing.Point(265, 116);
            this.yComboBoxEx.Name = "yComboBoxEx";
            this.yComboBoxEx.Size = new System.Drawing.Size(154, 20);
            this.yComboBoxEx.TabIndex = 16;
            // 
            // xComboBoxEx
            // 
            this.xComboBoxEx.FormattingEnabled = true;
            this.xComboBoxEx.Location = new System.Drawing.Point(38, 116);
            this.xComboBoxEx.Name = "xComboBoxEx";
            this.xComboBoxEx.Size = new System.Drawing.Size(153, 20);
            this.xComboBoxEx.TabIndex = 15;
            // 
            // saveFileButton
            // 
            this.saveFileButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.saveFileButton.BackgroundImage = global::ArcGISFoundation.Properties.Resources.banner;
            this.saveFileButton.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.saveFileButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.saveFileButton.Location = new System.Drawing.Point(370, 9);
            this.saveFileButton.Name = "saveFileButton";
            this.saveFileButton.Size = new System.Drawing.Size(50, 23);
            this.saveFileButton.TabIndex = 24;
            this.saveFileButton.Text = "保存";
            this.saveFileButton.UseVisualStyleBackColor = false;
            this.saveFileButton.Click += new System.EventHandler(this.saveFileButton_Click);
            // 
            // OpenExcel
            // 
            this.OpenExcel.BackgroundImage = global::ArcGISFoundation.Properties.Resources.banner;
            this.OpenExcel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.OpenExcel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.OpenExcel.Location = new System.Drawing.Point(344, 430);
            this.OpenExcel.Name = "OpenExcel";
            this.OpenExcel.Size = new System.Drawing.Size(75, 25);
            this.OpenExcel.TabIndex = 22;
            this.OpenExcel.Text = "取消";
            this.OpenExcel.UseVisualStyleBackColor = true;
            this.OpenExcel.Click += new System.EventHandler(this.OpenExcel_Click);
            // 
            // Create
            // 
            this.Create.BackgroundImage = global::ArcGISFoundation.Properties.Resources.banner;
            this.Create.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Create.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Create.Location = new System.Drawing.Point(236, 430);
            this.Create.Name = "Create";
            this.Create.Size = new System.Drawing.Size(75, 25);
            this.Create.TabIndex = 21;
            this.Create.Text = "创建";
            this.Create.UseVisualStyleBackColor = true;
            this.Create.Click += new System.EventHandler(this.Create_Click);
            // 
            // delFieldButtonX
            // 
            this.delFieldButtonX.BackgroundImage = global::ArcGISFoundation.Properties.Resources.banner;
            this.delFieldButtonX.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.delFieldButtonX.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.delFieldButtonX.Location = new System.Drawing.Point(203, 304);
            this.delFieldButtonX.Name = "delFieldButtonX";
            this.delFieldButtonX.Size = new System.Drawing.Size(51, 28);
            this.delFieldButtonX.TabIndex = 20;
            this.delFieldButtonX.Text = "移除";
            this.delFieldButtonX.UseVisualStyleBackColor = true;
            this.delFieldButtonX.Click += new System.EventHandler(this.delFieldButtonX_Click);
            // 
            // addFieldButtonX
            // 
            this.addFieldButtonX.BackgroundImage = global::ArcGISFoundation.Properties.Resources.banner;
            this.addFieldButtonX.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.addFieldButtonX.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.addFieldButtonX.Location = new System.Drawing.Point(203, 240);
            this.addFieldButtonX.Name = "addFieldButtonX";
            this.addFieldButtonX.Size = new System.Drawing.Size(51, 27);
            this.addFieldButtonX.TabIndex = 19;
            this.addFieldButtonX.Text = "添加";
            this.addFieldButtonX.UseVisualStyleBackColor = true;
            this.addFieldButtonX.Click += new System.EventHandler(this.addFieldButtonX_Click);
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
            this.panel_title_bar.Size = new System.Drawing.Size(434, 65);
            this.panel_title_bar.TabIndex = 15;
            this.panel_title_bar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_title_bar_MouseDown);
            this.panel_title_bar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_title_bar_MouseMove);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::ArcGISFoundation.Properties.Resources.create_shape_title;
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
            this.close.Location = new System.Drawing.Point(395, -1);
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
            this.min.Location = new System.Drawing.Point(361, -1);
            this.min.Name = "min";
            this.min.Size = new System.Drawing.Size(27, 22);
            this.min.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.min.TabIndex = 5;
            this.min.TabStop = false;
            this.min.Click += new System.EventHandler(this.min_Click);
            this.min.MouseEnter += new System.EventHandler(this.min_MouseEnter);
            this.min.MouseLeave += new System.EventHandler(this.min_MouseLeave);
            // 
            // CreateShpFileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(434, 530);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel_title_bar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CreateShpFileForm";
            this.Text = "创建Shape文件";
            this.Load += new System.EventHandler(this.CreateShpFileForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel_title_bar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.close)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.min)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox close;
        private System.Windows.Forms.PictureBox min;
        private System.Windows.Forms.Panel panel_title_bar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox shpTypeComboBox;
        private System.Windows.Forms.TextBox fileNameTextBox;
        private System.Windows.Forms.Button saveFileButton;
        private System.Windows.Forms.TextBox filePathTextBox;
        private System.Windows.Forms.Button OpenExcel;
        private System.Windows.Forms.Button Create;
        private System.Windows.Forms.Button delFieldButtonX;
        private System.Windows.Forms.Button addFieldButtonX;
        private System.Windows.Forms.ListBox addFieldListBox;
        private System.Windows.Forms.ListBox fieldListBox;
        private System.Windows.Forms.ComboBox yComboBoxEx;
        private System.Windows.Forms.ComboBox xComboBoxEx;
    }
}