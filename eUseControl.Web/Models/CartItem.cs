using eUseControl.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eUseControl.Web.Models
{
    public class CartItem
    {

        public ProductDbTable Product { get; set; }

        public int Quantity { get; set; }

    }
}