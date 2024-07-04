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

namespace 大地主题正反算
{
    struct Point_P
    {
        public double B;
        public double L;
        public Point_P(double B,double L)
        {
            this.B = B;
            this.L = L;
        }
    }
    struct ellipsoid_elements
    {
        public string ellipsoid;
        public double a;
        public double b;
        public double f;
        public double e2;
        public double e2_;
        public ellipsoid_elements(string ellipsoid ,double a,double b,double f,double e2,double e2_) 
        {
            this.ellipsoid = ellipsoid;
            this.a = a;
            this.b = b;
            this.f = f;
            this.e2 = e2;
            this.e2_ = e2_;

        }
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Point_P P1=new Point_P();
        Point_P P2=new Point_P();
        ellipsoid_elements ellipsoid_Elements = new ellipsoid_elements();
        private void File_Open_click(object sender, EventArgs e)
        {
            // 创建并配置一个打开文件对话框
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // 显示对话框并检查用户是否选择了一个文件
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // 获取用户选择的文件路径
                string filename = openFileDialog.FileName;
                // 读取文件中的所有行
                string[] lines = File.ReadAllLines(filename);
                string[] parts1 = lines[0].Split(' ');
                string[] parts2 = lines[1].Split(' ');
                P1.B = Convert.ToDouble(parts1[0]);
                P1.L = Convert.ToDouble(parts1[1]);
                P2.B = Convert.ToDouble(parts2[0]);
                P2.L = Convert.ToDouble(parts2[1]);
                richTextBox1.AppendText("点名   B(dd.mmss)   L(dd.mmss)\n");
                richTextBox1.AppendText($"P1   {P1.B}   {P1.L}\n");
                richTextBox1.AppendText($"P2   {P2.B}   {P2.L}\n");
            }
        }
        private void option_change_Click(object sender, EventArgs e)
        {

            string selected = (string)comboBox1.SelectedItem;

            if (selected == "克拉索夫斯基")
            {
                ellipsoid_Elements.ellipsoid = "克拉索夫斯基";
                ellipsoid_Elements.a = 6378245;
                ellipsoid_Elements.e2 = 0.00669342162297;
                ellipsoid_Elements.e2_ = 0.00673852541468;
                ellipsoid_Elements.f = 1 / 298.3;
            }
            else if (selected == "IUGG1975")
            {
                ellipsoid_Elements.ellipsoid = "IUGG1975";
                ellipsoid_Elements.a = 6378140;
                ellipsoid_Elements.e2 = 0.00669438499959;
                ellipsoid_Elements.e2_ = 0.00673852541468;
                ellipsoid_Elements.f = 1 / 298.257;
            }
            else if (selected == "CGCS2000")
            {
                ellipsoid_Elements.ellipsoid = "CGCS2000";
                ellipsoid_Elements.a = 6378137;
                ellipsoid_Elements.e2 = 0.00669438002290;
                ellipsoid_Elements.e2_ = 0.00673949677548;
                ellipsoid_Elements.f = 1 / 298.25722210100;
            }

        }
        private void calculate_Click(object sender, EventArgs e)
        {
            calculate calculate = new calculate();
            double result = calculate.lenth_calculate(ellipsoid_Elements, P1, P2);
            if  (ellipsoid_Elements.ellipsoid == "克拉索夫斯基")
            {
                richTextBox1.AppendText($"大地线长度(克拉索夫斯基)： {result.ToString()}\n");
            }
            else if (ellipsoid_Elements.ellipsoid == "IUGG1975")
            {
                richTextBox1.AppendText($"大地线长度(IUGG1975)： {result.ToString()}\n");
            }
            else if (ellipsoid_Elements.ellipsoid == "CGCS2000")
            {
                richTextBox1.AppendText($"大地线长度(CGCS2000)： {result.ToString()}\n");
            }

        }
    }
}
