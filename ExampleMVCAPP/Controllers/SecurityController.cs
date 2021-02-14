﻿using ExampleMVCAPP.DataContext;
using ExampleMVCAPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ExampleMVCAPP.Controllers
{
    [AllowAnonymous]

    public class SecurityController : Controller
    {
        // GET: Security
        DBContext dbObj = new DBContext();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            var userInDb = dbObj.UserSet.FirstOrDefault(x => x.Username == user.Username && x.Password == user.Password);
            if (userInDb != null)
            {
                FormsAuthentication.SetAuthCookie(user.Username, false);
                return RedirectToAction("UserView", "User");
            }
            else
            {
                ViewBag.Mesaj = "Geçersiz. Kullanıcı adı ya da şifre hatalı.";
                return View();
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}