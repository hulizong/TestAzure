using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// 管理员信息实体
    /// </summary>
    public class Manager
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 用户id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 账号
        /// </summary>
        public string  Account { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string  Name { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string  Password { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public int Sex { get; set; }

        /// <summary>
        /// 系统状态
        /// </summary>
        public int State { get; set; }

        /// <summary>
        /// 管理员状态
        /// </summary>
        public int Status { get; set; }
    }
}
