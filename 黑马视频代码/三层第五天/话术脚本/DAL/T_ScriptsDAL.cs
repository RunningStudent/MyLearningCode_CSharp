using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using 话术脚本.Model;
using System.Data;
using System.Data.SqlClient;

namespace 话术脚本.DAL
{
    public class T_ScriptsDAL
    {


        /// <summary>
        /// 根据Id获取子节点
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Scripts> GetSonNodesById(int id)
        {
            List<Scripts> list = new List<Scripts>();
            string sql = "select * from T_Scripts where ScriptParentId=@id";
            using (SqlDataReader reader=SqlHelper.ExecuteReader(sql, System.Data.CommandType.Text,new SqlParameter("@id",id)))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Scripts s = new Scripts();
                        s.ID = reader.GetInt32(0);
                        s.Title = reader.GetString(1);
                        s.Msg = reader.GetString(2);
                        s.ParentId = reader.GetInt32(3);
                        list.Add(s);
                    }
                }
            }
            return list;
        }



        /// <summary>
        /// 根据节点Id获取Msg数据
        /// </summary>
        /// <param name="id">节点Id</param>
        /// <returns></returns>
        public object GetMsgById(int id)
        {
            string sql = "select ScriptMsg from T_Scripts where ScriptId=@id";
            return SqlHelper.ExecuteScalar(sql, CommandType.Text, new SqlParameter("@id", id));
        }


        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int Insert(Scripts s)
        {
            string sql = "insert into T_Scripts values(@title,@msg,@pid)";
            SqlParameter[]pas=new SqlParameter[]{
                new SqlParameter("@title",s.Title),
                new SqlParameter("@msg",s.Msg),
                new SqlParameter("@pid",s.ParentId)
            };

            return SqlHelper.ExecuteNonQuery(sql, CommandType.Text, pas);
        }


        

        /// <summary>
        /// 根据数据Id删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(int id)
        {
            string sql = "delete from T_Scripts where ScriptId=@id";
            return SqlHelper.ExecuteNonQuery(sql, CommandType.Text, new SqlParameter("@id", id));
        }


        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int Update(Scripts s)
        {
            string sql = "update T_Scripts set ScriptTitle=@title,ScriptMsg=@msg where ScriptId=@id";
            SqlParameter[] pas = new SqlParameter[]{
                new SqlParameter("@title",s.Title),
                new SqlParameter("@msg",s.Msg),
                new SqlParameter("@id",s.ID),
            };
            return SqlHelper.ExecuteNonQuery(sql, CommandType.Text, pas);
        }
    }
}
