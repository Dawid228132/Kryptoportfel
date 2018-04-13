using Cryptonit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
namespace Cryptonit.Controllers
{
    public class UserController : Controller
    {


        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(Users user)
        {
            CryptonitSqlEntities db = new CryptonitSqlEntities();
            db.Users.Add(user);
            db.SaveChanges();
            return View("/Home/Index");
        }

        public ActionResult Login()
        {

            return View();
        }
    }

 
}