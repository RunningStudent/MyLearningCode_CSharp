using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using fmLoadArea.Model;
using System.Data.SqlClient;

namespace fmLoadArea.DAL
{
    public class T_SeatsDal
    {

        /// <summary>
        /// 根据用户信息注册
        /// </summary>
        /// <param name="um"></param>
        /// <returns></returns>
        public int Register(UserMsg um)
        {
            //CC_AutoId,CC_LoginId,CC_LoginPassWord,CC_UserName,CC_ErrorTimes,CC_LockDateTime,CC_TestInt
            string sql = "insert into T_seats(CC_LoginId,CC_LoginPassWord,CC_UserName) values(@uid,@psw,@username)";
            SqlParameter[] pars = new SqlParameter[]{
                new SqlParameter("@uid",um.CC_LoginId),
                new SqlParameter("@psw",um.CC_LoginPassWord),
                new SqlParameter("@username",um.CC_UserName)
            };
            return SqlHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text, pars);
        }
    }
}
