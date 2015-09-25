using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using 模拟三层.Model;

namespace 模拟三层.DAL
{

    /// <summary>
    /// TblSeat的数据层
    /// </summary>
    public class TbSeatDal
    {

        /// <summary>
        /// 数据层:登入,返回ExecuteScalar的返回值
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="psw">密码</param>
        /// <returns></returns>
        public int Login(string username, string psw)
        {
            string sql = "select COUNT(*) from T_Seats where CC_LoginId=@uid and CC_LoginPassword=@pwd";
            SqlParameter[] pas = new SqlParameter[]{
                new SqlParameter("@uid",username),
                new SqlParameter("@pwd",psw)
            };
            return (int)SqlHelper.ExecuteScalar(sql, System.Data.CommandType.Text, pas);
        }


        /// <summary>
        /// 根据用户名获得用户信息
        /// </summary>
        /// <param name="loginId">用户名</param>
        /// <returns>UserMsg</returns>
        public UserMsg GetUeserBaseMsgByLoginId(string loginId)
        {
            UserMsg um = null;
            string sql = "select CC_AutoID,CC_LoginPassword,CC_UserName from T_Seats where CC_LoginId=@uid";
            using (SqlDataReader reader=SqlHelper.ExecuteReader(sql, System.Data.CommandType.Text,new SqlParameter("@uid",loginId)))
            {
                //如果用用户名获得了数据,才把um实例化
                if (reader.HasRows)
                {
                    um = new UserMsg();
                    if (reader.Read())
                    {
                        um.AutoId = reader.GetInt32(0);
                        um.LoginId = loginId;//用传入值赋值
                        um.Psw = reader.GetString(1);
                        um.UserName = reader.GetString(2);
                    }
                }
            }
            return um;
        }


        /// <summary>
        /// 检查旧密码是否正确
        /// </summary>
        /// <param name="autoid">用户信息的主键id</param>
        /// <returns></returns>
        public int CheckOldPsw(string oldPsw,int autoId)
        {
            string sql = "select Count(*) from T_Seats where CC_AutoId=@autoid and CC_LoginPassword=@oldPsw";
            SqlParameter[] pas = new SqlParameter[]{
                new SqlParameter("@autoid",autoId),
                new SqlParameter("@oldPsw",oldPsw)
            };
            return (int)SqlHelper.ExecuteScalar(sql, System.Data.CommandType.Text, pas);
             
        }


        /// <summary>
        /// 根据用户信息主键id和传入密码,修改密码
        /// </summary>
        /// <param name="autoid">用户信息的主键id</param>
        /// <param name="newpsw">新密码</param>
        /// <returns></returns>
        public int UpdatePsw(int autoid,string newpsw)
        {
            string sql = "update T_Seats set CC_LoginPassword=@psw where CC_AutoId=@autoid";
            SqlParameter[] pas = new SqlParameter[]{
                new SqlParameter("@psw",newpsw),
                new SqlParameter("@autoid",autoid)
            };
            return SqlHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text, pas);
        }
        
    }
}
