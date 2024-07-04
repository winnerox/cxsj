using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 坐标转换
{
    public partial class Form1 : Form
    {

        struct BLHXYZ
        {
            public string name;
            public double B, L, H;
            public double X, Y, Z;
        }
        List< BLHXYZ > BLHXYZList= new List< BLHXYZ >();
        public Form1()
        {
            InitializeComponent();
        }
        private void file_open (object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog.FileName;
                string[] lines = File.ReadAllLines(filename);
                string[] columnNames = { "NameColumn", "BColumn", "LColumn", "HColumn" };
                string[] headers = { "点名", "B", "L", "H" };

                // 循环添加列
                for (int i = 0; i < columnNames.Length; i++)
                {
                    DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                    column.Name = columnNames[i];
                    column.HeaderText = headers[i];
                    dataGridView1.Columns.Add(column);
                }
                for (int i = 4; i < lines.Length; i++)
                {
                    string[] parts = lines[i].Split(',');
                    if (parts.Length == 4)  // 确保每行有4个部分
                    {
                        BLHXYZ bLHXYZ = new BLHXYZ();
                        string name = parts[0];
                        double B = Convert.ToDouble(parts[1]);
                        double L = Convert.ToDouble(parts[2]);
                        double H = Convert.ToDouble(parts[3]);
                        bLHXYZ.name = name;
                        bLHXYZ.B = B;
                        bLHXYZ.L = L;
                        bLHXYZ.H = H;
                        BLHXYZList.Add(bLHXYZ);
                        dataGridView1.Rows.Add(name, B, L, H);
                    }
                }

            }

        }
        private void calculate_Click(object sender, EventArgs e)
        {
            string option = comboBox1.Text;
            if (option == "BLH2XYZ")
            {
                //清除并创建
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                string[] columnNames = { "NameColumn", "BColumn", "LColumn", "HColumn" ,
                                        "XColumn","YColumn","ZColumn"};
                string[] headers = { "点名", "B", "L", "H" ,"X","Y","Z"};

                // 循环添加列
                for (int i = 0; i < columnNames.Length; i++)
                {
                    DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                    column.Name = columnNames[i];
                    column.HeaderText = headers[i];
                    dataGridView1.Columns.Add(column);
                }
                EP eP = new EP();
                BLH2XYZ bLH2XYZ = new BLH2XYZ(eP);
                for (int i = 0;i< BLHXYZList.Count; i++)
                {
                    double B = BLHXYZList[i].B;
                    double L = BLHXYZList[i].L;
                    double H = BLHXYZList[i].H;
                    string name = BLHXYZList[i].name;
                    var(X,Y,Z)=bLH2XYZ.BLH2XYZ_calculate(BLHXYZList[i].B, BLHXYZList[i].L, BLHXYZList[i].H);
                    dataGridView1.Rows.Add(name, B, L, H, X, Y, Z);
                    string dataLine = $" Name: {name},B: {B}, L: {L}, H: {H},X: {X}, Y: {Y}, Z: {Z},";
                    richTextBox2.AppendText(dataLine+Environment.NewLine);
                }
            }
            else if (option == "XYZ2BLH")
            {
                //清除并创建
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                string[] columnNames = { "NameColumn", "XColumn","YColumn","ZColumn","BColumn", "LColumn", "HColumn" };
                string[] headers = { "点名", "X", "Y", "Z","B", "L", "H" };
                // 循环添加列
                for (int i = 0; i < columnNames.Length; i++)
                {
                    DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                    column.Name = columnNames[i];
                    column.HeaderText = headers[i];
                    dataGridView1.Columns.Add(column);
                }
                EP eP = new EP();
                BLH2XYZ bLH2XYZ = new BLH2XYZ(eP);
                XYZ2BLH xYZ2BLH = new XYZ2BLH(eP);
                //textBox1.AppendText("XYZ2BLH" + Environment.NewLine);
                for (int i = 0; i < BLHXYZList.Count; i++)
                {
                    double B = BLHXYZList[i].B;
                    double L = BLHXYZList[i].L;
                    double H = BLHXYZList[i].H;
                    string name = BLHXYZList[i].name;
                    var (X, Y, Z) = bLH2XYZ.BLH2XYZ_calculate(BLHXYZList[i].B, BLHXYZList[i].L, BLHXYZList[i].H);
                    X = X + 1000;Y = Y + 1000;Z = Z + 1000;
                    var (B_, L_, H_) = xYZ2BLH.XYZ2BLH_calculate(X, Y ,Z);
                    dataGridView1.Rows.Add(name, X, Y, Z, B_, L_, H_);
                    string dataLine = $" Name: {name},X: {X}, Y: {Y}, Z: {Z}, B: {B_}, L: {L_}, H: {H_}";
                    richTextBox2.AppendText(dataLine+Environment.NewLine);
                }
            }

            else if (option == "BL2XY")
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                string[] columnNames = { "NameColumn","BColumn", "LColumn", "XColumn", "YColumn" };
                string[] headers = { "点名","B", "L", "X", "Y" };
                // 循环添加列
                for (int i = 0; i < columnNames.Length; i++)
                {
                    DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                    column.Name = columnNames[i];
                    column.HeaderText = headers[i];
                    dataGridView1.Columns.Add(column);
                }
                EP eP = new EP();
                Gauss1 gauss1 = new Gauss1(eP);
                for (int i = 0; i < BLHXYZList.Count; i++)
                {
                    string name = BLHXYZList[i].name;
                    double B = BLHXYZList[i].B;
                    double L = BLHXYZList[i].L;

                    var (x, y) = gauss1.Gauss1_calculate(B, L);
                    dataGridView1.Rows.Add(name,B,L,x,y);

                }


            }
            else if (option == "XY2BL")
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Text Files|*.txt|All Files|*.*",
                Title = "Save RichTextBox Content",
                FileName = "RichTextBoxContent.txt"
            };

            // 如果用户点击了“保存”按钮
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // 获取RichTextBox中的内容
                string content = richTextBox2.Text;

                // 获取用户选择的文件路径
                string filePath = saveFileDialog.FileName;

                // 将内容写入文件
                try
                {
                    File.WriteAllText(filePath, content);
                    MessageBox.Show("File saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
