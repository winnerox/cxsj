
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 纵横断面计算2
{
    class Calculate
    {
        double h;
        //距离计算
        public double distance_calculate(Point A,Point B)
        {
            return Math.Sqrt(Math.Pow(A.X - B.X, 2) + Math.Pow(A.Y - B.Y, 2));
        }
        //坐标方位角计算
        public double azimuth_calculate(Point A,Point B)
        {
            double delta_X = B.X - A.X;
            double delta_Y = B.Y - A.Y;
            double azimuth = Math.Atan2(delta_Y , delta_X);

            if (azimuth < 0)
            {
                azimuth = azimuth + 2*Math.PI;
            }
            //if (delta_X > 0 && delta_Y > 0)
            //{

            //}
            //if (delta_X < 0 && delta_Y > 0)
            //{
            //    azimuth = -azimuth + Math.PI;
            //}
            //else if (delta_X < 0 && delta_Y < 0)
            //{
            //    azimuth = azimuth + Math.PI;
            //}
            //else if (delta_X < 0 && delta_Y > 0)
            //{
            //    azimuth = -azimuth + 2*Math.PI;
            //}
            //else if (delta_X == 0 && delta_Y > 0)
            //{
            //    azimuth = Math.PI / 2;
            //}
            //else if (delta_X == 0 && delta_Y < 0)
            //{
            //    azimuth = Math.PI * 3/4;
            //}

            return azimuth;
        }
        //内插点P的高程值计算
        public double Interpolated_elevation_calculate(Point P,List<Point> points)
        {
            List<Tuple<Point,double>> distance_lists = new List<Tuple<Point, double>>();
            foreach(var point in points)
            {
                double distance = distance_calculate(P, point);
                if (distance > 0)
                {
                    distance_lists.Add(new Tuple<Point, double>(point, distance));
                }
            }
            var nearest_points = distance_lists.OrderBy(d => d.Item2).Take(5).ToList();
            double m1 = 0;
            double m2 = 0;
            for(int i = 0; i < 5; i++)
            {
                m1+= nearest_points[i].Item1.Z / nearest_points[i].Item2;
                m2+= 1 / nearest_points[i].Item2;
            }
            return m1/m2;
        }
        //断面面积计算
        public double cross_area_calculate(List<Point> points)
        {
            double h0 = 10;
            double sum_area = 0;
            for (int i = 0; i < points.Count-1; i++)
            {
                double area = 0;
                area = distance_calculate(points[i], points[i + 1]) * (points[i].Z + points[i + 1].Z - (2 * h0)) / 2;
                sum_area += area;
            }
            return sum_area;
        }
        //断面长度计算
        public double length_calculate(List<Point> points)
        {
            double lenth = 0;
            for (int i = 0; i < points.Count - 1; i++)
            {
                lenth += distance_calculate(points[i], points[i + 1]);
            }
                     
            return lenth;
        }
        //计算纵断面内插点的平面坐标
        public List<Point> coordinates_LS(List<Point> points)
        {
            Point K0 = points.Find(p => p.name == "K0");
            Point K1 = points.Find(p => p.name == "K1");
            Point K2 = points.Find(p => p.name == "K2");

            // 计算插值点的数量
            int interpolated_account = (int)Math.Floor(distance_calculate(K0, K2) / 10.000);
            int interpolated_account1 = (int)Math.Floor(distance_calculate(K0, K1) / 10.000);
            int interpolated_account2 = interpolated_account - interpolated_account1;

            List<Point> interpolated_points = new List<Point>();

            // 插值点在K0，K1上
            double azimuth01 = azimuth_calculate(K0, K1);
            interpolated_points.Add(K0);
            for (int i = 1; i <=interpolated_account1; i++)
            {
                double x = K0.X + i * 10.000 * Math.Cos(azimuth01);
                double y = K0.Y + i * 10.000 * Math.Sin(azimuth01);
                Point point = new Point($"V-{i}", x, y, 0);
                double z = Interpolated_elevation_calculate(point, points);
                point.Z = z;
                interpolated_points.Add(point);
            }

            // 插值点在K1，K2上
            interpolated_points.Add(K1);
            double azimuth12 = azimuth_calculate(K1, K2);
            double D0 = distance_calculate(K0, K1);
            for (int i = 1; i <= interpolated_account2; i++)
            {
                double x = K1.X + i * 10.000 * Math.Cos(azimuth12);
                double y = K1.Y + i * 10.000 * Math.Sin(azimuth12);
                Point point = new Point($"V-{interpolated_account1 + i}", x, y, 0);
                double z = Interpolated_elevation_calculate(point, points);
                point.Z = z;
                interpolated_points.Add(point);
            }

            interpolated_points.Add(K2);
            return interpolated_points;
        }   
        //计算横断面内插点的平面坐标
        public List<Point> coordinates_HS1(List<Point> points)
        {
            Point K0 = points.Find(p => p.name == "K0");
            Point K1 = points.Find(p => p.name == "K1");
            Point K2 = points.Find(p => p.name == "K2");
            double Xm = (K0.X + K1.X) / 2;
            double Ym = (K0.Y + K1.Y) / 2;
            double azimuth01 = azimuth_calculate(K0, K1);
            double azimuthM = azimuth01 + Math.PI / 2;
            List<Point> interpolated_points = new List<Point>();
            //过M点横断面的内插点
            for (int i = -5; i < 0; i++)
            {
                double x = Xm + i * 5.000 * Math.Cos(azimuthM);
                double y = Ym + i * 5.000 * Math.Sin(azimuthM);
                Point point = new Point($"C{i}", x, y, 0);
                double z = Interpolated_elevation_calculate(point, points);
                point.Z = z;
                interpolated_points.Add(point);
            }
            for (int i =1; i <6 ; i++)
            {
                double x = Xm + i * 5.000 * Math.Cos(azimuthM);
                double y = Ym + i * 5.000 * Math.Sin(azimuthM);
                Point point = new Point($"C{i}", x, y, 0);
                double z = Interpolated_elevation_calculate(point, points);
                point.Z = z;
                interpolated_points.Add(point);
            }

            return interpolated_points;
        }
        public List<Point> coordinates_HS2(List<Point> points)
        {
            Point K0 = points.Find(p => p.name == "K0");
            Point K1 = points.Find(p => p.name == "K1");
            Point K2 = points.Find(p => p.name == "K2");
            double Xn = (K1.X + K2.X) / 2;
            double Yn = (K1.Y + K2.Y) / 2;
            double azimuth12 = azimuth_calculate(K1, K2);
            double azimuthN = azimuth12 + Math.PI / 2;
            List<Point> interpolated_points = new List<Point>();
            //过N点横断面的内插点
            for (int i = -5; i < 0; i++)
            {
                double x = Xn + i * 5.000 * Math.Cos(azimuthN);
                double y = Yn + i * 5.000 * Math.Sin(azimuthN);
                Point point = new Point($"C{i}", x, y, 0);
                double z = Interpolated_elevation_calculate(point, points);
                point.Z = z;
                interpolated_points.Add(point);
            }
            for (int i = 1; i < 6; i++)
            {
                double x = Xn + i * 5.000 * Math.Cos(azimuthN);
                double y = Yn + i * 5.000 * Math.Sin(azimuthN);
                Point point = new Point($"C{i}", x, y, 0);
                double z = Interpolated_elevation_calculate(point, points);
                point.Z = z;
                interpolated_points.Add(point);
            }
            return interpolated_points;
        }     
    }
}