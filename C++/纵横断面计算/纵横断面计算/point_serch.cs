using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 纵横断面计算
{
    internal class point_serch
    {
        Basic_calculate basic_Calculate =new Basic_calculate();
        public point Point_serch(List<point> points,string name)
        {
            point point_ = new point();
            for (int i = 0; i < points.Count; i++)
            {
                if (name == points[i].name)
                {
                   
                    point_ = points[i];
                }
            }
            return point_;
        }
        public double IPE(P_point p_Point,List<point> points)
        {
            point p_Point_=new point("Point_p", p_Point.x, p_Point.y,0);
            List<Tuple<point, double>> distanceList = new List<Tuple<point, double>>();
            foreach (var point in points)
            {
                double distance = basic_Calculate.distance_calculate(p_Point_, point);
                if (distance > 0) // 确保距离不为零
                {
                    distanceList.Add(new Tuple<point, double>(point, distance));
                }
            }
            var nearestPoints = distanceList.OrderBy(d => d.Item2).Take(5).ToList();
            double result1 = 0, result2 = 0;
            foreach (var item in nearestPoints)
            {
                result1 += item.Item1.Z / item.Item2;
                result2 += 1 / item.Item2;
                string dataLine1 = $"name：{item.Item1.name}，distance:{item.Item2}";
            }
            double h = result1 / result2;
            return h;
        }

    }
}
