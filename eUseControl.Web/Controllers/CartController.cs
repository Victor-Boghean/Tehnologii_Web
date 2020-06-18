using eUseControl.BusinessLogic.DBModel;
using eUseControl.Domain.Entities.Product;
using eUseControl.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eUseControl.Web.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Cart()
        {
           return View();
        }

        ProductContext ctx = new ProductContext();
        
        public ActionResult AddToCart(int productId)
        {
            productId = 1;
            List<CartItem> cart = new List<CartItem>();
            var product = ctx.Products.Find(productId);
            cart.Add(new CartItem()
            {
                Product = product,
                Quantity = 1
            });

            Session["cart"] = cart;

            return View("Cart");
        }
    }
}