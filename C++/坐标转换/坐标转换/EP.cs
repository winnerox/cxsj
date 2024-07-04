using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 坐标转换
{
    public class EP:Ellipsoid_parameters
    {
        public double a { set; get; }
        public double f{ set; get; }
        public double L0 { set; get; }
        public double e2 { set; get; }
        public EP()
        {
            a = 6378137.000;
            f = 1/298.3;
            L0 = 111;
            e2 = 2 * f - f * f;
        }

    }
}
