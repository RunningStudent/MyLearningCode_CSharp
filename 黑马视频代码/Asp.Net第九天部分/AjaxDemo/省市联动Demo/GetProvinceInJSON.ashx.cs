using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace Demo.省市联动Demo
{
    /// <summary>
    /// GetProvinceInJSON 的摘要说明
    /// </summary>
    public class GetProvinceInJSON : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //用数据集生成了一些代码
            ProvinceDataSetTableAdapters.ProvinceTableAdapter adapter = new ProvinceDataSetTableAdapters.ProvinceTableAdapter();

            StringBuilder sb = new StringBuilder();
            //<option value="value">text</option>
            //获得所有数据
            ProvinceDataSet.ProvinceDataTable table=adapter.GetData();

            //构建一个数组,里面都是JSON
            sb.Append("[");
            //遍历表的每行,构建JSON字符串
            foreach (var item in table)
            {
                sb.Append("{");
                sb.AppendFormat("\"pId\":\"{0}\",",item.ProID);
                sb.AppendFormat("\"pName\":\"{0}\"",item.ProName);
                sb.Append("},");
            }
            string result = sb.ToString().TrimEnd(',');
            result += "]";
            //这里返回的仅是JSON的字符串,不是JSON
            context.Response.Write(result);


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