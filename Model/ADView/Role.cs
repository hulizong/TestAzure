using Model.AD.Sys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ADView
{
    public class Role: Sys_Role
    {
        /// <summary>
        /// 菜单Id
        /// </summary>
        public int MenuId { get; set; }
        /// <summary>
        /// 权限名称
        /// </summary>
        public string PowerName { get; set; }
        /// <summary>
        /// 控制器名称
        /// </summary>
        public string ControllerNmae { get; set; }
        /// <summary>
        /// 方法名称
        /// </summary>
        public string ActionName { get; set; }
    }
}
