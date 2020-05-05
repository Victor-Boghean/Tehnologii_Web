using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace eUseControl.Web.Models
{
    public class UserLogin
    {
        [Required]
        public string Email { get;set; }

        [Required]
        public string Password { get; set; }

    }
}
