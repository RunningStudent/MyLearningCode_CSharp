using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using News.BLL;

namespace Demo.新闻列表与详情复习
{
    public partial class EditFm : System.Web.UI.Page
    {
        public News.Model.HKSJ_Main modelMain { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = int.Parse(Request["id"] ?? "0");
            HKSJ_Main bllMain = new HKSJ_Main();
            if (!IsPostBack)
            {
                modelMain=bllMain.GetModel(id) ;
            }
            else
            {
                //新闻并不是全部都修改,所以先有原来的新闻信息,再修改其部分,最后保存

                //本来以为在第二次的modelMain里面保留了上次的记录,那么直接修改这个对象,再保存,然而事实是这个对象并未保存,第二次访问时为null
                //Response.Clear();
                //Response.Write(modelMain.title);
                //Response.End();

                //必须查询一次数据库,把这调新闻查询出来,在修改,再保存
                News.Model.HKSJ_Main saveModel = bllMain.GetModel(id);
                saveModel.people = Request["people"];
                saveModel.type = Request["type"];
                saveModel.title = Request["title"];
                saveModel.content = Request["content"];
                bllMain.Update(saveModel);

                Response.Clear();
                Response.Write("ok");
                Response.End();
            }
        }
    }
}