using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 坐标转换
{

    public class Gauss1
    {
        D2R_R2D D2R= new D2R_R2D();
        geo geo=new geo();
        private readonly Ellipsoid_parameters _parameters;
        public Gauss1(Ellipsoid_parameters parameters)
        {
            _parameters = parameters;
        }
        double L0;
        public double a;
        public double e2;
        public double M0;
        public double Ac = 1.00502006762861;
        public double Bc = 0.00502006809907569;
        public double Cc = 4.70476640522634e-10;
        public double Dc = 6.14795892202409e-15;
        public double Ec = 7.74692902991714e-20;
        public double Fc = 9.54344405348190e-25;
        public double alpha, beta, gamma, delta, epsilon, zeta;
        public double W;
        public double n2;
        double t;
        double N;
        double M;
        double X;
        double p = 648000.0 / Math.PI;
        public(double x,double y) Gauss1_calculate(double B,double L)
        {
            double x, y;
            B = geo.Dms2Rad(B);
            e2 = _parameters.e2;
            a=_parameters.a;
            L0=_parameters.L0;
            //辅助计算公式
            W = Math.Sqrt(1 - e2 * Math.Sin(B) * Math.Sin(B));
            n2=(e2/1-e2)*Math.Cos(B)*Math.Cos(B);
            t=Math.Tan(B);
            //N,M,MO赋值
            N = a / W;
            M0 = a * (1 - e2);
            M = M0 / Math.Pow(W, 3);
            alpha = Ac * M0;
            beta = -1/2*Bc * M0;
            gamma=Cc * M0/4;
            delta = -1/6*Dc * M0;
            epsilon = Ec * M0/8;
            zeta =-1/10* Fc * M0;
            X = alpha * B + beta * Math.Sin(2 * B) + gamma * Math.Sin(4 * B) + delta * Math.Sin(6 * B) + epsilon * Math.Sin(8 * B) + zeta * Math.Sin(10 * B);
            double l = (L - L0)/p;
            //计算辅助量
            double a0 = X;
            double a1 = N * Math.Cos(B);
            double a2=1/2*N*Math.Cos(B)*Math.Cos(B)*t;
            double a3 = (1.0 / 6.0) * N * Math.Pow(Math.Cos(B),3) * (1 - t * t + n2);
            double a4 = (1.0 / 24.0) * N * Math.Pow(Math.Cos(B), 4) * (5 - t * t + 9 * n2 + 4 * n2*n2) * t;
            double a5 = (1.0 / 120.0) * N * Math.Pow(Math.Cos(B), 5) * (5 - 18 * t * t + t * t * t * t + 14 * n2 - 58 * n2 * t * t);
            double a6 = (1.0 / 720.0) * N * Math.Pow(Math.Cos(B), 6) * (61 - 58 * t * t + t * t * t * t + 270 * n2 - 330 * n2 * t * t)*t;
            x = a0*Math.Pow(l, 0) + a2 * Math.Pow(l, 2) + a4 * Math.Pow(l, 4) + a6 * Math.Pow(l, 6);
            y=a1*l+a3 * Math.Pow(l,3)+a5 * Math.Pow(l,5);
            //y = y + 500000;
            return (x, y);
        }
    }
}
