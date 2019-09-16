using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Share.Web
{
    public class Common
    {
        public static string GetTimeMessage()
        {
            var timeMessage = "您好";
            var hour = DateTime.Now.Hour;

            if (hour >= 6 && hour <= 11)
            {
                timeMessage = "上午好";
            }
            if (hour > 11 && hour < 14)
            {
                timeMessage = "中午好";
            }
            if (hour >= 14 && hour < 18)
            {
                timeMessage = "下午好";
            }
            if (hour >= 18 && hour < 24)
            {
                timeMessage = "晚上好";
            }
            return timeMessage;
        }
    }
}
