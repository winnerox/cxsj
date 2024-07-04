using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 坐标转换
{
    public interface Ellipsoid_parameters
    {
        double a { set; get; }
        double f { set; get; }
        double L0 { set; get; }
        double e2 { set; get; }
    }


}
