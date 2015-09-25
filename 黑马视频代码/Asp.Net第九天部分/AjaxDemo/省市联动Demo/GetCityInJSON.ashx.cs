using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Demo.省市联动Demo.ProvinceDataSetTableAdapters;
using System.Text;

namespace Demo.省市联动Demo
{
    /// <summary>
    /// GetCityInJSON 的摘要说明
    /// </summary>
    public class GetCityInJSON : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int proId = int.Parse(context.Request["Proid"] ?? "0");
            CityTableAdapter adapter = new CityTableAdapter();
            Demo.省市联动Demo.ProvinceDataSet.CityDataTable table = adapter.GetCityByProID(proId);

            #region 拼接字符构造JSON字符串
            //StringBuilder sb = new StringBuilder();
            //sb.Append("[");
            //foreach (var item in table)
            //{
            //    sb.Append("{");
            //    sb.Append("\"CityID\":\""+item.CityID+"\",");
            //    sb.Append("\"CityName\":\"" + item.CityName + "\"");
            //    sb.Append("},");
            //}
            //string resultStr = sb.ToString().TrimEnd(',');
            //resultStr += "]";

            //前端要求JSON对象,那么在这里序列化成JSON
            //System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            //context.Response.Write(jss.Serialize(resultStr));
            #endregion


            #region 用对象集合序列化出JSON字符串
            List<City> citylist = new List<City>();
            foreach (var item in table)
            {
                citylist.Add(new City
                {
                    CityID = item.CityID,
                    CityName = item.CityName
                });
            }

            System.Web.Script.Serialization.JavaScriptSerializer jsSer = new System.Web.Script.Serialization.JavaScriptSerializer();

            context.Response.Write(jsSer.Serialize(citylist));


            #endregion

        }

        class City
        {
            public int CityID { get; set; }
            public string CityName { get; set; }
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}