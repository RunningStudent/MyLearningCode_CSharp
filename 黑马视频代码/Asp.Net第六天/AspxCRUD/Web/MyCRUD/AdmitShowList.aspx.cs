using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace News.Web.MyCRUD
{
    public partial class AdmitShowList : System.Web.UI.Page
    {
        /// <summary>
        /// 前端要显示的数据集合
        /// </summary>
        public List<Model.HKSJ_Main> NewsList { get; set; }

        /// <summary>
        /// 要显示的页数链接的个数
        /// </summary>
        public int pageCount { get; set; }


        /// <summary>
        /// 页面链接导航栏
        /// </summary>
        public string PageNav { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            BLL.HKSJ_Main mainBLL = new BLL.HKSJ_Main();
            #region 无分页获取数据
            ////获取数据
            //NewsList = mainBLL.GetModelList(string.Empty);
            #endregion
            
            #region 分页获取数据
            int totalListCount = mainBLL.GetRecordCount(string.Empty);

            //注意为空处理
            int pageIndex = int.Parse(Context.Request["pageIndex"] ?? "1");
            //每页显示的数量
            int pageSize = 5;
            //获得要前端要显示的页数连接的数量,注意totalListCount数量过小处理
            pageCount = Math.Max((totalListCount + pageSize - 1) / pageSize, 1);

            #region 代码生成器做法
            //DataSet set = mainBLL.GetListByPage(string.Empty, "id", (pageIndex - 1) * pageSize + 1, pageIndex * pageSize);
            //NewsList = mainBLL.DataTableToList(set.Tables[0]);
            #endregion

            #region 自行编写存储过程及其对应三层代码做法
            NewsList = mainBLL.MyGetListByPage(pageSize, pageIndex, out totalListCount);
            #endregion

            //处理链接导航栏,用一个静态类
            PageNav = Pager.ShowPageNavigate(pageSize, pageIndex, totalListCount);
            #endregion

        }
    }
}