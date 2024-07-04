namespace 大地线长度计算
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
            OpenFileButton = new Button();
            dataGridView1 = new DataGridView();
            Column0 = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            CalculateButton = new Button();
            resultBox = new TextBox();
            label1 = new Label();
            comboBox1 = new ComboBox();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // OpenFileButton
            // 
            OpenFileButton.Location = new Point(12, 10);
            OpenFileButton.Name = "OpenFileButton";
            OpenFileButton.Size = new Size(112, 34);
            OpenFileButton.TabIndex = 0;
            OpenFileButton.Text = "文件";
            OpenFileButton.UseVisualStyleBackColor = true;
            OpenFileButton.Click += toolOpen_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column0, Column1, Column2 });
            dataGridView1.Location = new Point(0, 107);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.RowTemplate.Height = 32;
            dataGridView1.Size = new Size(1059, 98);
            dataGridView1.TabIndex = 2;
            // 
            // Column0
            // 
            Column0.HeaderText = "点名";
            Column0.MinimumWidth = 8;
            Column0.Name = "Column0";
            // 
            // Column1
            // 
            Column1.HeaderText = "B(dd.mmss)";
            Column1.MinimumWidth = 8;
            Column1.Name = "Column1";
            // 
            // Column2
            // 
            Column2.HeaderText = "L(dd.mmss)";
            Column2.MinimumWidth = 8;
            Column2.Name = "Column2";
            // 
            // CalculateButton
            // 
            CalculateButton.Location = new Point(294, 12);
            CalculateButton.Name = "CalculateButton";
            CalculateButton.Size = new Size(112, 34);
            CalculateButton.TabIndex = 3;
            CalculateButton.Text = "计算";
            CalculateButton.UseVisualStyleBackColor = true;
            CalculateButton.Click += calculate_Click;
            // 
            // resultBox
            // 
            resultBox.Location = new Point(394, 327);
            resultBox.Name = "resultBox";
            resultBox.Size = new Size(253, 30);
            resultBox.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(324, 327);
            label1.Name = "label1";
            label1.Size = new Size(64, 24);
            label1.TabIndex = 5;
            label1.Text = "大地长";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "克拉索夫斯基", "IUGG1975", "CGCS2000" });
            comboBox1.Location = new Point(149, 12);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(122, 32);
            comboBox1.TabIndex = 6;
            comboBox1.Text = "选项";
            comboBox1.SelectedIndexChanged += option_change_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(24, 24);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 641);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1059, 22);
            statusStrip1.TabIndex = 7;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(1044, 15);
            toolStripStatusLabel1.Spring = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1059, 663);
            Controls.Add(statusStrip1);
            Controls.Add(comboBox1);
            Controls.Add(label1);
            Controls.Add(resultBox);
            Controls.Add(CalculateButton);
            Controls.Add(dataGridView1);
            Controls.Add(OpenFileButton);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button OpenFileButton;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Column0;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private Button CalculateButton;
        private TextBox resultBox;
        private Label label1;
        private ComboBox comboBox1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
    }
}