using Shop.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class UserProfileController : Controller
    {
        // GET: UserProfile
        [Authorize]
        public  ActionResult UserProfile()
        {
            var user = (AuthenticUser)Session["User"];
            if (user != null)
            {


                using (GeotonEntities db = new GeotonEntities())
                {
                    List<Product> productlist = new List<Product>();
                    foreach (var item in db.Products.Where(x => x.AuthenticUserId == user.id))
                    {
                        productlist.Add(new Product()
                        {
                            Id = item.Id,
                            ProductName = item.ProductName,
                            ProductImg = item.ProductImg,
                            ProductPass = item.ProductPass,
                            category = item.category,
                            AuthenticUserId = item.AuthenticUserId,
                            ProductCreationDate = item.ProductCreationDate,

                        });
                    }

                    return View(productlist);


                }
            }
            else
            {
                return RedirectToAction(".. /AcountUser/Login");
            }
           
           
        }
    }
}