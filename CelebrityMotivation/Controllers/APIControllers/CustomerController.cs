using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CelebrityMotivation.Classes;
using System.Web.Http;
using System.IO;
namespace CelebrityMotivation.Controllers
{
    public class CustomerController : ApiController
    {
       

        [HttpPost]
        public string InsertUser(string firstName, string lastName, string email, string pass)
        {
            User user = new User(firstName, lastName, email, pass);
            Classes.User.InsertUser(user);

            return "success";

        }
    }
}
