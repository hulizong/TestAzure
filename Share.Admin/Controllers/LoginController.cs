using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;
using Newtonsoft.Json;
using Service.Admin;
using Web.Common;
using Web.Common.LogHelper;
using Web.Enums;
using static Common.Common.LoginActionFilter;

namespace Share.Admin.Controllers
{
    /// <summary>
    /// 后台登录控制器
    /// </summary>
    
    public class LoginController : Controller
    {
        /// <summary>
        /// @ming 后台登录页
        /// </summary>
        /// <returns></returns>
        [NoPermission]
        public IActionResult Index()
        {
            //判断是否已登录
            Manager model = CacheHelper.Get<Manager>("admin");
            if (model!=null)
            {
                return RedirectToAction("index", "home");
            }
            return View();
        }

        /// <summary>
        /// @ming 后台登录功能
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="passWord">密码</param>
        /// <returns></returns>
        [NoPermission]
        [HttpPost]
        public IActionResult LoginAct(string userName,string passWord)
        {
            var result = new Response()
            {
                code = Convert.ToInt32(StatusEnum.Failed)
            };
            try
            {
                if (String.IsNullOrWhiteSpace(userName) || String.IsNullOrWhiteSpace(passWord))
                {
                    result.msg = "用户名或密码错误!";
                    return Ok(result);
                }

                //验证码，后期需要则加上

                //密码加密
                passWord = Convert.ToBase64String(BaseController.AESEncrypt(JsonConvert.SerializeObject(passWord)));
                result = LoginService.LoginAct(userName, passWord);
            }
            catch (Exception ex)
            {
                result.code = Convert.ToInt32(StatusEnum.Error);
                result.msg = "内部请求出错";//内部请求出错
                LogHelp.Error(ex, ex.Message);
            }
            return Ok(result);
        }

        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns></returns>
        public IActionResult OutLoginAct()
        {
            CacheHelper.RemoveCache("admin");
            return Redirect("/Login/Index");
        }
    }
}
