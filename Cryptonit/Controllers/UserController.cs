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


        public ActionResult Index()
        {
            using (CryptonitEntities1 db = new CryptonitEntities1())
            {
                return View(db.Users.ToList());
            }
                
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register( Users user)
        {
           if(ModelState.IsValid)
            {
                using (CryptonitEntities1 db = new CryptonitEntities1())
                {
                   
                    db.Users.Add(user);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = "Account successfully registered.";
            }
            return View();

        }
       
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(Users user)
        {
            using (CryptonitEntities1 db = new CryptonitEntities1())
            {
                var usr = db.Users.Single(u => u.login == user.login && u.password == user.password);
                if(usr!=null)
                {
                    Session["UserID"] = usr.Id.ToString();
                    Session["UserLogin"] = usr.login;
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "Login or Password is wrong.");
                }
            }
            return View();
        }
        public ActionResult LoggedIn()
        {
            if(Session["UserID"]!=null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
    

 
}