﻿using Cryptonit.Models;
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
                        user.password = HashPassword.hash(user.password);
                        user.confirmPassword= HashPassword.hash(user.confirmPassword);
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
  
                    using (CryptonitEntities1 db = new CryptonitEntities1())
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
            using (CryptonitEntities1 db = new CryptonitEntities1())
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

                using (CryptonitEntities1 db = new CryptonitEntities1())
                {
                    user.password = HashPassword.hash(user.password);
                    foreach (Users u in db.Users.ToArray())
                    {
                        if (u.login==user.login&& user.password==u.password)
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