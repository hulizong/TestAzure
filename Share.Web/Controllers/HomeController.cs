using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Common;
using Microsoft.AspNetCore.Mvc;

namespace Share.Web.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index(int type=0)
        {

            //SendHelper.Send();
            if (type==1)
            {
                ViewBag.loginMessage = "请先登录!";
            }
            Login logins = new Login();
            if (isLogin)
            {
                logins = login;
            }
            // var Id = userId;
            ViewBag.timeMessage = Common.GetTimeMessage();
            return View(logins);
        }

    }
}