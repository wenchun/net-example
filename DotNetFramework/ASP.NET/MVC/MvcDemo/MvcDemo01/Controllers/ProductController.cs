using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcDemo01.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /News/


        private object GetProducts()
        {
            var products = new Models.Product[]
            {
                new Models.Product { Name="XBOX360", Link="http://www.google.com", Price=300.0 },
                new Models.Product { Name="USB 隨身碟", Link="http://www.google.com", Price=24.5 },
                new Models.Product { Name="iPad", Link="http://www.google.com", Price=1200.0 }
            };
            return products;
        }

        public ActionResult List()
        {
            // 除了利用 ViewBag 來傳遞資料給 View，我們還可以使用自訂的 Model 物件.
            // 此動作所對應的 View 是使用非強型別的 Model 物件。
            var products = GetProducts();
            return View(products);
        }

        public ActionResult List2()
        {
            // 此動作所對應的 View 是使用強型別的 Model 物件。
            var products = new List<Models.Product>()
            {
                new Models.Product() { Name="XBOX360", Link="http://www.google.com", Price=300.0 },
                new Models.Product() { Name="USB 隨身碟", Link="http://www.google.com", Price=24.5 },
                new Models.Product() { Name="iPad", Link="http://www.google.com", Price=1200.0 }
            };
            return View(products);
        }



        public ActionResult DemoRenderSection()
        {
            // 此動作示範在 View 中使用 @RenderSection 來產生特定區段的 HTML 內容。
            var products = GetProducts();
            return View(products);
        }

    }
}
