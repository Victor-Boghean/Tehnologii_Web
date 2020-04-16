using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eUseControl.BusinessLogic;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.User;
using eUseControl.Web.Models;

namespace eUseControl.Web.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ISession _session;
        public RegisterController()
        {
            var bl = new BussinesLogic();
            _session = bl.GetSessionBL();
        }
        public ActionResult Register()
        {
            return View("Register");
        }


        [HttpPost]
        public ActionResult Register(UserRegister register)
        {
            if (ModelState.IsValid)
            {
                URegisterData data = new URegisterData
                {
                    Username = register.Username,
                    Email = register.Email,
                    Password = register.Password
                };
                var userRegiser = _session.UserRegister(data);
                if (userRegiser.Status)
                {
                    return RedirectToAction("Signin", "Login");
                }
                else
                {
                    ModelState.AddModelError("", userRegiser.StatusMsg);
                    return View("Register");
                }
            }
            return View("Register");
        }

    }
}