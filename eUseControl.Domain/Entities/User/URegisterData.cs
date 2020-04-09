using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.Domain.Entities.User
{
    public class URegisterData
    {
        [Required(ErrorMessage = "Name cannot be longer that 20 characters.")]
        [Display(Name = "Username")]
        [StringLength(20, MinimumLength = 3)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password cannot be shorter that 8 characters.")]
        [Display(Name = "Password")]
        [StringLength(50, MinimumLength = 8)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Enter email adress")]
        [EmailAddress]
        [Display(Name = "Email")]
        [StringLength(30)]
        public string Email { get; set; }

    }
}
