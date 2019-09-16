using System;
using System.Collections.Generic;
using System.Text;

namespace Model.AD.Sys
{
    public  class Sys_PowerSet
    {
        public int Id { get; set; }
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
        public int CreateUserId { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
