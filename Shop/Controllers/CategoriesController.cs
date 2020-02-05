using Shop.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories
        public ActionResult Categori(string test)
        {
            //test = "სხვადასხვა";
            using (GeotonEntities db = new GeotonEntities())
            {
                //List<Product> productlist = new List<Product>();
                //foreach (var item in db.Products.Where(x => x.category==test))
                //{
                //    productlist.Add(new Product()
                //    {
                //        Id = item.Id,
                //        ProductName = item.ProductName,
                //        ProductImg = item.ProductImg,
                //        ProductPass = item.ProductPass,
                //        AuthenticUserId = item.AuthenticUserId,
                //        category = item.category,
                //        ProductCreationDate = item.ProductCreationDate,

                //    });
                //}

                return View();
            }
        }
    }
}