using eUseControl.BusinessLogic;
using eUseControl.BusinessLogic.DBModel;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.Domain.Entities.Product;
using eUseControl.Web.Models;
using Microsoft.ApplicationInsights.Extensibility.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eUseControl.Web.Controllers
{
    public class ProdusController : Controller
    {
        // GET: Products

        private readonly ISession _session;
        public ProdusController()
        {
            var bl = new BussinesLogic();
            _session = bl.GetSessionBL();
        }

        [AdminMod]
        public ActionResult AdminProducts()
        
        {
            var product = new ProductEdit();
            product.Id = 1;

            ProductDbTable prodId;
            using (var db = new ProductContext())
            {
                prodId = db.Products.Find(product.Id);
            };
            return View("AdminProducts",prodId);
        }


        public ActionResult UserProducts()
        {

            var product = new ProductEdit();
            product.Id = 1;

            ProductDbTable prodId;
            using (var db = new ProductContext())
            {
                prodId = db.Products.Find(product.Id);
            };
            return View("UserProducts", prodId);
        }


        
        public ActionResult ProductsEdit(ProductEdit product)
        {
            ProductDbTable prodId;

            if (ModelState.IsValid)
            {
                PEditData data = new PEditData
                {
                    Id = 1,
                    Price = product.Price,
                };

                var productEdit = _session.ProductEdit(data);
                if (productEdit.Status)
                {
                    using (var db = new ProductContext())
                    {
                        prodId = db.Products.Find(data.Id);
                    };

                    return View("AdminProducts", prodId);
                }
                else
                {
                    ModelState.AddModelError("", productEdit.StatusMsg);
                    return View("AdminProducts");
                }
            }

            return View();
            
            
            
        }

        [HttpPost]
        public ActionResult ProductsRegister(Product product)
        {
            if (ModelState.IsValid)
            {
                PRegisterData data = new PRegisterData
                {
                    Price = product.Price,
                    ProdusName = product.ProdusName
                };

                var productRegister = _session.ProductRegister(data);
                if (productRegister.Status)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", productRegister.StatusMsg);
                    return View("Product");
                }
            }



            return View("Product");
        }
    }
}