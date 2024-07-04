using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 大地线长度计算
{
    class data
    {
        public static double B_1;
        public static double B_2;
        public static double L_1;
        public static double L_2;
        public double ddmmssTorad(double dd)
        {
            double rad;
            double deg;
            double min;
            double sec;
            deg = (int)(dd);
            min = (int)((dd - deg) * 100);
            sec = dd * 10000 - deg * 10000 - min * 100;
            rad = (deg + min / 60.0 + sec / 3600.0) / 180.0 * Math.PI;
            return rad;
        }

        public void fuzhi(string[] line)
        {
            B_1 = ddmmssTorad(Convert.ToDouble(line[0].Split(' ')[0]));
            L_1 = ddmmssTorad(Convert.ToDouble(line[0].Split(' ')[1]));
            B_2 = ddmmssTorad(Convert.ToDouble(line[1].Split(' ')[0]));
            L_2 = ddmmssTorad(Convert.ToDouble(line[1].Split(' ')[1]));

        }
    }
}
