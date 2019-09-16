using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Web.Common;
using Web.Common.LogHelper;

namespace Common.Common
{
   public class LoginActionFilter: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var isDefined = false;
            var controllerActionDescriptor = filterContext.ActionDescriptor as ControllerActionDescriptor;
            if (controllerActionDescriptor != null)
            {
                isDefined = controllerActionDescriptor.MethodInfo.GetCustomAttributes(inherit: true)
                  .Any(a => a.GetType().Equals(typeof(NoPermission)));
            }
            if (isDefined) return;


            //if (string.IsNullOrWhiteSpace(filterContext.HttpContext.Request.Query["LoginInfo"].ToString()))
            //{
            //    var item = new ContentResult();
            //    item.Content = "没得权限";

            //    filterContext.Result = new RedirectResult("/Account/Login");
            //}
            if (string.IsNullOrWhiteSpace(controllerActionDescriptor.ControllerName)&&string.IsNullOrWhiteSpace(controllerActionDescriptor.ActionName))
            {
                return;
            }
            var reaData = new IsPowerIng()
            {
                ControllerName = controllerActionDescriptor.ControllerName,
                ActionName = controllerActionDescriptor.ActionName
            };

            var Result =Post<IsPowerIng, Response>("http://192.168.20.78:61555/", "api/CheckPowers/IsPower/", reaData).GetAwaiter().GetResult();
            if (Result.code!=1)
            {
                var item = new ContentResult();
                item.Content = "没得权限"; 
                filterContext.Result = new RedirectResult("/Login/Index");
            }
            base.OnActionExecuting(filterContext);
        }
        public class NoPermission : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                base.OnActionExecuting(filterContext);
            }

        }
        public static async Task<R> Post<T, R>(string host, string url, T entity)
        {
            var apiRect = default(R);
            try
            {
                HttpClient clientAuth = new HttpClient();
                string requestUrl = string.Format("{0}{1}", host, url);
                HttpResponseMessage response = await clientAuth.PostAsJsonAsync(requestUrl, entity);
                response.EnsureSuccessStatusCode();
                string rect = await response.Content.ReadAsStringAsync();
                apiRect = JsonConvert.DeserializeObject<R>(rect);
            }
            catch (Exception ex)
            {
                LogHelp.Error(ex);
            }
            return apiRect;
        }
    }
}
