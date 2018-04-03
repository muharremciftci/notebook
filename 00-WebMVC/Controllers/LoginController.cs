using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _00_BusinessLayer;
using _00_Entity;

namespace _00_WebMVC.Controllers
{
    public class LoginController : Controller
    {
        UserBusiness _users =new UserBusiness();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string email,string password)
        {
           User user= _users.Login(email, password);
            if (user==null)
            {
                ViewBag.Error = "Kullanıcı adı veya Şifre Hatalı";
                return View();
            }
            else
            {
                Session["UserID"] = user.ID;
               return RedirectToAction("Index", "Home");   
            }
        }
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(User user)
        {
           bool result= _users.SignUp(user);
            if (result)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }

    }
}