using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Caching;

namespace Demo.缓存案例
{
    public partial class CatchDemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //设置依赖数据库的缓存
                Cache.Insert("key", DateTime.Now.ToString(), new SqlCacheDependency("bjhksj", "HKSJ_USERS"));
                Response.Write("缓存写入成功");
            }
            else
            {
                Response.Write(HttpContext.Current.Cache["key"]);
            }
        }
    }
}

#region 案例一
//Cache["key"] = DateTime.Now.ToString();
//Response.Write("缓存写入成功");
#endregion

#region 案例二
////带失效时间的缓存
////这里设置为绝对时间,5秒后缓存失效
////设置绝对失效时间,那么Insert最后一个必须为TimeSpan.Zero
//Cache.Insert("key", DateTime.Now.ToString(), null, DateTime.Now.AddSeconds(5), TimeSpan.Zero);
//Response.Write("缓存写入成功"); 
#endregion

#region 案例三
////设置滑动时间为失效时间的缓存
////即但不在访问页面一段时间后缓存才失效,如果一直在时间内访问页面,则缓存不失效
////设置滑动时间,倒数第二个参数必须为DateTime.MaxValue,即无绝对失效时间
//Cache.Insert("key", DateTime.Now.ToString(), null, DateTime.MaxValue, new TimeSpan(0, 0, 5));
//Response.Write("缓存写入成功");  
#endregion

#region 案例四
//string filePath = Request.MapPath("TextFile.txt");
//设置有依赖项缓存
//缓存现在依赖一个文本文件,当这个文本文件没有修改前缓存一直存在
//应用场景:假设页面上的一个菜单是后台读取一个XML文件生成的,那么这时可以把这个XML设置为依赖项
//菜单依赖XML生成,直到XML改变前菜单都不需要改变
//Cache.Insert("key", DateTime.Now, new System.Web.Caching.CacheDependency(filePath));
//Response.Write("缓存写入成功"); 
#endregion