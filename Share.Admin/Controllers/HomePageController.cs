using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using static Common.Common.LoginActionFilter;

namespace Share.Admin.Controllers
{
    public class HomePageController : Controller
    {
        [NoPermission]
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
