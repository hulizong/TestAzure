using Model;
using System;
using System.Collections.Generic;
using System.Text;
using Web.DBHelper;

namespace Service
{
    /// <summary>
    /// @ming 用户登录service
    /// </summary>
    public class UserService
    {
        #region 公共sql
        /// <summary>
        /// 根据用户名或手机号查询用户信息
        /// </summary>
        public static string get_userinfo_by_name_or_phone = @"select * from [AU_User] where Phone=@name or Name=@name";
        #endregion

        #region 业务逻辑

        /// <summary>
        /// 根据用户名或手机号查询用户信息
        /// </summary>
        /// <param name="name">用户名或手机号</param>
        /// <returns></returns>
        public static AU_User GetUserInfoByNameOrPhone(string name)
        {
            AU_User userModel = SqlDapperHelper.ReturnT<AU_User>(get_userinfo_by_name_or_phone, new { Phone = name, Name = name });
            return userModel;
        }
        #endregion
    }
}
