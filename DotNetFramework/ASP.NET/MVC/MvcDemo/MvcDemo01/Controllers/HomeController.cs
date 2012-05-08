using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcDemo01.Models;

namespace MvcDemo01.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

/*
        public string Index()
        {
            // 此範例沒有用到 View，只是單除傳回 HTML 字串.
            string result = "<html><body>" +
                            "<h2>Hello, ASP.NET MVC!</h2>" +
                            "</body></html>";
            return result;
        }
*/

        public ActionResult Index()
        {
            // 你可以把任何東西存入 ViewBag 的屬性，
            // 而且屬性名稱可由你任意指定. 
            ViewBag.CurrentTime = DateTime.Now; // 等同於使用 ViewData["CurrentTime"]
            return View();
        }
    }
}
