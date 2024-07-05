using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace 对流层改正计算
{
    struct coordinate
    {
        public string name;
        public double time;
        public double B;
        public double L;
        public double H;
        public double E;
        public coordinate(string name, double time, double B, double L, double H, double E)
        {
            this.name = name;
            this.time = time;
            this.B = B;
            this.L = L;
            this.H = H;
            this.E = E;

        }
    }
    struct resulst
    {
        public string name;
        public double E;
        public double ZHD;
        public double m_d;
        public double ZWD;
        public double m_w;
        public double delta_s;
        public resulst(string name ,double E,double ZHD,double m_d,double ZWD,double m_w,double delta_s)
        {
            this.name = name;
            this.E = E;
            this.ZHD = ZHD;
            this.m_d = m_d;
            this.ZWD = ZWD;
            this.m_w = m_w;
            this.delta_s = delta_s;
        }
    }
    //struct m_w
    //{
    //    public List<double> avg;
    //    public m_w(List<double> avg)
    //    {
    //        this.avg = avg;
    //    }
    //}
    //struct m_h
    //{
    //    public List<double> avg;
    //    public List<double> amp;
    //    public m_h(List<double> avg, List<double> amp)
    //    {
    //        this.avg = avg;
    //        this.amp = amp;
    //    }
    //}
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<coordinate> coordinates = new List<coordinate>();
        //文件读取
        private void file_open_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string filename = ofd.FileName;
                string[] lines = File.ReadAllLines(filename);
                for (int i = 1; i < lines.Length; i++)
                {
                    string[] parts = lines[i].Split(',');
                    string name = parts[0];
                    double time =Convert.ToDouble(parts[1]);
                    double B= Convert.ToDouble(parts[2]);
                    double L= Convert.ToDouble(parts[3]);
                    double H= Convert.ToDouble(parts[4]);
                    double E= Convert.ToDouble(parts[5]);
                    coordinate coordinate = new coordinate(name, time, B, L, H, E);
                    coordinates.Add(coordinate);
                }
            }
            richTextBox1.AppendText("测站名,时间(YYYYMMDD),经度(°), 纬度(°)，大地高(m)，高度角(°)\n");
            foreach(var coordinate in coordinates)
            {
                richTextBox1.AppendText($"{coordinate.name.PadRight(8)}{coordinate.time.ToString().PadRight(12)}{coordinate.B.ToString().PadRight(12)}{coordinate.L.ToString().PadRight(12)}{coordinate.H.ToString().PadRight(12)}{coordinate.E.ToString().PadRight(12)}\n");
            }
                
        }
        public void calculate_click(object sender, EventArgs e)
        {
            calculate calculate = new calculate();
            List<double> m_ws = calculate.m_w_calculate(coordinates);
            List<double> m_ds = calculate.m_d_calculate(coordinates);
            richTextBox1.Clear();
            for (int i = 0; i < coordinates.Count; i++)
            {
                double delta_S = 2.9951 * Math.Pow(Math.E, -0.00016 * coordinates[i].H) * m_ws[i] + 0.1 * m_ds[i];
                richTextBox1.AppendText($"{coordinates[i].name} {Math.Pow(Math.E, -0.00016 * coordinates[i].H).ToString("F3")} {m_ds[i].ToString("F3")} 0.100 {m_ws[i].ToString("F3")} {delta_S.ToString("F3")}\n");
            }

        }


    }
}
