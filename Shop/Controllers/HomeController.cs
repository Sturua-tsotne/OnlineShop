using Shop.Models;
using Shop.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Search(string search)
        {
            using (GeotonEntities db = new GeotonEntities())
           {
               
                   var   productlist =db.Products.Where(x=>x.ProductName.Contains(search.Trim()))
                    .Select(x=>new ProductModel
                    {
                        Productid = x.Id,
                        ProductName = x.ProductName,
                        ProductImg = x.ProductImg,
                        ProductPass = x.ProductPass,                     
                        Category = x.category,
                       

                    });
              
                return Json(productlist);
            }
        }
       
       
    }
}