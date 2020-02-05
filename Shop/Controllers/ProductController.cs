using Shop.Models;
using Shop.Models.DB;
using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Helper;

namespace Shop.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public object AddProduct()
        {
            var user = (AuthenticUser)Session["User"];
            if (user != null)
            {
                return View();
            }
            else
            {

                return RedirectToAction("../AcountUser/login");
            }

        }

        [HttpPost]
        public ActionResult Addproduc(HttpPostedFileBase ProductImg, ProductModel ProductModel)
        {
            var user = (AuthenticUser)Session["User"];
            bool ValidResult = ModelState.IsValid;
            if (ValidResult == true)
            {


                using (GeotonEntities db = new GeotonEntities())
                {
                    string fileExtension = Path.GetExtension(ProductImg.FileName);
                    string NewName = GlobalHelper.Random32();
                    string url = Server.MapPath("/images/");
                    ProductImg.SaveAs(url + NewName + fileExtension);

                    db.Products.Add(new Product()
                    {
                        ProductName = ProductModel.ProductName,
                        AuthenticUserId = user.id,
                        ProductPass = ProductModel.ProductPass,
                        category = ProductModel.Category,
                        ProductCreationDate = DateTime.Now,
                        ProductImg = "/images/" + NewName + fileExtension,


                    });
                    db.SaveChanges();
                    return RedirectToAction("../UserProfile/UserProfile");
                }
            }
           
            return View("AddProduct");
        }
           
        
    }
}