using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc; 

namespace Share.Web.Controllers
{
    public class AlbumController : BaseController
    {
       
        public IActionResult Index()
        {
            if (!isLogin)
            {
                return Redirect("/Login/Index");
            }
            Login logins = new Login();
            if (isLogin)
            {
                logins = login;
            }
            return View(logins); 
        }
        /// <summary>
        /// 查询对应相册中图片
        /// </summary>
        /// <returns></returns>
        public IActionResult Photo(int Id)
        {
            Login logins = new Login();
            if (isLogin)
            {
                logins = login;
            }
            return View(logins);
        }

        
    }
}