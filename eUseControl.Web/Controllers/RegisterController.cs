using eUseControl.BusinessLogic.DBModel;
using eUseControl.Domain.Entities.User;
using eUseControl.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eUseControl.Web.Controllers
{
    public class RegisterController : Controller
    {
        public ActionResult Register()
        {
            URegisterData userModel = new URegisterData();

            return View(userModel);
        }


        [HttpPost]
        public ActionResult Register(URegisterData userModel)
        {
            UserRegister register = new UserRegister
            {
                Username = userModel.Username,
                Password = userModel.Password,
                Email = userModel.Email,
                RegisterDateTime = DateTime.Now
            };

            using (OnlineStoreEntities dbModel = new OnlineStoreEntities())
            {
                dbModel.UserRegisters.Add(register);
                dbModel.SaveChanges();
            }
            ModelState.Clear();
            return RedirectToAction("Signin", "Login");
        }

    }
}