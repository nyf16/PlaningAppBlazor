using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PlaningApp.Shared.Models
{
    public class RegisterRequest
    {
        [Required]
        [StringLength(50)]
        [EmailAddress]
        [Display(Name ="E-Mail")]
        public string Email { get; set; }

        [Required]
        [StringLength(25)]
        [Display(Name = "İsim")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(25)]
        [Display(Name = "Soyisim")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Şifreyi Onayla")]
        public string ConfirmPassword { get; set; }
    }
}
