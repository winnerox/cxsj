using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace 纵横断面计算
{
    internal class LC_calculate
    {
        point_serch point_Serch=new point_serch();
        Basic_calculate basic_Calculate = new Basic_calculate();
        
        //纵断面长度计算
        public double lenth_calculate(List<point> points)
        {
            Basic_calculate basic_Calculate = new Basic_calculate();
            double lenth=0;
            for(int i = 0; i< 2; i++)
            {
                lenth += basic_Calculate.distance_calculate(point_Serch.Point_serch(points, $"k{i}"), point_Serch.Point_serch(points, $"k{i + 1}"));
            }
            return lenth;
        }
        
       //计算内插点的平面坐标
        public List<Tuple<P_point, double>> coordinate_calculate(List<point> points) 
        {
            List<Tuple<P_point, double>> P_points=new List<Tuple<P_point, double>>();
            point K0= new point();
            point K1= new point();
            point K2 = new point();
            K0 = point_Serch.Point_serch(points, "K0");
            K1 = point_Serch.Point_serch(points, "K1");
            K2 = point_Serch.Point_serch(points, "K2");
            
            //插值点在K0，K1直线上
            int points1=(int)basic_Calculate.distance_calculate(K0, K1)/10;
            double alpha01=basic_Calculate.calculate_Azimuth(K0, K1);
            for( int i = 0; i< points1; i++)
            {
                double elevation;
                P_point p_Point=new P_point();
                p_Point.x = K0.X + i * 10 * Math.Cos(alpha01);
                p_Point.y = K0.Y + i * 10 * Math.Sin(alpha01);
                elevation = point_Serch.IPE(p_Point, points);

                P_points.Add(new Tuple<P_point, double>(p_Point, elevation));
            }
            //插值点在K1，K2直线上
            int points2 = (int)basic_Calculate.distance_calculate(K1, K2) / 10;
            double alpha12 = basic_Calculate.calculate_Azimuth(K1, K2);
            for (int i = 0; i < points1; i++)
            {
                double elevation;
                P_point p_Point = new P_point();
                p_Point.x = K1.X + i * Math.Cos(alpha01);
                p_Point.y = K1.Y + i * Math.Sin(alpha01);
                elevation = point_Serch.IPE(p_Point, points);
                P_points.Add(new Tuple<P_point, double>(p_Point, elevation));

            }

            return P_points;
        }
        //计算纵断面面积
        public double LCarea_calculate(List<Tuple<P_point, double>> P_points)
        {
            double sum = 0;


            return 0;
        }

    }
}
