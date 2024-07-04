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
namespace 电离层改正2
{
    struct satellite_coordinate
    {
        public string name;
        public double X;
        public double Y;
        public double Z;
        public satellite_coordinate(string name,double X, double Y, double Z)
        {
            this.name = name;
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }
    }
    struct IP
    {
        public double Phi_IP;
        public double Lambda_IP;
        public double Phi_m;
        public IP(double Phi_IP,double Lambda_IP,double Phi_m)
        {
            this.Phi_IP = Phi_IP;
            this.Lambda_IP = Lambda_IP;
            this.Phi_m = Phi_m;
        }
        
    }
    struct EandA
    {
        public double E;
        public double A;
        public EandA(double E,double A)
        {
            this.E = E;
            this.A = A;
        }
      
    }
    struct delay
    {
        public double Tion;
        public double Dion;
        public delay(double Tion,Double Dion)
        {
            this.Tion = Tion;
            this.Dion = Dion;
        }
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<satellite_coordinate> satellites = new List<satellite_coordinate>();
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

                for (int i = 1; i < lines.Length; i++)
                {                   
                    string[] parts = lines[i].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    string name = parts[0];
                    double X = Convert.ToDouble(parts[1]) * 1000;
                    double Y = Convert.ToDouble(parts[2]) * 1000;
                    double Z = Convert.ToDouble(parts[3]) * 1000;
                    satellite_coordinate satellite_Coordinate = new satellite_coordinate(name, X, Y, Z);
                    satellites.Add(satellite_Coordinate);
                }
                richTextBox1.AppendText("卫星点位数据\n");
                //richTextBox1.AppendText("点名      X      Y      Z\n");
                foreach(var satellite in satellites)
                {
                    richTextBox1.AppendText($"{satellite.name.PadRight(8)}{satellite.X.ToString("F6").PadRight(18)}{satellite.Y.ToString("F6").PadRight(18)}{satellite.Z.ToString("F6").PadRight(18)}\n");
                }
            }
        }
        private void calculate_click(object sender, EventArgs e)
        {
            Myfoundations myfoundations = new Myfoundations();
            calculate calculate = new calculate();
            List<EandA> EandAs = calculate.Eand_calculate(satellites);
            List<IP> IPs = calculate.Geomagnetic_latitude_calculate(EandAs);
            List<delay> delays = calculate.delay_calculate(IPs,EandAs);
            richTextBox1.Clear();
            richTextBox1.AppendText("计算结果为\n");
            richTextBox1.AppendText("SV   EL(°)   AZ(°)   L1(m)   L2(m)\n");
            for (int i = 0; i < satellites.Count; i++)
            {
                string E = EandAs[i].E.ToString("F3");
                string A = EandAs[i].A.ToString("F3");
                string Tion = delays[i].Tion.ToString("F4");
                string Dion1= (delays[i].Dion * 1.65).ToString("F4");
                string Dion= delays[i].Dion.ToString("F4");
                richTextBox1.AppendText($"{satellites[i].name.PadRight(6)}{E.PadRight(12)}{A.PadRight(12)}{Dion.PadRight(12)}{Dion1.PadRight(12)}\n");
            }
        }
        private void report_click(object sender, EventArgs e)
        {
            // 获取RichTextBox的内容
            string content = richTextBox1.Text;

            // 定义文件保存路径
            string filePath = "D:\\C++\\电离层改正2\\结果报告.txt";

            // 将内容写入文件
            File.WriteAllText(filePath, content);
        }


    }
}
