using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using News.BLL;

namespace News.Web.MyCRUD
{
    public partial class ShowListForm : System.Web.UI.Page
    {


        /// <summary>
        /// 新闻List Model> 类,给页面使用
        /// </summary>
        public List<Model.HKSJ_Main> newsListData { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            HKSJ_Main mainBll = new HKSJ_Main();
            newsListData =mainBll.GetModelList(string.Empty);

        }
    }
}