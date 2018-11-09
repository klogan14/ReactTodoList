using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CelebrityMotivation.Classes;

namespace CelebrityMotivation.Controllers
{
    public class Customer : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public string InsertUser(string firstName, string lastName, string email, string pass)
        {

            User user = new User(firstName, lastName, email, pass);
            Classes.User.InsertUser(user);
            Console.WriteLine("test");
            System.Diagnostics.Debug.WriteLine("test!");
            return "success";

        }
    }
}
