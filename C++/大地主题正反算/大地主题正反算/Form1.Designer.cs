namespace 大地主题正反算
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.file_open = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.calculate1 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.report = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // file_open
            // 
            this.file_open.Location = new System.Drawing.Point(21, 12);
            this.file_open.Name = "file_open";
            this.file_open.Size = new System.Drawing.Size(121, 34);
            this.file_open.TabIndex = 0;
            this.file_open.Text = "文件打开";
            this.file_open.UseVisualStyleBackColor = true;
            this.file_open.Click += new System.EventHandler(this.File_Open_click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "克拉索夫斯基",
            "IUGG1975",
            "CGCS2000"});
            this.comboBox1.Location = new System.Drawing.Point(174, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(145, 26);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.Text = "椭球体选择";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.option_change_Click);
            // 
            // calculate1
            // 
            this.calculate1.Location = new System.Drawing.Point(344, 12);
            this.calculate1.Name = "calculate1";
            this.calculate1.Size = new System.Drawing.Size(121, 34);
            this.calculate1.TabIndex = 2;
            this.calculate1.Text = "计算";
            this.calculate1.UseVisualStyleBackColor = true;
            this.calculate1.Click += new System.EventHandler(this.calculate_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(21, 149);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(814, 228);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            // 
            // report
            // 
            this.report.Location = new System.Drawing.Point(517, 12);
            this.report.Name = "report";
            this.report.Size = new System.Drawing.Size(121, 34);
            this.report.TabIndex = 5;
            this.report.Text = "报告输出";
            this.report.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 590);
            this.Controls.Add(this.report);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.calculate1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.file_open);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button file_open;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button calculate1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button report;
    }
}

