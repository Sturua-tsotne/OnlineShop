using Acount.Servise;
using Shop.Models;
using System.Web.Mvc;
using System.Web.Security;

namespace NEWS.Controllers
{
    public class AcountUserController : Controller
    {
        // GET: AcountUser
        AcountUserServis AcountUserServis;
        public AcountUserController()
        {
            AcountUserServis = new AcountUserServis();
        }

        // GET: Home

        public ActionResult Registration()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Registration(RegistrationModel registrationmodel)
        {
            bool ValidResult = ModelState.IsValid;

            if (ValidResult == true)
            {
                var result = AcountUserServis.InsertUserNotRegister(registrationmodel);
                if (result == true)
                {
                    return Content("<Html> <div class='messigtex' ><h3>რეგისთრაცის დასრულებისათვის საჭიროა შეამოწმოთ მითითებული  ელ.ფოსტა <a href = '/Home/Index'>მთავარი </a>  </h3></div>" +
                        "<script>$(document).ready(function (){ alert(<div class='messigtex' ><h3>რეგისთრაცის დასრულებისათვის საჭიროა შეამოწმოთ მითითებული  ელ.ფოსტა <a href = '/Home/Index'>მთავარი </a>  </h3></div>);})</script> </html>");
                }
                else
                {
                    ViewBag.HtmlOutput = "<HTML><div>ამ ელ.ფოსტით უკვე გაქტიურებულია მომხმარებელი !</div></HTML>";
                    return View();


                }
            }


            return View();
        }


        // GET: Confirmation

        public ActionResult Confirmation(string id)
        {

            var result = AcountUserServis.UserConfirmation(id);

            if (result != false)
            {
                return Content("<html>  + <div style:> <h3>გილოცავთ თქვენ წარმატებით დარეგისთრირდით</h3> " +
                    "<hr> <a href = '/AcountUser/Login' > შესვლა </ a </div > </ html > ");
            }
            else
            {
                return Content("ტექნიკური ხარვეზია გთხოვთ ცადოთ თავიდან <a href = '/AcountUser/Registration'> ცადეთ თავიდან</a> ");
            }



        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel LoginModel)
        {
            bool ValidResult = ModelState.IsValid;

            if (ValidResult == true)
            {
                var result = AcountUserServis.Login(LoginModel);

                if (result != null)
                {
                    FormsAuthentication.SetAuthCookie(result.Email, false);
                    Session["User"] = result;
                    return RedirectToAction("../UserProfile/UserProfile");
                }
                else
                {
                    ViewBag.HtmlOutput = "<HTML><div>ესეთი მომხმარებელი ბაზაში ვერ მოიძებნა !</div><a href = '#'>დაგავიწყდათ პაროლი ? </a> <br><a href = '/AcountUser/Registration'>რეგისტრაცია</a></HTML>";
                    return View();

                    //return Content("<html> "  +
                    //    "<div>ესეთი მომხმარებელი ბაზაში ვერ მოიძებნა</div>" +
                    //    "<a href = '/AcountUser/Login' > თავიდან ცდა</a>" +
                    //    "<br>"+
                    //    " <a href = '#'>პაროლის აღდგენა </a>" +
                    //    "<br>" +
                    //    " <a href = '/AcountUser/Registration' >რეგისტრაცია </a> </html>");
                }
            }

            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}

