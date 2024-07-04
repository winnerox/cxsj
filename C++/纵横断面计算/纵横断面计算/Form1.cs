using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace 纵横断面计算
{
    struct point
    {
        public string name;
        public double X;
        public double Y;
        public double Z;
        public point(string name_, double x, double y, double z)
        {
            name = name_;
            X = x;
            Y = y;
            Z = z;

        }
    }
    //定义插值点P
    struct P_point
    {
        public double x, y;
        public P_point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
    }
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
        List<point> points = new List<point>();

        private void file_open_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string filename=ofd.FileName;
                string[] lines =File.ReadAllLines(filename);
                for(int j=2; j<4; j++)
                {
                    double O = 0;
                    string[] parts = lines[j].Split(',');
                    point point = new point(parts[0],Convert.ToDouble(parts[1]), Convert.ToDouble(parts[2]), O);
                    points.Add(point);
                }
                for (int i = 5; i < lines.Length; i++)
                {
                    string[] parts = lines[i].Split(',');
                    point point = new point(parts[0], Convert.ToDouble(parts[1]), Convert.ToDouble(parts[2]), Convert.ToDouble(parts[3]));
                    points.Add(point);
                }
                for (int i = 0; i < points.Count; i++)
                {
                    string dataLine = $"Name:{points[i].name} X：{points[i].X}，Y:{points[i].Y},Z:{points[i].Z}";
                    richTextBox1.AppendText(dataLine + Environment.NewLine);
                }

            }
        }

        private void basic_calculate_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            Basic_calculate basic_Calculate = new Basic_calculate();
            List<Tuple<point,double>> nearpoints= new List<Tuple<point,double>>();
            double A;
            A = basic_Calculate.calculate_Azimuth(points[0], points[1]);
            nearpoints = basic_Calculate.calculate_PElevation(points);
            double result1 = 0, result2 = 0;
            foreach (var item in nearpoints)
            {
                result1 += item.Item1.Z / item.Item2;
                result2 += 1 / item.Item2;
                string dataLine1 = $"name：{item.Item1.name}，distance:{item.Item2}";
                richTextBox1.AppendText (dataLine1 + Environment.NewLine);
            }
            double h=result1/ result2;
            string dataLine = $"A：{A}，h:{h}";
            richTextBox1.AppendText(dataLine + Environment.NewLine);
            
        }

        private void LC_calculate_Click(object sender, EventArgs e)
        {
          
        }
    }
}
