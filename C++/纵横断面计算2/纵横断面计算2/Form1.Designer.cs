namespace 纵横断面计算2
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
            this.File_Open = new System.Windows.Forms.Button();
            this.Calculate = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // File_Open
            // 
            this.File_Open.Location = new System.Drawing.Point(12, 12);
            this.File_Open.Name = "File_Open";
            this.File_Open.Size = new System.Drawing.Size(146, 56);
            this.File_Open.TabIndex = 0;
            this.File_Open.Text = "文件读取";
            this.File_Open.UseVisualStyleBackColor = true;
            this.File_Open.Click += new System.EventHandler(this.File_Open_click);
            // 
            // Calculate
            // 
            this.Calculate.Location = new System.Drawing.Point(306, 12);
            this.Calculate.Name = "Calculate";
            this.Calculate.Size = new System.Drawing.Size(140, 56);
            this.Calculate.TabIndex = 2;
            this.Calculate.Text = "断面计算";
            this.Calculate.UseVisualStyleBackColor = true;
            this.Calculate.Click += new System.EventHandler(this.Calculate_click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 125);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(921, 438);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(604, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 56);
            this.button1.TabIndex = 4;
            this.button1.Text = "输出报告";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.report_click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 605);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.Calculate);
            this.Controls.Add(this.File_Open);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button File_Open;
        private System.Windows.Forms.Button Calculate;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button1;
    }
}

