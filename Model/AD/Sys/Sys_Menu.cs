using System;
using System.Collections.Generic;
using System.Text;

namespace Model.AD.Sys
{
   public  class Sys_Menu
    {
        public int Id { get; set; }
        /// <summary>
        /// 菜单名称
        /// </summary>
        public string MenuName { get; set; }
        /// <summary>
        /// 菜单路径
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 图标路径
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// 父级id
        /// </summary>
        public int ParentId { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 是否展示 0 不展示  1展示
        /// </summary>
        public int IsShow { get; set; }
        public int CreateUserId { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
