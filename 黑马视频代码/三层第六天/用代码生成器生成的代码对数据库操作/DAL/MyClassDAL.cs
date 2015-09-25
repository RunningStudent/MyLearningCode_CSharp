//============================================================
//http://net.itcast.cn author:yangzhongke
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using 用代码生成器生成的代码对数据库操作.Model;

namespace 用代码生成器生成的代码对数据库操作.DAL
{
	public partial class MyClassDAL
	{
        public MyClass Add
			(MyClass myClass)
		{
				string sql ="INSERT INTO MyClass (className)  output inserted.classId VALUES (@className)";
				SqlParameter[] para = new SqlParameter[]
					{
						new SqlParameter("@className", ToDBValue(myClass.ClassName)),
					};
					
				int newId = (int)SqlHelper.ExecuteScalar(sql, para);
				return GetByClassId(newId);
		}

        public int DeleteByClassId(int classId)
		{
            string sql = "DELETE MyClass WHERE ClassId = @ClassId";

           SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@classId", classId)
			};
		
            return SqlHelper.ExecuteNonQuery(sql, para);
		}
		
				
        public int Update(MyClass myClass)
        {
            string sql =
                "UPDATE MyClass " +
                "SET " +
			" className = @className" 
               
            +" WHERE classId = @classId";


			SqlParameter[] para = new SqlParameter[]
			{
				new SqlParameter("@classId", myClass.ClassId)
					,new SqlParameter("@ClassName", ToDBValue(myClass.ClassName))
			};

			return SqlHelper.ExecuteNonQuery(sql, para);
        }		
		
        public MyClass GetByClassId(int classId)
        {
            string sql = "SELECT * FROM MyClass WHERE ClassId = @ClassId";
            using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql, new SqlParameter("@ClassId", classId)))
			{
				if (reader.Read())
				{
					return ToModel(reader);
				}
				else
				{
					return null;
				}
       		}
        }
		
		public MyClass ToModel(SqlDataReader reader)
		{
			MyClass myClass = new MyClass();

			myClass.ClassId = (int)ToModelValue(reader,"classId");
			myClass.ClassName = (string)ToModelValue(reader,"className");
			return myClass;
		}
		
		public int GetTotalCount()
		{
			string sql = "SELECT count(*) FROM MyClass";
			return (int)SqlHelper.ExecuteScalar(sql);
		}
		
		public IEnumerable<MyClass> GetPagedData(int minrownum,int maxrownum)
		{
			var list = new List<MyClass>();
			string sql = "SELECT * from(SELECT *,row_number() over(order by classId) rownum FROM MyClass) t where rownum>=@minrownum and rownum<=@maxrownum";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql,
				new SqlParameter("@minrownum",minrownum),
				new SqlParameter("@maxrownum",maxrownum)))
			{
				while(reader.Read())
				{
					list.Add(ToModel(reader));
				}				
			}
			return list;
		}
		
		public IEnumerable<MyClass> GetAll()
		{
			var list = new List<MyClass>();
			string sql = "SELECT * FROM MyClass";
			using(SqlDataReader reader = SqlHelper.ExecuteDataReader(sql))
			{
				while(reader.Read())
				{
					list.Add(ToModel(reader));
				}				
			}
			return list;
		}
		
		public object ToDBValue(object value)
		{
			if(value==null)
			{
				return DBNull.Value;
			}
			else
			{
				return value;
			}
		}
		
		public object ToModelValue(SqlDataReader reader,string columnName)
		{
			if(reader.IsDBNull(reader.GetOrdinal(columnName)))
			{
				return null;
			}
			else
			{
				return reader[columnName];
			}
		}
	}
}
