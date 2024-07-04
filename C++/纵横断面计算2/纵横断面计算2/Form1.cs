using System;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
namespace 纵横断面计算2
{
    public struct Point
    {
        public string name;
        public double X;
        public double Y;
        public double Z;
        public Point(string name,double X,double Y,double Z)
        {
            this.name = name;
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Point> Point_list = new List<Point>();
        private void File_Open_click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.AppendText("点位数据\n");
                richTextBox1.AppendText("----------------------------\n");
                richTextBox1.AppendText("点名   X坐标(m)   Y坐标(m)   H坐标(m)\n");
                string filename = openFileDialog.FileName;
                string[] lines= File.ReadAllLines(filename);
                for (int i=5;i<lines.Length;i++)
                {
                    string[] parts = lines[i].Split(',');
                    string name = parts[0];
                    double X = Convert.ToDouble(parts[1]);
                    double Y = Convert.ToDouble(parts[2]);
                    double Z = Convert.ToDouble(parts[3]);
                    Point point = new Point(name, X, Y, Z);
                    Point_list.Add(point);
                }
                for (int i = 0; i < Point_list.Count ; i++)
                {
                    richTextBox1.AppendText($"{Point_list[i].name.PadRight(6)}{Point_list[i].X.ToString("F3").PadRight(12)}{Point_list[i].Y.ToString("F3").PadRight(12)}{Point_list[i].Z.ToString("F3").PadRight(12)}\n");
                }
            }
        } 

        private void Calculate_click(object sender,EventArgs e)
        {
            //纵断面
            Calculate calculate = new Calculate();
            List<Point> coordinates_LS = new List<Point>();
            coordinates_LS = calculate.coordinates_LS(Point_list);
            double area_LS = calculate.cross_area_calculate(coordinates_LS);
            double lenth_LS = calculate.length_calculate(coordinates_LS);
            richTextBox1.Clear();
            richTextBox1.AppendText("纵断面信息\n");
            richTextBox1.AppendText("----------------------------\n");
            richTextBox1.AppendText($"纵断面积:{area_LS}\n");
            richTextBox1.AppendText($"纵断面全长: {lenth_LS}\n");
            richTextBox1.AppendText("线路主点:\n");
            richTextBox1.AppendText("点名    X坐标(m)    Y坐标(m)    H坐标(m)\n");

            foreach (var point in coordinates_LS)
            {
                richTextBox1.AppendText($"{point.name.PadRight(6)} {point.X.ToString("F3").PadRight(12)} {point.Y.ToString("F3").PadRight(12)} {point.Z.ToString("F3").PadRight(8)}\n");
            }
            //横断面1
            List<Point> coordinates_HS1 = new List<Point>();
            coordinates_HS1 = calculate.coordinates_HS1(Point_list);
            double area_HS1 = calculate.cross_area_calculate(coordinates_HS1);
            double lenth_HS1 = calculate.length_calculate(coordinates_HS1);
            richTextBox1.AppendText("横断面信息1\n");
            richTextBox1.AppendText("----------------------------\n");
            richTextBox1.AppendText($"纵断面积:{area_HS1}\n");
            richTextBox1.AppendText($"纵断面全长: {lenth_HS1}\n");
            richTextBox1.AppendText("线路主点:\n");
            richTextBox1.AppendText("点名    X坐标(m)    Y坐标(m)    H坐标(m)\n");

            foreach (var point in coordinates_HS1)
            {
                richTextBox1.AppendText($"{point.name.PadRight(6)} {point.X.ToString("F3").PadRight(12)} {point.Y.ToString("F3").PadRight(12)} {point.Z.ToString("F3").PadRight(8)}\n");
            }
            //横断面2
            List<Point> coordinates_HS2 = new List<Point>();
            coordinates_HS2 = calculate.coordinates_HS2(Point_list);
            double area_HS2 = calculate.cross_area_calculate(coordinates_HS2);
            double lenth_HS2 = calculate.length_calculate(coordinates_HS2);
            richTextBox1.AppendText("横断面信息2\n");
            richTextBox1.AppendText("----------------------------\n");
            richTextBox1.AppendText($"纵断面积:{area_HS2}\n");
            richTextBox1.AppendText($"纵断面全长: {lenth_HS2}\n");
            richTextBox1.AppendText("线路主点:\n");
            richTextBox1.AppendText("点名    X坐标(m)    Y坐标(m)    H坐标(m)\n");

            foreach (var point in coordinates_HS2)
            {
                richTextBox1.AppendText($"{point.name.PadRight(6)} {point.X.ToString("F3").PadRight(12)} {point.Y.ToString("F3").PadRight(12)} {point.Z.ToString("F3").PadRight(8)}\n");
            }
        }
        
        private void report_click(object sender, EventArgs e)
        {
            string content = richTextBox1.Text;
            string filePath = "D:\\C++\\纵横断面计算2\\结果报告.txt";
            File.WriteAllText(filePath, content);

        }
        
    }
}
