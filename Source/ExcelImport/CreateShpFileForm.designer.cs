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
            this.xComboBoxEx = new System.Windows.Forms.ComboBox();
            this.yComboBoxEx = new System.Windows.Forms.ComboBox();
            this.fieldListBox = new System.Windows.Forms.ListBox();
            this.addFieldListBox = new System.Windows.Forms.ListBox();
            this.addFieldButtonX = new System.Windows.Forms.Button();
            this.delFieldButtonX = new System.Windows.Forms.Button();
            this.Create = new System.Windows.Forms.Button();
            this.OpenExcel = new System.Windows.Forms.Button();
            this.shpTypeComboBox = new System.Windows.Forms.ComboBox();
            this.fileNameTextBox = new System.Windows.Forms.TextBox();
            this.saveFileButton = new System.Windows.Forms.Button();
            this.filePathTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // xComboBoxEx
            // 
            this.xComboBoxEx.FormattingEnabled = true;
            this.xComboBoxEx.Location = new System.Drawing.Point(31, 128);
            this.xComboBoxEx.Name = "xComboBoxEx";
            this.xComboBoxEx.Size = new System.Drawing.Size(157, 20);
            this.xComboBoxEx.TabIndex = 0;
            // 
            // yComboBoxEx
            // 
            this.yComboBoxEx.FormattingEnabled = true;
            this.yComboBoxEx.Location = new System.Drawing.Point(260, 131);
            this.yComboBoxEx.Name = "yComboBoxEx";
            this.yComboBoxEx.Size = new System.Drawing.Size(157, 20);
            this.yComboBoxEx.TabIndex = 1;
            // 
            // fieldListBox
            // 
            this.fieldListBox.FormattingEnabled = true;
            this.fieldListBox.ItemHeight = 12;
            this.fieldListBox.Location = new System.Drawing.Point(31, 172);
            this.fieldListBox.Name = "fieldListBox";
            this.fieldListBox.Size = new System.Drawing.Size(157, 208);
            this.fieldListBox.TabIndex = 2;
            // 
            // addFieldListBox
            // 
            this.addFieldListBox.FormattingEnabled = true;
            this.addFieldListBox.ItemHeight = 12;
            this.addFieldListBox.Location = new System.Drawing.Point(260, 172);
            this.addFieldListBox.Name = "addFieldListBox";
            this.addFieldListBox.Size = new System.Drawing.Size(157, 208);
            this.addFieldListBox.TabIndex = 3;
            // 
            // addFieldButtonX
            // 
            this.addFieldButtonX.Location = new System.Drawing.Point(200, 216);
            this.addFieldButtonX.Name = "addFieldButtonX";
            this.addFieldButtonX.Size = new System.Drawing.Size(51, 23);
            this.addFieldButtonX.TabIndex = 4;
            this.addFieldButtonX.Text = "添加";
            this.addFieldButtonX.UseVisualStyleBackColor = true;
            this.addFieldButtonX.Click += new System.EventHandler(this.addFieldButtonX_Click);
            // 
            // delFieldButtonX
            // 
            this.delFieldButtonX.Location = new System.Drawing.Point(200, 263);
            this.delFieldButtonX.Name = "delFieldButtonX";
            this.delFieldButtonX.Size = new System.Drawing.Size(51, 23);
            this.delFieldButtonX.TabIndex = 5;
            this.delFieldButtonX.Text = "移除";
            this.delFieldButtonX.UseVisualStyleBackColor = true;
            this.delFieldButtonX.Click += new System.EventHandler(this.delFieldButtonX_Click);
            // 
            // Create
            // 
            this.Create.Location = new System.Drawing.Point(233, 401);
            this.Create.Name = "Create";
            this.Create.Size = new System.Drawing.Size(75, 23);
            this.Create.TabIndex = 6;
            this.Create.Text = "创建";
            this.Create.UseVisualStyleBackColor = true;
            this.Create.Click += new System.EventHandler(this.Create_Click);
            // 
            // OpenExcel
            // 
            this.OpenExcel.Location = new System.Drawing.Point(341, 401);
            this.OpenExcel.Name = "OpenExcel";
            this.OpenExcel.Size = new System.Drawing.Size(75, 23);
            this.OpenExcel.TabIndex = 7;
            this.OpenExcel.Text = "取消";
            this.OpenExcel.UseVisualStyleBackColor = true;
            this.OpenExcel.Click += new System.EventHandler(this.OpenExcel_Click);
            // 
            // shpTypeComboBox
            // 
            this.shpTypeComboBox.FormattingEnabled = true;
            this.shpTypeComboBox.Items.AddRange(new object[] {
            "Point",
            "Polyline",
            "polygon"});
            this.shpTypeComboBox.Location = new System.Drawing.Point(12, 92);
            this.shpTypeComboBox.Name = "shpTypeComboBox";
            this.shpTypeComboBox.Size = new System.Drawing.Size(405, 20);
            this.shpTypeComboBox.TabIndex = 11;
            // 
            // fileNameTextBox
            // 
            this.fileNameTextBox.Location = new System.Drawing.Point(12, 60);
            this.fileNameTextBox.Name = "fileNameTextBox";
            this.fileNameTextBox.Size = new System.Drawing.Size(405, 21);
            this.fileNameTextBox.TabIndex = 10;
            this.fileNameTextBox.TextChanged += new System.EventHandler(this.fileNameTextBox_TextChanged);
            // 
            // saveFileButton
            // 
            this.saveFileButton.Location = new System.Drawing.Point(367, 21);
            this.saveFileButton.Name = "saveFileButton";
            this.saveFileButton.Size = new System.Drawing.Size(50, 23);
            this.saveFileButton.TabIndex = 9;
            this.saveFileButton.Text = "保存";
            this.saveFileButton.UseVisualStyleBackColor = true;
            this.saveFileButton.Click += new System.EventHandler(this.saveFileButton_Click);
            // 
            // filePathTextBox
            // 
            this.filePathTextBox.Location = new System.Drawing.Point(12, 23);
            this.filePathTextBox.Name = "filePathTextBox";
            this.filePathTextBox.Size = new System.Drawing.Size(349, 21);
            this.filePathTextBox.TabIndex = 8;
            this.filePathTextBox.TextChanged += new System.EventHandler(this.filePathTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "X：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(231, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "Y：";
            // 
            // CreateShpFileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 441);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.shpTypeComboBox);
            this.Controls.Add(this.fileNameTextBox);
            this.Controls.Add(this.saveFileButton);
            this.Controls.Add(this.filePathTextBox);
            this.Controls.Add(this.OpenExcel);
            this.Controls.Add(this.Create);
            this.Controls.Add(this.delFieldButtonX);
            this.Controls.Add(this.addFieldButtonX);
            this.Controls.Add(this.addFieldListBox);
            this.Controls.Add(this.fieldListBox);
            this.Controls.Add(this.yComboBoxEx);
            this.Controls.Add(this.xComboBoxEx);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "CreateShpFileForm";
            this.Text = "创建Shape文件";
            this.Load += new System.EventHandler(this.CreateShpFileForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox xComboBoxEx;
        private System.Windows.Forms.ComboBox yComboBoxEx;
        private System.Windows.Forms.ListBox fieldListBox;
        private System.Windows.Forms.ListBox addFieldListBox;
        private System.Windows.Forms.Button addFieldButtonX;
        private System.Windows.Forms.Button delFieldButtonX;
        private System.Windows.Forms.Button Create;
        private System.Windows.Forms.Button OpenExcel;
        private System.Windows.Forms.ComboBox shpTypeComboBox;
        private System.Windows.Forms.TextBox fileNameTextBox;
        private System.Windows.Forms.Button saveFileButton;
        private System.Windows.Forms.TextBox filePathTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}