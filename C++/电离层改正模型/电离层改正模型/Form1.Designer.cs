namespace 电离层改正模型
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            FileOpenButton = new Button();
            CalculateButton = new Button();
            ReportButton = new Button();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // FileOpenButton
            // 
            FileOpenButton.Location = new Point(28, 40);
            FileOpenButton.Name = "FileOpenButton";
            FileOpenButton.Size = new Size(112, 34);
            FileOpenButton.TabIndex = 0;
            FileOpenButton.Text = "文件";
            FileOpenButton.UseVisualStyleBackColor = true;
            FileOpenButton.Click += FileOpenButton_Click;
            // 
            // CalculateButton
            // 
            CalculateButton.Location = new Point(204, 40);
            CalculateButton.Name = "CalculateButton";
            CalculateButton.Size = new Size(112, 34);
            CalculateButton.TabIndex = 1;
            CalculateButton.Text = "计算";
            CalculateButton.UseVisualStyleBackColor = true;
            CalculateButton.Click += Calculate_Button_Click;
            // 
            // ReportButton
            // 
            ReportButton.Location = new Point(386, 40);
            ReportButton.Name = "ReportButton";
            ReportButton.Size = new Size(112, 34);
            ReportButton.TabIndex = 2;
            ReportButton.Text = "生成报告";
            ReportButton.UseVisualStyleBackColor = true;
            ReportButton.Click += ReportButton_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(2, 174);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.RowTemplate.Height = 32;
            dataGridView1.Size = new Size(1164, 513);
            dataGridView1.TabIndex = 4;
            dataGridView1.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1167, 730);
            Controls.Add(dataGridView1);
            Controls.Add(ReportButton);
            Controls.Add(CalculateButton);
            Controls.Add(FileOpenButton);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private Button FileOpenButton;
        private Button CalculateButton;
        private Button ReportButton;
        private DataGridView dataGridView1;
    }
}