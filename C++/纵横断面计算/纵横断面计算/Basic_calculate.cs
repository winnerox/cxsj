using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace 纵横断面计算
{
    internal class Basic_calculate
    {
        public double distance_calculate(point A,point B)
        {
            return Math.Sqrt(Math.Pow(A.X - B.X, 2) + Math.Pow(A.Y - B.Y, 2));
        }
        public double calculate_Azimuth(point A,point B)
        {
            geo geo = new geo();
            double delta_Y = B.Y - A.Y;
            double delta_X= B.X - A.X;
            double thita=Math.Atan(delta_Y / delta_X);
            if (delta_X < 0 && delta_Y > 0)
            {
                thita = -1 * (thita + Math.PI);
            }
            else if (delta_X < 0 && delta_Y < 0)
            {
                thita += Math.PI;
            }
            else if (delta_X < 0 && delta_Y > 0)
            {
                thita = -1 * (thita + 2 * Math.PI);
            }
            return geo.Rad2Dms(thita);
        }


        public List<Tuple<point,double>> calculate_PElevation(List<point> points)
        {
            point P_point = points.FirstOrDefault(p => p.name == "K1");

            List<Tuple<point, double>> distanceList = new List<Tuple<point, double>>();

            foreach (var point in points)
            {
                if (point.name != "K1")
                {
                    double distance = distance_calculate(P_point, point);
                    if (distance > 0) // 确保距离不为零
                    {
                        distanceList.Add(new Tuple<point, double>(point, distance));
                    }
                }
            }

            var nearestPoints = distanceList.OrderBy(d => d.Item2).Take(5).ToList();
            return nearestPoints;
        }
        public double area_calculate(point A, point B)
        {
            double area;
            double delta_L=distance_calculate(A,B);
            area=delta_L*(A.Z+B.Z-20.0)/2;
            return area;
        }
        //point P_point = new point();
        //double distance;
        //List<double> distance_list= new List<double>();
        //List<double> distanace_list_= new List<double>();
        //List<point> Qpoints_list= new List<point>();
        //for (int i = 2; i < points.Count; i++)
        //{

        //    if (points[i].name == "K1")
        //    {
        //        P_point = points[i];
        //    }
        //    distance = distance_calculate(P_point, points[i]);
        //    distance_list.Add(distance);
        //    distanace_list_.Add(distance);                         
        //}
        //distance_list.Sort();
        //for (int i = 0; i < 5; i++)
        //{
        //    for (int j = 0; j< distanace_list_.Count; j++)
        //    {
        //        if (distance_list[i] == distanace_list_[j])
        //        {
        //            Qpoints_list.Add(points[j]);
        //        }
        //    }
        //}
        //double result1 = 0, result2 = 0;
        //for(int i=0; i < 5; i++)
        //{
        //    result1 += Qpoints_list[i].Z / distance_list[i];
        //    result2+=1/ distance_list[i];
        //}


        //return result1 / result2;
    }
    
}
