using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Share.Web.Controllers
{
    public class ArticleController : BaseController
    {
        public IActionResult Index()
        {
            Login logins = new Login();
            if (isLogin)
            {
                logins = login;
            }
            // var Id = userId;
            ViewBag.timeMessage = Common.GetTimeMessage();
            return View(logins);
        }
        
        public IActionResult Add()
        {
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