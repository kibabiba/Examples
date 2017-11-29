using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AppMVCTest.Models;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;

namespace AppMVCTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new MessageViewModel(User.Identity.GetUserName());
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(MessageViewModel model)
        {
            
            if (ModelState.IsValid)
            {
                var user = new UserModel(model.UserName);
                if(!User.Identity.IsAuthenticated)
                {
                    if (user.IsExist)
                    {
                        ViewData["Error"] = "User already exists.";
                        return View(model);
                    }
                    FormsAuthentication.SetAuthCookie(user.UserName, true);
                    user.SaveNewUser();
                }
                model.AddNewMessage(user);
            }
            ViewData["Message"] = model.MsgId > 0 ? "Message saved" : "Message can not be saved";
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public void LogOff()
        {
            FormsAuthentication.SignOut();
            Response.Redirect("/");
        }
    }
}