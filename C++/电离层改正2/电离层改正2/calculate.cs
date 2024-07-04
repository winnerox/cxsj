using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;
namespace 电离层改正2
{
    class calculate
    {
        Myfoundations Myfoundations = new Myfoundations();
        //A4 A2的计算
        public double calculateA(double[] AB, double Phi_m)
        {
            double A = 0;
            for (int i = 0; i < AB.Length; i++)
            {
                A += AB[i] * Math.Pow(Phi_m, i);
            }
            return A;
        }
        //方位角和高度角的计算
        public List<EandA> Eand_calculate(List<satellite_coordinate> satellites)
        {
            List<EandA> EandAs = new List<EandA>();

            double B_p = Myfoundations.degrees2radians(30);
            double L_p = Myfoundations.degrees2radians(114);
            double P_X = -2225669.7744;
            double P_Y = 4998936.1598;
            double P_Z = 3265908.9678;
            double sinBp = Math.Sin(B_p), cosBp = Math.Cos(B_p), sinLp = Math.Sin(L_p), cosLp = Math.Cos(L_p);

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

            foreach (var satellite in satellites)
            {              
                var matrixC = Matrix<double>.Build.DenseOfArray(new double[,]
                {
                { satellite.X }, { satellite.Y }, { satellite.Z }
                });

                var matrixD = matrixC - matrixB;
                var matrixE = matrixA * matrixD;

                double X = matrixE[0, 0];
                double Y = matrixE[1, 0];
                double Z = matrixE[2, 0];

                double A = Math.Atan2(Y, X);
                A = Myfoundations.radians2degrees(A);
                if (A < 0)
                {
                    A += 360.0;
                }

                double E = Myfoundations.radians2degrees(Math.Atan2(Z, Math.Sqrt(X * X + Y * Y)));

                EandA eanda = new EandA(E, A);
                EandAs.Add(eanda);

            }
            return EandAs;
        }
        //地磁纬度计算
        public List<IP> Geomagnetic_latitude_calculate(List<EandA> EandAs)
        {
            List<IP> IPs = new List<IP>();

            double B_p = Myfoundations.degrees2radians(30);
            double L_p = Myfoundations.degrees2radians(114);
            List<double> Geomagnetic_latitudes = new List<double>();
            foreach(var EandA in EandAs)
            {
                double Psi= 0.0137 / ((Myfoundations.degrees2radians(EandA.E)/Math.PI) + 0.11) - 0.022;
                double Phi_IP = B_p/Math.PI + Psi * Math.Cos(EandA.A);
                if (Phi_IP > 0.416) Phi_IP = 0.416;
                if (Phi_IP < -0.416) Phi_IP = -0.416;
                double Lambda_IP = L_p/Math.PI + Psi * Math.Sin(EandA.A) / Math.Cos(Phi_IP*Math.PI);
                double Phi_m = Phi_IP + 0.064 * Math.Cos((Lambda_IP - 1.617)* Math.PI);
                IP ip = new IP(Phi_IP, Lambda_IP, Phi_m);
                IPs.Add(ip);
            }
            return IPs;
        }
        //延迟量计算
        public List<delay> delay_calculate(List<IP> IPs, List<EandA> EandAs)
        {
            List<delay> delays = new List<delay>();
            double[] Alpha = { 0.1397e-7, -0.7451e-8, -0.5960e-7, 0.1192e-6 };
            double[] Beta = { 0.1270e6, -0.1966e6, 0.6554e5, 0.2621e6 };
            double T = 38700;
            double A1 = 5e-9;
            double A3 = 50400.0;
            double c = 299792458.0;

            for (int i = 0; i < EandAs.Count; i++)
            {
                double t = 43200 * IPs[i].Lambda_IP + T;
                if (t < 0) t += 86400;
                if (t > 86400) t -= 86400;

                double Phi_m = IPs[i].Phi_m;
                double E = EandAs[i].E/180.0; 
                double A2 = Alpha[0] + Alpha[1] * Phi_m + Alpha[2] * Phi_m * Phi_m + Alpha[3] * Math.Pow(Phi_m, 3);
                if (A2 < 0) A2 = 0;
                double A4 = Beta[0] + Beta[1] * Phi_m + Beta[2] * Phi_m * Phi_m + Beta[3] * Math.Pow(Phi_m, 3);
                if (A4 < 72000) A4 = 72000;

                double F = 1 + 16 * Math.Pow(0.53 - E, 3);
                double judge = Math.Abs(2 * Math.PI * (t - A3) / A4);
                double Tion,Dion;

                if (EandAs[i].E < 0)
                {
                    Tion = 0;
                }
                else
                {
                    if (judge < 1.57)
                    {

                        Tion = F * (A1 + A2 * (1 - judge * judge / 2 + judge * judge * judge * judge / 24));
                    }
                    else
                    {
                        Tion = A1 * F;
                    }
                }

                Dion = Tion * c;
                delay delay = new delay(Tion, Dion);
                delays.Add(delay);
            }

            return delays;
        }


    }
}
