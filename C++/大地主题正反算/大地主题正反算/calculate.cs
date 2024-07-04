using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 大地主题正反算
{
    class calculate
    {
        public static double Dms2Rad(double dms)
        {
            int degrees = (int)dms;
            double fractionalPart = dms - degrees;
            // 分和秒
            double mmssssss = fractionalPart * 100;
            int minutes = (int)mmssssss;
            double seconds = (mmssssss - minutes) * 100;

            // 将度、分、秒转换为十进制度
            double decimalDegrees = degrees + (minutes / 60.0) + (seconds / 3600.0);

            // 将十进制度转换为弧度
            double radians = decimalDegrees * (Math.PI / 180);
            return radians;
        }
        public double lenth_calculate(ellipsoid_elements ellipsoid_Elements,Point_P P1,Point_P P2)
        {
            double B1 = Dms2Rad(P1.B);
            double B2 = Dms2Rad(P2.B);
            double L1 = Dms2Rad(P1.L);
            double L2 = Dms2Rad(P2.L);
            double w1 = Math.Sqrt(1 - ellipsoid_Elements.e2 * Math.Pow(Math.Sin(B1), 2));
            double w2 = Math.Sqrt(1 - ellipsoid_Elements.e2 * Math.Pow(Math.Sin(B2), 2));
            double Sin_u1 = Math.Sin(B1) * Math.Sqrt(1 - ellipsoid_Elements.e2) / w1;
            double Sin_u2 = Math.Sin(B2) * Math.Sqrt(1 - ellipsoid_Elements.e2) / w2;
            double Cos_u1 = Math.Cos(B1) / w1;
            double Cos_u2 = Math.Cos(B2) / w1;
            double a1 = Sin_u1 * Sin_u2;
            double a2 = Cos_u1 * Cos_u2;
            double b1 = Cos_u1 * Sin_u2;
            double b2 = Sin_u1 * Cos_u2;
            double delta_L = L1 - L2;
            double SinSigema;
            double CosSigema;
            double sigema;
            double sinA0;
            double cosA02;
            double x;
            double delta1;
            double y;
            double S;
            double delta=0;
            double alpha = 0, beta = 0;
            double A = 0, B = 0, C = 0;
            double lambda = delta_L + delta;
            double p = Cos_u2 * Math.Sin(lambda);
            double q = b1 - b2 * Math.Cos(lambda);
            //计算大地方位角
            do
            {
                double A1 = Math.Atan(p / q);
                if (p > 0 && q > 0)
                {
                    A1 = Math.Abs(A1);
                }
                else if (p > 0 && q < 0)
                {
                    A1 = Math.PI - Math.Abs(A1);
                }
                else if (p < 0 && q < 0)
                {
                    A1 = Math.PI + Math.Abs(A1);
                }
                else
                {
                    A1 = 2 * Math.PI - Math.Abs(A1);
                }
                if (A1 < 0)
                {
                    A1 = A1 + 2 * Math.PI;
                }
                else if (A1 > 2 * Math.PI)
                {
                    A1 = A1 - 2 * Math.PI;
                }
                //
                SinSigema = p * Math.Sin(A1) + q * Math.Cos(A1);
                CosSigema = a1 + a2 * Math.Cos(lambda);
                sigema = Math.Atan(SinSigema / CosSigema);
                if (CosSigema > 0)
                {
                    sigema = Math.Abs(sigema);
                }
                if (SinSigema < 0)
                {
                    sigema = Math.PI - Math.Abs(sigema);
                }
                sinA0 = Cos_u1 * Math.Sin(A1);
                cosA02 = (1 - sinA0 * sinA0);

                if (ellipsoid_Elements.ellipsoid == "克拉索夫斯基")
                {
                    alpha = (33523299 - (28189 - 70 * cosA02) * cosA02) * 1e-10;
                    beta = (28189 - 94 * cosA02) * 1e-10;
                }
                else if (ellipsoid_Elements.ellipsoid == "IUGG1975")
                {
                    alpha = (33528130 - (28190 - 70 * cosA02) * cosA02) * 1e-10;
                    beta = (28190 - 93.4 * cosA02) * 1e-10;
                }
                else if (ellipsoid_Elements.ellipsoid == "CGCS2000")
                {
                    alpha = (33528130 - (28190 - 70 * cosA02) * cosA02) * 1e-10;
                    beta = (28190 - 93.4 * cosA02) * 1e-10;
                }

                x = 2 * a1 - cosA02 * CosSigema;
                delta1 = (alpha * sigema - beta * x * SinSigema) * sinA0;
                lambda = delta_L + delta;
                if (Math.Abs(delta1 - delta) < 1e-12)
                    break;
                delta = delta1;
            } while (true);
            
            if (ellipsoid_Elements.ellipsoid == "克拉索夫斯基")
            {
                A = 6356863.020 + (10708.949 - 13.474 * cosA02) * cosA02;
                B = 10708.938 - 17.956 * cosA02;
                C = 4.487;
            }
            else if (ellipsoid_Elements.ellipsoid == "IUGG1975")
            {
                A = 6356755.288 + (10710.341 - 13.534 * cosA02) * cosA02;
                B = 10710.342 - 18.046 * cosA02;
                C = 4.512;
            }
            else if (ellipsoid_Elements.ellipsoid == "CGCS2000")
            {
                A = 6356755.288 + (10710.341 - 13.534 * cosA02) * cosA02;
                B = 10710.342 - 18.046 * cosA02;
                C = 4.512;
            }
            y = (cosA02 * cosA02 - 2 * x * x) * CosSigema;
            S = A * sigema + (B * x + C * y) * SinSigema;
            return S;
        }
        
    }
}
