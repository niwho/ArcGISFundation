namespace ArcGISFoundation
{
    partial class QueryInput
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QueryInput));
            this.panel_main = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupBox_xingzheng = new System.Windows.Forms.GroupBox();
            this.queryBtn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel_title_bar = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.close = new System.Windows.Forms.PictureBox();
            this.min = new System.Windows.Forms.PictureBox();
            this.panel_main.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox_xingzheng.SuspendLayout();
            this.panel_title_bar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.close)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.min)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_main
            // 
            this.panel_main.Controls.Add(this.groupBox1);
            this.panel_main.Controls.Add(this.groupBox_xingzheng);
            this.panel_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_main.Location = new System.Drawing.Point(0, 65);
            this.panel_main.Name = "panel_main";
            this.panel_main.Size = new System.Drawing.Size(375, 183);
            this.panel_main.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Location = new System.Drawing.Point(12, 89);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(351, 79);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "输入牧草名称查询";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(220)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Location = new System.Drawing.Point(287, 47);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(44, 22);
            this.button1.TabIndex = 22;
            this.button1.Text = "查询";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Location = new System.Drawing.Point(26, 20);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(305, 21);
            this.textBox2.TabIndex = 21;
            // 
            // groupBox_xingzheng
            // 
            this.groupBox_xingzheng.Controls.Add(this.queryBtn);
            this.groupBox_xingzheng.Controls.Add(this.textBox1);
            this.groupBox_xingzheng.Location = new System.Drawing.Point(12, 6);
            this.groupBox_xingzheng.Name = "groupBox_xingzheng";
            this.groupBox_xingzheng.Size = new System.Drawing.Size(351, 79);
            this.groupBox_xingzheng.TabIndex = 0;
            this.groupBox_xingzheng.TabStop = false;
            this.groupBox_xingzheng.Text = "输入行政名称查询";
            // 
            // queryBtn
            // 
            this.queryBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(155)))), ((int)(((byte)(220)))));
            this.queryBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.queryBtn.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.queryBtn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.queryBtn.Location = new System.Drawing.Point(287, 47);
            this.queryBtn.Name = "queryBtn";
            this.queryBtn.Size = new System.Drawing.Size(44, 22);
            this.queryBtn.TabIndex = 22;
            this.queryBtn.Text = "查询";
            this.queryBtn.UseVisualStyleBackColor = false;
            this.queryBtn.Click += new System.EventHandler(this.queryBtn_Click);
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(26, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(305, 21);
            this.textBox1.TabIndex = 21;
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
            this.panel_title_bar.Size = new System.Drawing.Size(375, 65);
            this.panel_title_bar.TabIndex = 2;
            this.panel_title_bar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_title_bar_MouseDown);
            this.panel_title_bar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_title_bar_MouseMove);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::ArcGISFoundation.Properties.Resources.query_param;
            this.pictureBox2.Location = new System.Drawing.Point(66, 17);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(143, 34);
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
            this.close.Location = new System.Drawing.Point(336, -1);
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
            this.min.Location = new System.Drawing.Point(302, -1);
            this.min.Name = "min";
            this.min.Size = new System.Drawing.Size(27, 22);
            this.min.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.min.TabIndex = 5;
            this.min.TabStop = false;
            this.min.Click += new System.EventHandler(this.min_Click);
            this.min.MouseEnter += new System.EventHandler(this.min_MouseEnter);
            this.min.MouseLeave += new System.EventHandler(this.min_MouseLeave);
            // 
            // QueryInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 248);
            this.Controls.Add(this.panel_main);
            this.Controls.Add(this.panel_title_bar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "QueryInput";
            this.Text = "QueryInput";
            this.panel_main.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox_xingzheng.ResumeLayout(false);
            this.groupBox_xingzheng.PerformLayout();
            this.panel_title_bar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.close)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.min)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_title_bar;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox close;
        private System.Windows.Forms.PictureBox min;
        private System.Windows.Forms.Panel panel_main;
        private System.Windows.Forms.GroupBox groupBox_xingzheng;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button queryBtn;
        private System.Windows.Forms.TextBox textBox1;

    }
}