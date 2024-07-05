using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 对流层改正计算
{
    class calculate
    {
        public double degrees2radians(double degrees )
        {
            return degrees * Math.PI / 180;
        }
        //湿分量
        public  List<double> a_w = new List<double> { 0.00058021897, 0.00056794847, 0.00058118019, 0.00059727542, 0.00061641693 };
        public  List<double> b_w = new List<double> { 0.0014275268, 0.0015138625, 0.0014572752, 0.0015007428, 0.0017599082 };
        public  List<double> c_w = new List<double> { 0.043472961, 0.046729510, 0.043908931, 0.044626982, 0.054736038 };
        //干分量
        public  List<double> a_h = new List<double> { 0.0012769934, 0.0012683230, 0.0012465397, 0.0012196049, 0.0012045996 };
        public  List<double> b_h = new List<double> { 0.0029153695, 0.0029152299, 0.0029288445, 0.0029022565, 0.0029024912 };
        public  List<double> c_h = new List<double> { 0.062610505, 0.062837393, 0.063721774, 0.063824265, 0.064258455 };
        public  List<double> a_h_ = new List<double> { 0.0, 0.000012709626, 0.000026523662, 0.000034000452, 0.000041202191 };
        public  List<double> b_h_ = new List<double> { 0.0, 0.000021414979, 0.000030160779, 0.000072562722, 0.00011723375 };
        public  List<double> c_h_ = new List<double> { 0.0, 0.000090128400, 0.000043497037, 0.00084795348, 0.0017037206 };

        //湿分量系数内插计算
        public double abc_w_calculte(double L,List<double> w)
        {
            double m=0;
            for (int i = 0; i < 5; i++)
            {
                if (i * 15 < L && L < (i + 1) * 15)
                {
                    m = w[i - 1] + (L - i * 15) * (w[i] - w[i - 1]) / 15;
                    break;
                }
            }
            return m;
        }
        //干分量系数内插计算
        public double abc_d_calculte(double L, double time , double H,List<double> h, List<double> h1)
        {
            double m=0;
            DateTime date = DateTime.ParseExact(time.ToString(), "yyyyMMdd", null);
            int dayofyear = date.DayOfYear;
            for (int i = 1; i < 5; i++)
            {
                if (i * 15 < L && L < (i + 1) * 15)
                {
                    m = h[i - 1] + (L - i * 15) * (h[i] - h[i - 1]) / 15
                        +(h1[i - 1] + (L - (i - 1) * 15) * (h1[i] - h1[i - 1]) / 15)*Math.Cos(Math.PI*2* (dayofyear-28)/365.25);
                    break;
                } 
            }
            return m;
        }
        //m_w计算
        public List<double> m_w_calculate(List<coordinate> coordinates)
        {
            List<double> m_ws = new List<double>();
            double a_w1, b_w1, c_w1;
            double se, up, down;
            foreach (var coordinate in coordinates)
            {
                if (coordinate.L <= 15)
                {
                    a_w1 = a_w[0];
                    b_w1 = b_w[0];
                    c_w1 = c_w[0];
                }
                else if (coordinate.L >= 75)
                {
                    a_w1 = a_w[4];
                    b_w1 = b_w[4];
                    c_w1 = c_w[4];
                }
                else
                {
                    a_w1 = abc_w_calculte(coordinate.L, a_w);
                    b_w1 = abc_w_calculte(coordinate.L, b_w);
                    c_w1 = abc_w_calculte(coordinate.L, c_w);                   
                }
                se = Math.Sin(degrees2radians(coordinate.E));
                up = 1 / (1 + a_w1 / (1 + b_w1 / (1 + c_w1)));
                down = 1 / (se + a_w1 / (se + b_w1 / (se + c_w1)));
                double result= up / down;
                m_ws.Add(result);
                //double r1 = b_w1 / (1 + c_w1);
                //double r2 = a_w1 / (1 + r1);
                //double r3 = 1 / (1 + r2);
                //double p1 = b_w1 / (Math.Sin(degrees2radians(coordinate.E)) + c_w1);
                //double p2 = a_w1 / (Math.Sin(degrees2radians(coordinate.E)) + p1);
                //double p3 = 1 / (Math.Sin(degrees2radians(coordinate.E)) + p2);
            }
            return m_ws;
        }
        //m_d计算
        public List<double> m_d_calculate(List<coordinate> coordinates)
        {
            
            double aht = 2.53e-5, bht = 5.49e-3, cht = 1.14e-3;
            List<double> m_hs = new List<double>();
            double a_h1, b_h1, c_h1;
            foreach(var coordinate in coordinates)
            {
                if (coordinate.L <= 15)
                {
                    a_h1 = a_w[0];
                    b_h1 = b_w[0];
                    c_h1 = c_w[0];
                }
                else if (coordinate.L >= 75)
                {
                    a_h1 = a_w[4];
                    b_h1 = b_w[4];
                    c_h1 = c_w[4];
                }
                else
                {
                    a_h1 = abc_d_calculte(coordinate.L,coordinate.time,coordinate.H,a_h,a_h_);
                    b_h1 = abc_d_calculte(coordinate.L, coordinate.time, coordinate.H, b_h, b_h_);
                    c_h1 = abc_d_calculte(coordinate.L, coordinate.time, coordinate.H, c_h, c_h_);
                }

                double R1 = b_h1 / (1 + c_h1);
                double R2 = a_h1 / (1 + R1);
                double R3 = 1 / (1 + R2);
                double P1 = b_h1 / (Math.Sin(degrees2radians(coordinate.E)) + c_h1);
                double P2 = a_h1 / (Math.Sin(degrees2radians(coordinate.E)) + P1);
                double P3 = 1 / (Math.Sin(degrees2radians(coordinate.E)) + P2);

                double R1_ = bht / (1 + cht);
                double R2_ = aht / (1 + R1);
                double R3_ = 1 / (1 + R2);
                double P1_ = bht / (Math.Sin(degrees2radians(coordinate.E)) + c_h1);
                double P2_ = aht / (Math.Sin(degrees2radians(coordinate.E)) + P1);
                double P3_ = 1 / (Math.Sin(degrees2radians(coordinate.E)) + P2);

                double J = R3 / P3 + (1 / Math.Sin(degrees2radians(coordinate.E)) - (R3_ / P3_)) * coordinate.H / 1000;
                m_hs.Add(J);
            }
            return m_hs;
            
        }

    }
}
