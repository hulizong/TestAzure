using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// 用户信息类
    /// </summary>
    public class AU_User
    {
        /// <summary>
        /// 用户id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 用户手机号
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Pwd { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string  Name { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public int Sex { get; set; }
        /// <summary>
        /// 出生年月
        /// </summary>
        public DateTime Birthday { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 婚姻状况
        /// </summary>
        public string Married { get; set; }
        /// <summary>
        /// QQ号
        /// </summary>
        public string  QQ { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string  Mail { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int State { get; set; }
        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 真实名称
        /// </summary>
        public string RealName { get; set; }
        /// <summary>
        /// 介绍
        /// </summary>
        public string IntroduceAbout { get; set; }
        /// <summary>
        /// 对于的行业id   0未填写
        /// </summary>
        public int WorkIn { get; set; }
        /// <summary>
        /// 对应的学历id  0未填写
        /// </summary>
        public int EducationBackgroundId { get; set; }
        /// <summary>
        /// 是否认证   0 未认证   
        /// </summary>
        public int AuthenticationId { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string HeadImage { get; set; }
        /// <summary>
        /// 是否登录，1  登录  0未登录
        /// </summary>
        public int IsLogin { get; set; }
    }
}
