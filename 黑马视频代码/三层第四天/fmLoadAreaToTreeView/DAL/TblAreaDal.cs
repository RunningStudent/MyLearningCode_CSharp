using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace fmLoadArea.Model
{
    public class TblAreaDal
    {

        /// <summary>
        /// 根据AreaPid获得数据,并用Area储存
        /// </summary>
        /// <param name="areaPid"></param>
        /// <returns>Area类集合</returns>
        public List<Area> GetAreaDataByAreaPID(int areaPid)
        {
            List<Area> list = new List<Area>();
            string sql = "select AreaId,AreaName from TblArea where AreaPId=@pid";
            using (SqlDataReader reader=SqlHelper.ExecuteReader(sql, System.Data.CommandType.Text,new SqlParameter("@pid",areaPid)))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Area a = new Area();
                        a.AreaId = reader.GetInt32(0);
                        a.AreaName = reader.GetString(1);
                        list.Add(a);
                    }
                }
            }
            return list;
        }


        /// <summary>
        /// 根据areaPId删除数据
        /// </summary>
        /// <param name="areaId"></param>
        /// <returns>影响行数</returns>
        public int DeleteAreaDateByAreaId(int areaPId)
        {
            string sql = "delete TblArea where AreaId=@areaId";
            return SqlHelper.ExecuteNonQuery(sql, System.Data.CommandType.Text, new SqlParameter("@areaId", areaPId));
        }

    }
}
