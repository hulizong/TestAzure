using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Admin.Login;
using Web.Common;
using Web.Enums;
using static Common.Common.LoginActionFilter;

namespace Share.Admin.Controllers
{ 
    [ApiController]
    public class CheckPowersController : BaseController
    {
        [NoPermission]
        [HttpPost,Route("api/CheckPowers/IsPower")]
        public async Task<Response> IsPower(IsPowerIng Result)
        {
            Response response = new Response
            {
                code = Convert.ToInt32(StatusEnum.Failed)
            };
            response= await CheckPower.IsHavePower(Result, Id);

            return response;
        } 
    }
}