using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Common
{
    /// <summary>
    /// 公共方法类
    /// </summary>
    public class CommonHelper
    {
        private IHttpContextAccessor _accessor;
        public CommonHelper(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }
        /// <summary>
        /// 获取当前登录用户IP
        /// </summary>
        /// <returns></returns>
        public   string GetUserIp()
        {
            string userIP = "";
            try
            {
              
                    userIP = _accessor.HttpContext.Connection.RemoteIpAddress.ToString();
              
                return userIP;
            }
            catch { }

            return userIP;
            //return _accessor.HttpContext.Connection.RemoteIpAddress.ToString(); 
        }
    }
}
