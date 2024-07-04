using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace 坐标转换
{
    public  class Gauss2
    {
        private readonly Ellipsoid_parameters _parameters;
        public Gauss2( Ellipsoid_parameters parameters)
        {
            _parameters = parameters;
        }
        D2R_R2D D2R_R2D= new D2R_R2D();
        double Bf, B0;
        double Nf,Mf,nf2,tf;
        double X, x;
        double M0;
        double a;
        double e2;
        double L0;
        public double Ac = 1.00502006762861;
        public double Bc = 0.00502006809907569;
        public double Cc = 4.70476640522634e-10;
        public double Dc = 6.14795892202409e-15;
        public double Ec = 7.74692902991714e-20;
        public double Fc = 9.54344405348190e-25;
        public double alpha, beta, gamma, delta, epsilon, zeta;
        double b0, b1, b2, b3, b4, b5, b6;
        double delta_;
        public (double B,double L) Gauss2_calculate(double x,double y)
        {
            double B, L;
            a = _parameters.a;
            e2= _parameters.e2;
            L0 = _parameters.L0;
            M0 = a * (1 - e2);
            //计算辅助量
            alpha = Ac * M0;
            beta = -1 / 2 * Bc * M0;
            gamma = Cc * M0 / 4;
            delta = -1 / 6 * Dc * M0;
            epsilon = Ec * M0 / 8;
            zeta = -1 / 10 * Fc * M0;
            //
            b0 = Bf;
            b1 = 1 / Nf * Math.Cos(D2R_R2D.Degrees2radius(Bf));
            b2 = -tf / 2 * Mf * Nf;
            b3=-b1*(1+2*tf*tf+nf2)/6*Nf*Nf;
            b4=-b2*(5+3*tf*tf+nf2-9*nf2*tf*tf)/12*Nf*Nf;
            b5=-b1*(5+28*tf*tf+24*tf*tf+6*nf2+8*nf2*tf*tf)/120*Math.Pow(Nf,4);
            b6=(61+90*tf*tf+45*Math.Pow(tf,4))/360* Math.Pow(Nf, 4);
            X = x;
            B0 = X / alpha;
            do
            {
                delta_ = beta * Math.Sin(2 * B0) + gamma * Math.Sin(4 * B0) + delta * Math.Sin(6 * B0) + epsilon * Math.Sin(8 * B0) + zeta * Math.Sin(10 * B0);
                Bf = (X - delta_) / alpha;
                if (Math.Abs(Bf - B0) <= 0.00000001)
                {
                    break;
                }
                B0 = Bf;
            } while (true);
            B = b0 + b2 * Math.Pow(y, 2) + b4 * Math.Pow(y, 4) + b6 * Math.Pow(y, 6);
            L = b1 * y + b3 * Math.Pow(y, 3) + b5 * Math.Pow(y, 5) + L0;
            return (B, L);
        }
    }
}
