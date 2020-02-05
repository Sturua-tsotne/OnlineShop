using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public enum Test
    {
      gold,
      silver


    }


    public class TESTController : Controller
    {
        // GET: TEST
        public ActionResult Te(string name ,string surname,Test test)
        {
            name = "tsotne";
            surname = "sturua";
            
            if (test== Test.gold)
            {
                return Content(surname+"<h1>50</h1>"+name);
            }
            else
            {
                return Content("<h1>20</h1>");
            }
            
           
        }
    }
}