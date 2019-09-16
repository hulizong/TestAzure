using Common.Enums;
using Model;
using System;
using System.Collections.Generic;
using System.Text;
using Web.Common;
using Web.DBHelper;
using Web.Enums;

namespace Service.Admin
{
    /// <summary>
    /// 用户登录操作类
    /// </summary>
    public class LoginService
    {
        #region sql
        /// <summary>
        /// 查询管理员信息by_Account
        /// </summary>
        public static string get_admin_by_username = @"select * from [Manager] where Account=@Account";
        #endregion

        #region 业务逻辑处理

        /// <summary>
        /// @ming 后台登录逻辑
        /// </summary>
        /// <param name="userName">账号</param>
        /// <param name="passWord">加密密码</param>
        /// <returns></returns>
        public static Response LoginAct(string userName, string passWord)
        {
            var res = new Response()
            {
                code = Convert.ToInt32(StatusEnum.Failed)
            };
            //获取管理信息
            Manager managerMode = SqlDapperHelper.ReturnT<Manager>(get_admin_by_username, new { Account = userName });
            if (managerMode != null)
            {
                //状态确定以后，进行状态判断

                //密码比对
                if (passWord == managerMode.Password)
                {
                    //缓存信息
                    CacheHelper.SetAbsolute("admin", managerMode, 10 * 60);
                    //记录日志
                    ManagerLog adminLogModel = new ManagerLog()
                    {
                        Name = managerMode.Name,
                        UserId = managerMode.UserId,
                        ActionType = OperationTypeEnum.Login.ToString(),
                        UserIp ="127.0.0.1",
                        AddTime = DateTime.Now,
                        Remark = ""
                    };
                    if (SqlDapperHelper.Insert(adminLogModel) > 0)
                    {
                        res.code = Convert.ToInt32(StatusEnum.Succeed);
                        res.msg = "登录成功！";
                        res.url = "../home/index";
                    }
                }
                else
                {
                    res.msg = "用户名或密码错误!";
                }
            }
            else {
                res.msg = "用户名或密码错误!";
            }
            return res;
        }

        #endregion
    }
}
