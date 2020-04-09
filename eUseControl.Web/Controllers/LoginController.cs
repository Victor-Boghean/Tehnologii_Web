﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eUseControl.BusinessLogic;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.User;
using eUseControl.Web.Models;

namespace eUseControl.Web.Controllers
{
    public class LoginController : Controller
    {

        private readonly ISession _session;

        public LoginController()
        {
            var bl = new BussinesLogic();
            _session = bl.GetSessionBL();
        }


        public ActionResult Signin()
        {
            UserLogin login = new UserLogin();

            return View(login);
        }        

        //Get: Login
        [HttpPost] //transmiterea datelor client sau a formularului catre server
        [ValidateAntiForgeryToken]//pentru a preveni falsificarea cererilor între site-uri
        public ActionResult Signin(UserLogin login) 
        {
           if(ModelState.IsValid)
            {
                UserRegister user = null;

                using(OnlineStoreEntities db = new OnlineStoreEntities())
                {
                    user = db.UserRegisters.FirstOrDefault(u => u.Username == login.Username && u.Password == login.Password );
                }

                if(user != null)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "This user doesn't exixt");
                }


               /* ULoginData data = new ULoginData
                {
                    Username = login.Username,
                    Password = login.Password,
                    LoginIp = Request.UserHostAddress,
                    LoginDateTime = DateTime.Now

                };
                
                var userLogin = _session.UserLogin(data);
                if(userLogin.Status)
                {
                    //add cookie
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", userLogin.StatusMsg);
                    return View();
                }*/
            }
            return View(login);
        }
    }
}