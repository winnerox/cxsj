using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 坐标转换
{
    public class XYZ2BLH
    {
        D2R_R2D _R2D=new D2R_R2D();
        geo geo=new geo();
        private readonly Ellipsoid_parameters _parameters;
        public XYZ2BLH(Ellipsoid_parameters parameters)
        {
            _parameters = parameters;
        }
        public double e2;
        double N;
        double a, W;
        public (double B_, double L_, double H_) XYZ2BLH_calculate(double X, double Y, double Z)
        {
            e2 = _parameters.e2;
            a = _parameters.a;

            double B = Math.Atan2(Z, Math.Sqrt(X * X + Y * Y)); // 初始B值
            double B_prev;
            int iterations = 0;
            do
            {
                B_prev = B;
                W = Math.Sqrt(1 - e2 * Math.Sin(B) * Math.Sin(B));
                N = a / W;
                B = Math.Atan2(Z + N * e2 * Math.Sin(B), Math.Sqrt(X * X + Y * Y));
                iterations++;
            } while (Math.Abs(B - B_prev) > 1e-12 && iterations < 1000); // 迭代终止条件

            double L_ = geo.Rad2Dms(Math.Atan2(Y, X));
            double H_ = (Math.Sqrt(X * X + Y * Y) / Math.Cos(B)) - N;
            double B_ = geo.Rad2Dms(B);

            return (B_, L_, H_);
        }
    }
}
