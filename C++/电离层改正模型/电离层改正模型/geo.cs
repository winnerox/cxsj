using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 电离层改正模型
{
    public class geo

    {
        public static string Rad2Str(double rad)//弧度转化为角度字符串
        {
            string str = "";
            double d = rad / Math.PI * 180;
            string sign = "";
            if (d < 0)
            {
                sign = "-";
            }
            d = Math.Abs(d);
            double dd, mm, ss;
            dd = Math.Floor(d);//舍弃小数，保留整数，度。
            mm = Math.Floor((d - dd) * 60.0);//分
            ss = (d - dd - mm / 60.0) * 3600.0;//string.Format("{0:00}", mm)
            str = sign.ToString() + dd.ToString() + "°" + mm.ToString() + "′" + ss.ToString("f4") + "″";
            return str;
        }

        public static double Dms2Rad(double dms)//度分秒格式转化为弧度格式
        {
            int degrees = (int)dms;
            double fractionalPart = dms - degrees;

            // 分和秒
            double mmssssss = fractionalPart * 100;
            int minutes = (int)mmssssss;
            double seconds = (mmssssss - minutes) * 100;

            // 将度、分、秒转换为十进制度
            double decimalDegrees = degrees + (minutes / 60.0) + (seconds / 3600.0);

            // 将十进制度转换为弧度
            double radians = decimalDegrees * (Math.PI / 180);

            return radians;
        }

        public static double Rad2Dms(double rad)
        {
            double dms = 0, sec = 0;
            int deg = 0, minu = 0;
            int sign = 1;
            if (rad < 0)
            {
                sign = -1;
                rad = -rad;
            }
            dms = rad / Math.PI * 180;
            deg = Convert.ToInt32(Math.Floor(dms));
            minu = Convert.ToInt32(Math.Floor((dms - deg) * 60.0));

            sec = (dms - deg - minu / 60.0) * 3600.0;
            dms = deg + minu / 100.0 + sec / 10000.0;
            dms = sign * dms;
            return dms;
        }
    }
}
