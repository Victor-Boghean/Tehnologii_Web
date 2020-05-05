using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eUseControl.Web.Models
{
    public class ProductEdit
    {
        public int Id { get; set; }
        public string ProdusName { get; set; }

        public string Price { get; set; }

    }
}