using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Common
{
    public class Response<T>
    {
        /// <summary>
        /// 返回编码
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 数据
        /// </summary>
        public T data { get; set; }
        /// <summary>
        /// 提示语
        /// </summary>
        public string msg { get; set; }
        public string url { get; set; }
    }

    public class Response
    {
        /// <summary>
        /// 返回编码
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 提示语
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 路径
        /// </summary>
        public string url { get; set; }
    }


    public class IsPowerIng
    {
        public string ControllerName { get; set; }
        public string ActionName { get; set; } 
        public int code { get; set; }
        public int msg { get; set; }
    }
}
