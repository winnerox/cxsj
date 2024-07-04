using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 大地线长度计算
{
    class Calculate
    {
        public double cos(double degree)
        {
            return Math.Cos(degree);
        }
        public double sin(double degree)
        {
            return Math.Sin(degree);
        }
        public static double DegreeToRadian(double degree)
        {
            return degree * (Math.PI / 180.0);
        }

        public double CalculateDistance(ellipsoid_elements ellipsoid_Elements,double B1, double L1, double B2, double L2)
        {
            double e2 = ellipsoid_Elements.e2;
            double e12= ellipsoid_Elements.e12;
            double w1 = Math.Sqrt(1 - e2 * Math.Pow(Math.Sin(B1), 2));
            double w2 = Math.Sqrt(1 - e2 * Math.Pow(Math.Sin(B2), 2));
            double Sin_u1 = Math.Sin(B1) * Math.Sqrt(1 - e2) / w1;
            double Sin_u2 = Math.Sin(B2) * Math.Sqrt(1 - e2) / w2;
            double Cos_u1 = Math.Cos(B1) / w1;
            double Cos_u2 = Math.Cos(B2) / w1;
            double a1 = Sin_u1 * Sin_u2;
            double a2 = Cos_u1 * Cos_u2;
            double b1 = Cos_u1 * Sin_u2;
            double b2 = Sin_u1 * Cos_u2;
            double L = L2 - L1;
            double p;
            double q;
            double A1;
            double delta=0;
            double delta1;
            double lambda=L+delta;
            double SinSigema, CosSigema, sigema;
            double A0;
            double x;
            double y;
            double sinA0;
            double cosA02;
            double SinSigema1;
            double alpha=0, beta=0, gamma = 0;
            double A=0, B=0, C = 0;
            double S;
            //PART1
            do
            {
                p = Cos_u2 * sin(lambda);
                q = b1 - b2 * cos(lambda);
                A1 = Math.Atan(p / q);
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
                else if (A1 > 360)
                {
                    A1 = A1 - 2 * Math.PI;
                }
                SinSigema = p * sin(A1) + q * cos(A1);
                CosSigema = a1 + a2 * cos(lambda);
                sigema = Math.Atan(SinSigema / CosSigema);
                if (CosSigema > 0)
                {
                    sigema = Math.Abs(sigema);
                }
                if (SinSigema < 0)
                {
                    sigema = Math.PI - Math.Abs(sigema);
                }
                sinA0 = Cos_u1 * sin(A1);
                cosA02 = (1 - sinA0 * sinA0);
                if (ellipsoid_Elements.option == 1)
                {
                    alpha = (33523299 - (28189 - 70 * cosA02) * cosA02) * 1e-10;
                    beta = (28189 - 94 * cosA02) * 1e-10;
                }
                else if (ellipsoid_Elements.option == 2)
                {
                    alpha = (33528130 - (28190 - 70 * cosA02) * cosA02) * 1e-10;
                    beta = (28190 - 93.4 * cosA02) * 1e-10;
                }
                else if (ellipsoid_Elements.option == 3)
                {
                    alpha = (33528130 - (28190 - 70 * cosA02) * cosA02) * 1e-10;
                    beta = (28190 - 93.4 * cosA02) * 1e-10;
                }
                x = 2 * a1 - cosA02 * CosSigema;
                delta1 = (alpha * sigema - beta * x * SinSigema) * sinA0;
                lambda = L + delta;
                if (Math.Abs(delta1 - delta) < 1e-12)
                    break;
                delta = delta1;

            }while (true);
            // PART2
            if (ellipsoid_Elements.option == 1)
            {
                A = 6356863.020 + (10708.949 - 13.474 * cosA02) * cosA02;
                B = 10708.938 - 17.956 * cosA02;
                C = 4.487;
            }
            else if (ellipsoid_Elements.option == 2)
            {
                A = 6356755.288 + (10710.341 - 13.534 * cosA02) * cosA02;
                B = 10710.342 - 18.046 * cosA02;
                C = 4.512;
            }
            else if (ellipsoid_Elements.option == 3)
            {
                A = 6356755.288 + (10710.341 - 13.534 * cosA02) * cosA02;
                B = 10710.342 - 18.046 * cosA02;
                C = 4.512;
            }
            y = (cosA02*cosA02 - 2 * x * x) * CosSigema;
            S = A * sigema + (B * x + C * y) * SinSigema;
            return S;
        }

    }
}

