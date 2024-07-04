using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 坐标转换
{
    public class D2R_R2D
    {
        public double Degrees2radius(double degrees) 
        {
            return degrees * Math.PI / 180.0;
        }
        public double Radius2derees(double radius)
        {
            return radius * 180.0 / Math.PI;
        }

    }
}
