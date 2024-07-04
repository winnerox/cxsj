namespace 纵横断面计算
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
            this.basic_calculate = new System.Windows.Forms.Button();
            this.LC_calculate = new System.Windows.Forms.Button();
            this.HS_calculate = new System.Windows.Forms.Button();
            this.file_open = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // basic_calculate
            // 
            this.basic_calculate.Location = new System.Drawing.Point(274, 31);
            this.basic_calculate.Name = "basic_calculate";
            this.basic_calculate.Size = new System.Drawing.Size(155, 41);
            this.basic_calculate.TabIndex = 0;
            this.basic_calculate.Text = "基本计算";
            this.basic_calculate.UseVisualStyleBackColor = true;
            this.basic_calculate.Click += new System.EventHandler(this.basic_calculate_Click);
            // 
            // LC_calculate
            // 
            this.LC_calculate.Location = new System.Drawing.Point(531, 31);
            this.LC_calculate.Name = "LC_calculate";
            this.LC_calculate.Size = new System.Drawing.Size(155, 41);
            this.LC_calculate.TabIndex = 1;
            this.LC_calculate.Text = "道路纵断面计算";
            this.LC_calculate.UseVisualStyleBackColor = true;
            this.LC_calculate.Click += new System.EventHandler(this.LC_calculate_Click);
            // 
            // HS_calculate
            // 
            this.HS_calculate.Location = new System.Drawing.Point(788, 31);
            this.HS_calculate.Name = "HS_calculate";
            this.HS_calculate.Size = new System.Drawing.Size(155, 41);
            this.HS_calculate.TabIndex = 2;
            this.HS_calculate.Text = "道路横断面计算";
            this.HS_calculate.UseVisualStyleBackColor = true;
            // 
            // file_open
            // 
            this.file_open.Location = new System.Drawing.Point(45, 31);
            this.file_open.Name = "file_open";
            this.file_open.Size = new System.Drawing.Size(155, 41);
            this.file_open.TabIndex = 3;
            this.file_open.Text = "文件";
            this.file_open.UseVisualStyleBackColor = true;
            this.file_open.Click += new System.EventHandler(this.file_open_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(45, 163);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(898, 452);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 661);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.file_open);
            this.Controls.Add(this.HS_calculate);
            this.Controls.Add(this.LC_calculate);
            this.Controls.Add(this.basic_calculate);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button basic_calculate;
        private System.Windows.Forms.Button LC_calculate;
        private System.Windows.Forms.Button HS_calculate;
        private System.Windows.Forms.Button file_open;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

