using System.Collections.Generic;

namespace 电离层改正模型
{
    public struct statelite_coordinate
    {
        public string name;
        public double X;
        public double Y;
        public double Z;
    }
    public struct EandA
    {
        public double E;
        public double A;
    }
    public struct IP
    {
        public double Phi;
        public double Lambda;
        public double Psi;
        public double Phi_m;
    }
    public struct TandD
    {
        public double Tion;
        public double Dion;
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public List<statelite_coordinate> statelite_list = new List<statelite_coordinate>();
        private void FileOpenButton_Click(object sender, EventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string[] lines = File.ReadAllLines(ofd.FileName);
                for (int i = 1; i < lines.Length; i++)
                {
                    statelite_coordinate statelite_ = new statelite_coordinate();
                    string[] parts = lines[i].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    statelite_.name = parts[0];
                    statelite_.X = Convert.ToDouble(parts[1]) * 1000;
                    statelite_.Y = Convert.ToDouble(parts[2]) * 1000;
                    statelite_.Z = Convert.ToDouble(parts[3]) * 1000;
                    statelite_list.Add(statelite_);
                }
            }

        }

        private void Calculate_Button_Click(object sender, EventArgs e)
        {
            string[] columnNames = { "SvColumn", "ELColumn", "AZColumn","L1","L2"};
            string[] headers = { "SV", "EL(°)", "AZ(°)", "L1(m)", "L2(m)"};

            // 循环添加列
            for (int i = 0; i < columnNames.Length; i++)
            {
                DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                column.Name = columnNames[i];
                column.HeaderText = headers[i];
                dataGridView1.Columns.Add(column);
            }
            dataGridView1.Visible = true;
            geo geo = new geo();
            
            calculate calc = new calculate();
            calc.StateliteList = statelite_list;
            List<EandA> EandAList = calc.calculate_EandA(statelite_list);
            List<TandD> TandD_list = calc.calculate_DandT(EandAList);
            for (int i = 0;i < statelite_list.Count;i++) 
            {
                dataGridView1.Rows.Add(statelite_list[i].name, EandAList[i].E, EandAList[i].A, TandD_list[i].Tion, TandD_list[i].Dion); 
            }
            

        }

        private void ReportButton_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}