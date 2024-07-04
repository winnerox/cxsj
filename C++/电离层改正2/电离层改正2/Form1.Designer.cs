namespace 电离层改正2
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
            this.calculate = new System.Windows.Forms.Button();
            this.report = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // file_open
            // 
            this.file_open.Location = new System.Drawing.Point(24, 28);
            this.file_open.Name = "file_open";
            this.file_open.Size = new System.Drawing.Size(106, 48);
            this.file_open.TabIndex = 0;
            this.file_open.Text = "文件打开";
            this.file_open.UseVisualStyleBackColor = true;
            this.file_open.Click += new System.EventHandler(this.File_Open_click);
            // 
            // calculate
            // 
            this.calculate.Location = new System.Drawing.Point(183, 28);
            this.calculate.Name = "calculate";
            this.calculate.Size = new System.Drawing.Size(106, 48);
            this.calculate.TabIndex = 1;
            this.calculate.Text = "计算";
            this.calculate.UseVisualStyleBackColor = true;
            this.calculate.Click += new System.EventHandler(this.calculate_click);
            // 
            // report
            // 
            this.report.Location = new System.Drawing.Point(346, 28);
            this.report.Name = "report";
            this.report.Size = new System.Drawing.Size(106, 48);
            this.report.TabIndex = 2;
            this.report.Text = "报告输出";
            this.report.UseVisualStyleBackColor = true;
            this.report.Click += new System.EventHandler(this.report_click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 161);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1037, 427);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 644);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.report);
            this.Controls.Add(this.calculate);
            this.Controls.Add(this.file_open);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button file_open;
        private System.Windows.Forms.Button calculate;
        private System.Windows.Forms.Button report;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

