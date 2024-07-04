using System.Windows.Forms;
using System;
using System.IO;
namespace 大地线长度计算
{
    struct ellipsoid_elements
    {
        public double option;
        public double a;
        public double e2;
        public double e12;
        public double f;
        public ellipsoid_elements(double x, double y, double z, double d, double c)
        {
            a = x; e2 = y; e12 = z; f = d; option = c;
        }
    }
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        ellipsoid_elements ellipsoid_Elements = new ellipsoid_elements();

        private void toolOpen_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    toolStripStatusLabel1.ForeColor = Color.Black;
                    toolStripStatusLabel1.Text = "文件格式正确！";
                    string filename = openFileDialog.FileName;
                    string[] lines = File.ReadAllLines(filename);
                    data data = new data();
                    data.fuzhi(lines);
                    int counter = 1;
                    foreach (string line in lines)
                    {
                        string pValue = "P" + counter.ToString();
                        string[] parts = line.Split(' ');
                        dataGridView1.Rows.Add(pValue, parts[0], parts[1]);
                        counter++;
                    }
                }
            }


            catch
            {
                toolStripStatusLabel1.ForeColor = Color.Red;
                toolStripStatusLabel1.Text = "文件格式错误！";
            }
        }
        private void option_change_Click(object sender, EventArgs e)
        {

            string selected = (string)comboBox1.SelectedItem;

            if (selected == "克拉索夫斯基")
            {
                ellipsoid_Elements.option = 1;
                ellipsoid_Elements.a = 6378245;
                ellipsoid_Elements.e2 = 0.00669342162297;
                ellipsoid_Elements.e12 = 0.00673852541468;
                ellipsoid_Elements.f = 1 / 298.3;
                toolStripStatusLabel1.ForeColor = Color.Black;
                toolStripStatusLabel1.Text = "克拉索夫斯基";
            }
            else if (selected == "IUGG1975")
            {
                ellipsoid_Elements.option = 2;
                ellipsoid_Elements.a = 6378140;
                ellipsoid_Elements.e2 = 0.00669438499959;
                ellipsoid_Elements.e12 = 0.00673852541468;
                ellipsoid_Elements.f = 1 / 298.257;
                toolStripStatusLabel1.ForeColor = Color.Black;
                toolStripStatusLabel1.Text = "IUGG1975";
            }
            else if (selected == "CGCS2000")
            {
                ellipsoid_Elements.option = 3;
                ellipsoid_Elements.a = 6378137;
                ellipsoid_Elements.e2 = 0.00669438002290;
                ellipsoid_Elements.e12 = 0.00673949677548;
                ellipsoid_Elements.f = 1 / 298.25722210100;
                toolStripStatusLabel1.ForeColor = Color.Black;
                toolStripStatusLabel1.Text = "CGCS2000";
            }

        }

        private void calculate_Click(object sender, EventArgs e)
        {
            Calculate calculate = new Calculate();
            try {
                double result = calculate.CalculateDistance(ellipsoid_Elements, data.B_1, data.L_1, data.B_2, data.L_2);
                toolStripStatusLabel1.ForeColor = Color.Black;
                toolStripStatusLabel1.Text = "计算完成！";
                resultBox.Text = result.ToString();
            }
            catch
            {
                toolStripStatusLabel1.ForeColor = Color.Red;
                toolStripStatusLabel1.Text = "数据有误！";
            }
            
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {

        }
    }
}