using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using System.Collections.Generic;//Please add references
namespace News.DAL
{
	/// <summary>
	/// 数据访问类:HKSJ_Main
	/// </summary>
	public partial class HKSJ_Main
	{
		public HKSJ_Main()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "HKSJ_Main"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from HKSJ_Main");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(News.Model.HKSJ_Main model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into HKSJ_Main(");
			strSql.Append("title,content,type,Date,people,picUrl)");
			strSql.Append(" values (");
			strSql.Append("@title,@content,@type,@Date,@people,@picUrl)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.VarChar,200),
					new SqlParameter("@content", SqlDbType.NText),
					new SqlParameter("@type", SqlDbType.Char,8),
					new SqlParameter("@Date", SqlDbType.DateTime),
					new SqlParameter("@people", SqlDbType.VarChar,20),
					new SqlParameter("@picUrl", SqlDbType.VarChar,250)};
			parameters[0].Value = model.title;
			parameters[1].Value = model.content;
			parameters[2].Value = model.type;
			parameters[3].Value = model.Date;
			parameters[4].Value = model.people;
			parameters[5].Value = model.picUrl;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(News.Model.HKSJ_Main model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update HKSJ_Main set ");
			strSql.Append("title=@title,");
			strSql.Append("content=@content,");
			strSql.Append("type=@type,");
			strSql.Append("Date=@Date,");
			strSql.Append("people=@people,");
			strSql.Append("picUrl=@picUrl");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.VarChar,200),
					new SqlParameter("@content", SqlDbType.NText),
					new SqlParameter("@type", SqlDbType.Char,8),
					new SqlParameter("@Date", SqlDbType.DateTime),
					new SqlParameter("@people", SqlDbType.VarChar,20),
					new SqlParameter("@picUrl", SqlDbType.VarChar,250),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.title;
			parameters[1].Value = model.content;
			parameters[2].Value = model.type;
			parameters[3].Value = model.Date;
			parameters[4].Value = model.people;
			parameters[5].Value = model.picUrl;
			parameters[6].Value = model.ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from HKSJ_Main ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
};
			parameters[0].Value = ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from HKSJ_Main ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public News.Model.HKSJ_Main GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,title,content,type,Date,people,picUrl from HKSJ_Main ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
};
			parameters[0].Value = ID;

			News.Model.HKSJ_Main model=new News.Model.HKSJ_Main();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"]!=null && ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["title"]!=null && ds.Tables[0].Rows[0]["title"].ToString()!="")
				{
					model.title=ds.Tables[0].Rows[0]["title"].ToString();
				}
				if(ds.Tables[0].Rows[0]["content"]!=null && ds.Tables[0].Rows[0]["content"].ToString()!="")
				{
					model.content=ds.Tables[0].Rows[0]["content"].ToString();
				}
				if(ds.Tables[0].Rows[0]["type"]!=null && ds.Tables[0].Rows[0]["type"].ToString()!="")
				{
					model.type=ds.Tables[0].Rows[0]["type"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Date"]!=null && ds.Tables[0].Rows[0]["Date"].ToString()!="")
				{
					model.Date=DateTime.Parse(ds.Tables[0].Rows[0]["Date"].ToString());
				}
				if(ds.Tables[0].Rows[0]["people"]!=null && ds.Tables[0].Rows[0]["people"].ToString()!="")
				{
					model.people=ds.Tables[0].Rows[0]["people"].ToString();
				}
				if(ds.Tables[0].Rows[0]["picUrl"]!=null && ds.Tables[0].Rows[0]["picUrl"].ToString()!="")
				{
					model.picUrl=ds.Tables[0].Rows[0]["picUrl"].ToString();
				}
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,title,content,type,Date,people,picUrl ");
			strSql.Append(" FROM HKSJ_Main ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" ID,title,content,type,Date,people,picUrl ");
			strSql.Append(" FROM HKSJ_Main ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM HKSJ_Main ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from HKSJ_Main T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "HKSJ_Main";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  Method

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.HKSJ_Main> DataTableToList(DataTable dt)
        {
            
            List<Model.HKSJ_Main> modelList = new List<Model.HKSJ_Main>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                News.Model.HKSJ_Main model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new News.Model.HKSJ_Main();
                    if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    if (dt.Rows[n]["title"] != null && dt.Rows[n]["title"].ToString() != "")
                    {
                        model.title = dt.Rows[n]["title"].ToString();
                    }
                    if (dt.Rows[n]["content"] != null && dt.Rows[n]["content"].ToString() != "")
                    {
                        model.content = dt.Rows[n]["content"].ToString();
                    }
                    if (dt.Rows[n]["type"] != null && dt.Rows[n]["type"].ToString() != "")
                    {
                        model.type = dt.Rows[n]["type"].ToString();
                    }
                    if (dt.Rows[n]["Date"] != null && dt.Rows[n]["Date"].ToString() != "")
                    {
                        model.Date = DateTime.Parse(dt.Rows[n]["Date"].ToString());
                    }
                    if (dt.Rows[n]["people"] != null && dt.Rows[n]["people"].ToString() != "")
                    {
                        model.people = dt.Rows[n]["people"].ToString();
                    }
                    if (dt.Rows[n]["picUrl"] != null && dt.Rows[n]["picUrl"].ToString() != "")
                    {
                        model.picUrl = dt.Rows[n]["picUrl"].ToString();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        #region 下面函数要调用的存储过程
        //create procedure LoadPageData
        //@pageSize int ,
        //@pageIndex int,
        //@totalCount int output
        //as
        //begin
        //    select top(@pageSize)* from dbo.HKSJ_Main where ID  not in
        //    (
        //        select top((@pageIndex-1)*@pageSize) ID from dbo.HKSJ_Main order by id
        //    )
        //    order by id

        //    set @totalCount=(select COUNT(1) from dbo.HKSJ_Main)
        //    print @totalCount
        //end  
        #endregion


        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageSize">页面最多显示的条数</param>
        /// <param name="pageIndex">第几页</param>
        /// <param name="totalListCount">总共有多少条数据</param>
        /// <returns></returns>
        public System.Collections.Generic.List<Model.HKSJ_Main> MyGetListByPage(int pageSize, int pageIndex, out int totalListCount)
        {

            //输出参数的Parameter,要写在using外面,为了后面的调用
            //totalCount是输出参数,所以不需要对他赋值,故换另一种写法
            SqlParameter outPutParameter = new SqlParameter("@totalCount", SqlDbType.Int);
            //设置为输出参数
            outPutParameter.Direction = ParameterDirection.Output;

            //保存到数据库的DataSet
            DataSet ds = new DataSet();

            using (SqlConnection con=new SqlConnection(DbHelperSQL.connectionString))
            {
                //con.Open()

                //执行存储过程只要输入存储过程名
                using (SqlDataAdapter ad=new SqlDataAdapter("LoadPageData",con))
                {
                    //设置参数
                    ad.SelectCommand.Parameters.Add(new SqlParameter("@pageSize", pageSize));
                    ad.SelectCommand.Parameters.Add(new SqlParameter("@pageIndex", pageIndex));
                    ad.SelectCommand.Parameters.Add(outPutParameter);
                    //设置执行的是存储过程
                    ad.SelectCommand.CommandType = CommandType.StoredProcedure;

                    //保存数据
                    ad.Fill(ds);
                }
            }

            //获取输出参数的值
            totalListCount = (int)outPutParameter.Value;
            
            //转换为List集合
            return DataTableToList(ds.Tables[0]);
            
        }
    }
}

