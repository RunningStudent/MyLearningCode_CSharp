using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace News.Web.MyCRUD
{
    public partial class EditFrom : System.Web.UI.Page
    {
        public Model.HKSJ_Main newsDeatail;

        protected void Page_Load(object sender, EventArgs e)
        {
            BLL.HKSJ_Main mainBll = new BLL.HKSJ_Main();
            //提交修改信息时
            if (IsPostBack)
            {
                Model.HKSJ_Main newDataModel = new Model.HKSJ_Main();
                //数据获得
                newDataModel.title = Context.Request["title"];
                newDataModel.ID = int.Parse(Context.Request["id"]??"0");
                newDataModel.people = Context.Request["people"];
                newDataModel.picUrl = "";
                newDataModel.type = "";
                newDataModel.content = Context.Request["content"];
                newDataModel.Date = DateTime.Now;

                //保存到数据库
                mainBll.Update(newDataModel);
                Context.Response.Redirect("AdmitShowList.aspx");
            }
            else//第一次访问页面,数据展示
            {
                int id = int.Parse(Context.Request["id"]);
                newsDeatail = mainBll.GetModel(id);
            
            }
        }
    }
}