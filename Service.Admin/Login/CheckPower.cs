using Model.AD.Sys;
using Model.ADView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Common;
using Web.Common.LogHelper;
using Web.DBHelper;
using Web.Enums;
using static Common.Common.LoginActionFilter;

namespace Service.Admin.Login
{
  public  class CheckPower
    {
      
        public static async Task<Response> IsHavePower(IsPowerIng ResultMsg, int Id)
        {
            Response response = new Response
            {
                code = Convert.ToInt32(StatusEnum.Failed)
            };
            response.msg = "暂无权限";
            try
            {

                var list = await SqlDapperHelper.ReturnListTAsync<Role>("select SR.Id,SR.AdminId,SR.PowerSetId,SR.CreateTime,SP.ActionName,SP.ControllerNmae,SP.PowerName,SP.MenuId  from Sys_Role SR join Sys_PowerSet SP  on SR.PowerSetId=SP.Id  where SR.AdminId=@AdminId", new { AdminId = Id });

                var isHave = list.Any(x => x.ControllerNmae == ResultMsg.ControllerName && x.ActionName == ResultMsg.ActionName);
                if (isHave)
                {
                    response.code = Convert.ToInt32(StatusEnum.Succeed);
                    response.msg = "正常";
                }
                else
                {
                    response.code = Convert.ToInt32(StatusEnum.Error);
                    response.msg = "暂无权限";
                }
            }
            catch (Exception ex)
            {
                LogHelp.Error(ex);
            }
            return response;
        }
    }
}
