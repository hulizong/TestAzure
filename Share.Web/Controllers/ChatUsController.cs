using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Share.Web.Controllers
{
    public class ChatUsController : BaseController
    {
        public IActionResult Index()
        {
            if (!isLogin)
            {
                return Redirect("/Home/Index?type=1");
            }
            Login logins = new Login();
            if (isLogin)
            {
                logins = login;
            }
            return View(logins);
        }
    }
}