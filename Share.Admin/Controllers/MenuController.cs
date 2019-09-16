using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;
using Service.Admin;
using static Common.Common.LoginActionFilter;

namespace Share.Admin.Controllers
{
    /// <summary>
    /// 后台导航菜单
    /// </summary>
    public class MenuController : BaseController
    {
        #region 菜单生成

        /// <summary>
        /// @ming 菜单查询
        /// </summary>
        /// <returns></returns> 
        [NoPermission]
        public JsonResult GetNavigationAct()
        {
            //获取用户登录信息
            Manager managerModel = GetAdminInfo();
            if (managerModel==null)
            {
                return null;
            }
            //查询导航数据
            string menuValue = "";//MenuService.GetMenuDate(managerModel.Id);
            //return Ok(menuValue);
            return Json(menuValue);
        }
        #endregion

        #region 菜单管理
        /// <summary>
        /// 菜单树形展示
        /// </summary>
        /// <returns></returns>
        public IActionResult MenuList()
        {

            return null;
        }
        #endregion
    }
}
