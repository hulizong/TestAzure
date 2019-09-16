using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;
using Service.Admin;
using Share.Admin.Models;
using static Common.Common.LoginActionFilter;

namespace Share.Admin.Controllers
{

    public class HomeController : BaseController
    {
        [NoPermission]
        public IActionResult Index()
        {
            Manager model = GetAdminInfo();
            ViewBag.name = model.Name;
            ViewBag.id = model.Id;

            return View();
        }

      
    }
}
