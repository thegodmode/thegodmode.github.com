namespace Skeleton.ViewModels.Account 
{
    using System.ComponentModel.DataAnnotations;
    using System;
    using Skeleton.Models;
   
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string Name { get; set; }
        
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Range(1, 12, ErrorMessage = "Invalid Month")]
        public int Month { get; set; }

        [Required]
        [Range(1, 31, ErrorMessage = "Invalid Day")]
        public int Day { get; set; }
        
        [Required]
        [Range(1800, 2021, ErrorMessage = "Invalid Year")]
        public int Year { get; set; }

        private DateTime GetBirthDay()
        {
            return new DateTime(this.Year, this.Month, this.Day);
        }

        public ApplicationUser CreateDbUser()
        {
            var user = new ApplicationUser()
            {
                UserName = this.UserName,
                Name = this.Name,
                BirthDay = this.GetBirthDay()
            };

            return user;
        }
    }
}