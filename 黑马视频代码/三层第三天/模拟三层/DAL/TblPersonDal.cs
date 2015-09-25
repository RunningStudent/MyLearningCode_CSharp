using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace 模拟三层.DAL
{
    public class TblPersonDal
    {
        //处理年龄的数据层方法
        public int AddAge(int id)
        {
            string sql = "update TblPerson set age=age+1 where autoId=@id";
            return SqlHelper.ExecuteNonQuery(sql,CommandType.Text, new SqlParameter("@id", id));
        }
    }
}
