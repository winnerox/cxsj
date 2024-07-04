using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;


namespace 电离层改正模型
{
    
    
    public class calculate
    {
        geo geo = new geo();
        public double degrees2radians(double degrees)
        {
            return degrees * (Math.PI / 180);
        }
        public double radians2degrees(double radians)
        {
            return radians * (180/Math.PI);
        }
        public double calculateA(double[] AB,double Phi_m)
        {
            double A=0;
            for (int i = 0; i < AB.Length; i++)
            {
                A += AB[i] * Math.Pow(Phi_m, i);
            }
            return A;
        }
        
        public List<statelite_coordinate> StateliteList { get; set; }
        public List<TandD> TandD_list = new List<TandD>();
        public double B_p = 30.0;
        public double L_p = 114.0;
        public double P_X = -2225669.7744;
        public double P_Y = 4998936.1598;
        public double P_Z = 3265908.9678;
        private double sinBp, cosBp, sinLp, cosLp;
        public double A1=5e-9, A2, A3=50400, A4;
        double T = 38700;
        double t;
        public double[] Alpha = { 0.1397e-7, -0.7451e-8, -0.5960e-7, 0.1192e-6 };
        public double[] Beta = { 0.1270e6, -0.1966e6, 0.6554e5, 0.2621e6 };
        public List<EandA> calculate_EandA(List<statelite_coordinate> StateliteList)
        {
            double Bp_rad = degrees2radians(B_p);
            double Lp_rad = degrees2radians(L_p);


            sinBp = Math.Sin(Bp_rad);
            cosBp = Math.Cos(Bp_rad);
            sinLp = Math.Sin(Lp_rad);
            cosLp = Math.Cos(Lp_rad);

            var matrixA = Matrix<double>.Build.DenseOfArray(new double[,]
            {         
            { -sinBp * cosLp, -sinBp * sinLp, cosBp },
            { -sinLp, cosLp, 0 },
            { cosBp * cosLp, cosBp * sinLp, sinBp }
            });


            var matrixB = Matrix<double>.Build.DenseOfArray(new double[,]
            {
            { P_X }, { P_Y }, { P_Z }
            });
            //计算卫星S的高度角和方位角
            List<EandA> EandA_list = new List<EandA>();
            foreach (var state in StateliteList)
            {
                EandA eandA = new EandA();
                var matrixC = Matrix<double>.Build.DenseOfArray(new double[,]
                {
                { state.X }, { state.Y }, { state.Z }
                });

                var matrixD = matrixC - matrixB;
                var matrixE = matrixA * matrixD;

                double X = matrixE[0, 0];
                double Y = matrixE[1, 0];
                double Z = matrixE[2, 0];

                double A = Math.Atan2(Y,X);
                A = radians2degrees(A);
                if (A < 0)
                {
                    A += 360.0;
                }
                double E = Math.Atan2(Z, Math.Sqrt(X * X + Y * Y));                

                eandA.A = A;
                eandA.E = radians2degrees(E);
                
                EandA_list.Add(eandA);
            }
            return EandA_list;
        }

       
        public List<TandD> calculate_DandT(List <EandA> EandA_list_)
        {
            List<IP> IP_list=new List<IP>();
            EandA_list_ = calculate_EandA(StateliteList);
            double R = 6371.3;
            double H = 350.0;
            //计算穿刺点的地磁纬度
            for (int i = 0; i < EandA_list_.Count;i++)
            {
                double E_ = EandA_list_[i].E;
                double A_ = EandA_list_[i].A;
                IP iP = new IP();
                iP.Psi = 0.0137 / (E_ + 0.11) - 0.022;

                iP.Phi = degrees2radians( B_p) + iP.Psi * Math.Cos(A_);
                if (iP.Phi > 0.416)
                {
                    iP.Phi = 0.416;
                }
                else if (iP.Phi < -0.416)
                {
                    iP.Phi = -0.416;
                }
                iP.Lambda = degrees2radians(L_p) + iP.Psi * Math.Sin(A_) / Math.Cos(iP.Phi);
                iP.Phi_m = iP.Phi + 0.064 * Math.Cos(iP.Lambda - 1.617);
                IP_list.Add(iP);
            }

            for (int i = 0; i < IP_list.Count; i++)
            {
                double Tion = 0, Dion = 0;
                A2 = calculateA(Alpha, IP_list[i].Phi_m);
                if (A2 < 0)
                {
                    A2 = 0;
                }
                A4 = calculateA(Beta, IP_list[i].Phi_m);
                if (A4 < 72000)
                {
                    A4 = 72000;
                }
                t = 43200*IP_list[i].Lambda + T;
                if (t >= 86400)
                {
                    t -= 86400;
                }
                else if (t < 0)
                {
                    t += 86400;
                }
                double X = 2 * Math.PI * (t - A3) / A4;
                double F = 1 + 16 * Math.Pow((0.53 - EandA_list_[i].E), 3);
                if (EandA_list_[i].E < 0)
                {
                    Tion = 0;
                }
                else
                {
                    if (Math.Abs(X) < 1.57)
                    {
                        
                        Tion = (A1 + A2 *Math.Cos( X) )* F;
                    }
                    else
                    {
                        Tion = A1 * F;
                    }
                }
                

                Dion = Tion * 299792458;
                TandD tandD = new TandD();
                
                tandD.Tion = Tion;
                tandD.Dion = Dion;
                
                TandD_list.Add(tandD);
            }



            return TandD_list;
        }
            
        
    }
}
    
