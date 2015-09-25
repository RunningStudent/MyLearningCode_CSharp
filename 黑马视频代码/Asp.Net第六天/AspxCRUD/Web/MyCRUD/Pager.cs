using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace News.Web.MyCRUD
{
    public class Pager
    {
        /// <summary>
        /// 获得分页连接导航栏的HTML字符串
        /// </summary>
        /// <param name="pageSize">每页显示的数量</param>
        /// <param name="currentPage">当前第几页</param>
        /// <param name="totalCount">数据的总条数</param>
        /// <returns></returns>
        public static string ShowPageNavigate(int pageSize, int currentPage, int totalCount)
        {
            //这里可以修改为跳转到某个连接
            //如果不写就是跳转当前页面,只是添加了几个属性
            string redirectTo = "";
            pageSize = pageSize == 0 ? 3 : pageSize;
            //总页数
            var totalPages = Math.Max((totalCount + pageSize - 1) / pageSize, 1); 
            var output = new StringBuilder();
            
            if (totalPages > 1)
            {
                if (currentPage != 1)
                {
                    //处理首页连接
                    output.AppendFormat("<a class='pageLink' href='{0}?pageIndex=1&pageSize={1}'>首页</a> ", redirectTo, pageSize);
                }
                if (currentPage > 1)
                {
                    //处理上一页的连接
                    output.AppendFormat("<a class='pageLink' href='{0}?pageIndex={1}&pageSize={2}'>上一页</a> ", redirectTo, currentPage - 1, pageSize);
                }
                else
                {
                    // output.Append("<span class='pageLink'>上一页</span>");
                }

                output.Append(" ");
                int currint = 5;
                for (int i = 0; i <= 10; i++)
                {
                    //一共最多显示10个页码，前面5个，后面5个
                    if ((currentPage + i - currint) >= 1 && (currentPage + i - currint) <= totalPages)
                    {
                        if (currint == i)
                        {
                            //当前页处理,这里好像就修改了a标签的class属性
                            //output.Append(string.Format("[{0}]", currentPage));
                            output.AppendFormat("<a class='cpb' href='{0}?pageIndex={1}&pageSize={2}'>{3}</a> ", redirectTo, currentPage, pageSize, currentPage);
                        }
                        else
                        {
                            //一般页处理
                            output.AppendFormat("<a class='pageLink' href='{0}?pageIndex={1}&pageSize={2}'>{3}</a> ", redirectTo, currentPage + i - currint, pageSize, currentPage + i - currint);
                        }
                    }
                    output.Append(" ");
                }

                //处理下一页的链接
                if (currentPage < totalPages)
                {
                    output.AppendFormat("<a class='pageLink' href='{0}?pageIndex={1}&pageSize={2}'>下一页</a> ", redirectTo, currentPage + 1, pageSize);
                }
                else
                {
                    //output.Append("<span class='pageLink'>下一页</span>");
                }


                output.Append(" ");


                //处理末页的链接
                if (currentPage != totalPages)
                {
                    output.AppendFormat("<a class='pageLink' href='{0}?pageIndex={1}&pageSize={2}'>末页</a> ", redirectTo, totalPages, pageSize);
                }
                output.Append(" ");
            }

            //这个统计加不加都行
            output.AppendFormat("第{0}页 / 共{1}页", currentPage, totalPages);
            return output.ToString();
        }
    }
}
