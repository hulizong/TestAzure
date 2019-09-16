using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Model;
using Newtonsoft.Json;
using Service;
using Web.Common;
using Web.Common.LogHelper;
using Web.Enums;
using Web.RedisHelper;

namespace Share.Web.Controllers
{
    public class LoginController : Controller
    {
        /// <summary>
        /// 会从其他控制器跳转过来（需要登录的控制器，如果没有登录的话就会跳转这里）
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        { 
            ViewBag.timeMessage =Common.GetTimeMessage(); 
            return Redirect("/Home/Index"); 
        }
       

        /// <summary>
        /// @ming 登录操作
        /// </summary>
        /// <param name="loginInfo">登录实体</param>
        /// <returns></returns>
        public IActionResult LoginAct([FromForm] Login loginInfo)
        {

            var result = new Response<Login>()
            {
                code = Convert.ToInt32(StatusEnum.Failed)
            };
            result.url = "/Login/Index"; 
            try
            {
                #region 数据验证 （后期可改为模型验证）
                //非空
                if (String.IsNullOrWhiteSpace(loginInfo.Phone) && String.IsNullOrWhiteSpace(loginInfo.Name))
                {
                    result.msg = "请输入用户名或密码";
                    return Ok(result);
                }
                if (String.IsNullOrWhiteSpace(loginInfo.Password))
                {
                    result.msg = "请输入用户名或密码";
                    return Ok(result);
                }
                //防sql注入，后期补上
                #endregion
                //用户名查询


                //用户名查询用户信息
                AU_User userModel = UserService.GetUserInfoByNameOrPhone(loginInfo.Name);
                if (userModel == null)
                {
                    result.msg = "账号或密码错误";
                    return Ok(result);
                }
  
                var token =BaseController.EncodeText(JsonConvert.SerializeObject(userModel));
                //密码判断
                string passWord = Encoding.UTF8.GetString(BaseController.AESDecrypt(Convert.FromBase64String(userModel.Pwd)));
                passWord = passWord.Replace("\0", "").Trim();
                if (passWord != loginInfo.Password)
                {
                    result.msg = "账号或密码错误";
                    return Ok(result);
                }
                if (userModel.IsLogin==1)
                {
                    result.msg = "用户已登录";
                    return Ok(result);
                }
                //检查用户状态

                //加密存入缓存 
                //// CacheHelper.SetAbsolute("token",token,15*60);
                //HttpContext.Response.Cookies.Delete("tokens");
                RedisManager.redisHelp.SetValue(userModel.Name, JsonConvert.SerializeObject(userModel),20);
                HttpContext.Response.Cookies.Append("tokens", token);
                result.code = Convert.ToInt32(StatusEnum.Succeed);
                result.url = "/Login/Index";
                result.msg = "登录成功!";
                //是否需要返回登录成功后的实体
                return Ok(result);
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
        public IActionResult LoginOut( )
        {

            var result = new Response<Login>()
            {
                code = Convert.ToInt32(StatusEnum.Failed)
            };
            result.url = "/Home/Index";
            result.msg = "退出失败!";
            try
            {
                

                //检查用户状态

                //加密存入缓存 
                //// CacheHelper.SetAbsolute("token",token,15*60);
                //HttpContext.Response.Cookies.Delete("tokens");

                HttpContext.Response.Cookies.Delete("tokens");
                result.code = Convert.ToInt32(StatusEnum.Succeed);
                result.url = "/Home/Index";
                result.msg = "退出成功!";
                //是否需要返回登录成功后的实体
                return Ok(result);
            }
            catch (Exception ex)
            {
                result.code = Convert.ToInt32(StatusEnum.Error);
                result.msg = "内部请求出错";//内部请求出错
                LogHelp.Error(ex, ex.Message);
            }
            return Ok(result);
        }
    }
}
