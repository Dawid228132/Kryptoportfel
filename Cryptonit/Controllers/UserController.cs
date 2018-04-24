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
            using (CryptonitEntities db = new CryptonitEntities())
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
                using (CryptonitEntities db = new CryptonitEntities())
                {
                    bool isEmail = IsEmailExist(user.email);
                    bool isLogin = IsLoginExist(user.login);
                    if(isLogin)
                    {
                        ModelState.AddModelError("LoginExist", "Login already exist.");
                        return View(user);
                    }
                    if (isEmail)
                    {
                        ModelState.AddModelError("EmailExist", "Email already exist.");
                        return View(user);
                    }
                    if (!isLogin&&!isEmail)
                    {
                        user.salt = HashPassword.createSalt();
                       
                        user.password = HashPassword.hash(user.password,user.salt);
                        user.confirmPassword= HashPassword.hash(user.confirmPassword,user.salt);
                        db.Users.Add(user);
                        db.SaveChanges();
                        ViewBag.Message = "success";
                        
                    }
                }
                ModelState.Clear();
                
            }
            return View();

        }
       [NonAction]
        public bool IsEmailExist(string email)
        {
  
                    using (CryptonitEntities db = new CryptonitEntities())
                {
                
                    foreach(Users u in db.Users.ToArray())
                    {
                        if (u.email.Equals(email))
                            return true;
                    }

                    return false;
                }
        }
        public bool IsLoginExist(string login)
        {
            using (CryptonitEntities db = new CryptonitEntities())
            {
                foreach (Users u in db.Users.ToArray())
                {
                    if (u.login.Equals(login))
                        return true;
                }
                return false;
            }
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Users user)
        {

                using (CryptonitEntities db = new CryptonitEntities())
                {
                    //user.password = HashPassword.hash(user.password);
                    foreach (Users u in db.Users.ToArray())
                    {
                        if (u.login==user.login&& HashPassword.hash(user.password,u.salt)==u.password)
                        {
                            Session["UserID"] = u.Id.ToString();
                            Session["UserLogin"] = u.login;
                            return RedirectToAction("LoggedIn");
                        }
                    }  
                }

            ModelState.AddModelError("LoginError", "Login or Password is wrong.");
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