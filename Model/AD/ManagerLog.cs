using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ManagerLog
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
        /// 用户名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 操作类型
        /// </summary>
        public string ActionType { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 登录ip
        /// </summary>
        public string UserIp { get; set; }
        /// <summary>
        /// 登录时间
        /// </summary>
        public DateTime AddTime { get; set; }
    }
}
