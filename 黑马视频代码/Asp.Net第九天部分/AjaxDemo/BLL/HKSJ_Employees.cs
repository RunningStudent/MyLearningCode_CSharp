﻿using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using News.Model;
namespace News.BLL
{
	/// <summary>
	/// HKSJ_Employees
	/// </summary>
	public partial class HKSJ_Employees
	{
		private readonly News.DAL.HKSJ_Employees dal=new News.DAL.HKSJ_Employees();
		public HKSJ_Employees()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			return dal.Exists(ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(News.Model.HKSJ_Employees model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(News.Model.HKSJ_Employees model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			
			return dal.Delete(ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			return dal.DeleteList(IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public News.Model.HKSJ_Employees GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public News.Model.HKSJ_Employees GetModelByCache(int ID)
		{
			
			string CacheKey = "HKSJ_EmployeesModel-" + ID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (News.Model.HKSJ_Employees)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<News.Model.HKSJ_Employees> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<News.Model.HKSJ_Employees> DataTableToList(DataTable dt)
		{
			List<News.Model.HKSJ_Employees> modelList = new List<News.Model.HKSJ_Employees>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				News.Model.HKSJ_Employees model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new News.Model.HKSJ_Employees();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["title"]!=null && dt.Rows[n]["title"].ToString()!="")
					{
					model.title=dt.Rows[n]["title"].ToString();
					}
					if(dt.Rows[n]["content"]!=null && dt.Rows[n]["content"].ToString()!="")
					{
					model.content=dt.Rows[n]["content"].ToString();
					}
					if(dt.Rows[n]["people"]!=null && dt.Rows[n]["people"].ToString()!="")
					{
					model.people=dt.Rows[n]["people"].ToString();
					}
					if(dt.Rows[n]["date"]!=null && dt.Rows[n]["date"].ToString()!="")
					{
						model.date=DateTime.Parse(dt.Rows[n]["date"].ToString());
					}
					if(dt.Rows[n]["status"]!=null && dt.Rows[n]["status"].ToString()!="")
					{
						model.status=int.Parse(dt.Rows[n]["status"].ToString());
					}
					if(dt.Rows[n]["MainPeople"]!=null && dt.Rows[n]["MainPeople"].ToString()!="")
					{
					model.MainPeople=dt.Rows[n]["MainPeople"].ToString();
					}
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  Method
	}
}

