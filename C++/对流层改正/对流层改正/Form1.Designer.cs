namespace 对流层改正计算
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
            this.file_open.Location = new System.Drawing.Point(12, 25);
            this.file_open.Name = "file_open";
            this.file_open.Size = new System.Drawing.Size(78, 29);
            this.file_open.TabIndex = 0;
            this.file_open.Text = "文件读取";
            this.file_open.UseVisualStyleBackColor = true;
            this.file_open.Click += new System.EventHandler(this.file_open_Click);
            // 
            // calculate
            // 
            this.calculate.Location = new System.Drawing.Point(216, 25);
            this.calculate.Name = "calculate";
            this.calculate.Size = new System.Drawing.Size(78, 29);
            this.calculate.TabIndex = 1;
            this.calculate.Text = "计算";
            this.calculate.UseVisualStyleBackColor = true;
            this.calculate.Click += new System.EventHandler(this.calculate_click);
            // 
            // report
            // 
            this.report.Location = new System.Drawing.Point(447, 25);
            this.report.Name = "report";
            this.report.Size = new System.Drawing.Size(78, 29);
            this.report.TabIndex = 2;
            this.report.Text = "生成报告";
            this.report.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 60);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(513, 237);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 316);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.report);
            this.Controls.Add(this.calculate);
            this.Controls.Add(this.file_open);
            this.Name = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button file_open;
        private System.Windows.Forms.Button calculate;
        private System.Windows.Forms.Button report;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

