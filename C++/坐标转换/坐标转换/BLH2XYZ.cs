using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 坐标转换
{
    public class BLH2XYZ
    {
        geo geo=new geo();

        private readonly Ellipsoid_parameters _parameters;
        public BLH2XYZ(Ellipsoid_parameters parameters)
        {
            _parameters = parameters;
        }
        public double N;
        public double e2;
        public double a;
        public double W;
        public (double X, double Y, double Z) BLH2XYZ_calculate(double B, double L, double H)
        {
            B = geo.Dms2Rad(B);
            L = geo.Dms2Rad(L);
            e2 = _parameters.e2;
            a= _parameters.a;
            W = Math.Sqrt(1 - e2 * Math.Sin(B) * Math.Sin(B));
            N = a / W;
            double X, Y, Z;
            X = (N + H) * Math.Cos(B) * Math.Cos(L);
            Y = (N + H) * Math.Cos(B) * Math.Sin(L);
            Z=(N*(1-e2)+H)*Math.Sin(B);
            return (X, Y, Z);
        }
    }
}
