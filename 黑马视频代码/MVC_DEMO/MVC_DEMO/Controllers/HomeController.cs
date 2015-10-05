using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using System.Web.WebPages;
using System.ComponentModel;
namespace MVC_DEMO.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        CCDBEntities db = new CCDBEntities();

        public ActionResult Index()
        {
            
            return View(new Test(){
                 Test1=1
            });
         
        }

        [HttpPost]
        public ActionResult Add(string className)
        {
            db.MyClass.Add(new MyClass()
            {
                className = className
            });

            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            MyClass myclass = new MyClass()
            {
                classId = id
            };
            db.MyClass.Attach(myclass);
            db.MyClass.Remove(myclass);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Test()
        {
            return View(new Test()
            {
                Test1 = 1,
                Test2 = 2
            });
            
        }

        [HttpPost]
        public ActionResult Test(Test t)
        {
            return Content(t.Test1.ToString());
        }

        
    }

    public class Test{
        [DisplayName("测试")]
        public int Test1 { get; set; }
        public int Test2 { get; set; }
    }
}
