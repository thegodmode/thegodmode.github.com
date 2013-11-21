namespace HotLikes.ViewModels.Account 
{
    using System.ComponentModel.DataAnnotations;
    using System;
    using HotLikes.Models;

    public class RegisterViewModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be between {2} and {1} characters long", MinimumLength = 1)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be between {2} and {1} characters long", MinimumLength = 1)]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(@"^\w+[\w-\.]*\@\w+((-\w+)|(\w*))\.[a-z]{2,3}$", ErrorMessage = "Invalid Email")]
        public string Email { get; set; }
        
        [Required]
        [Compare("Email", ErrorMessage = "The email and confirmation email do not match.")]
        public string ConfirmEmail { get; set; }
        
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
       
        [Required]
        [Range(1, 2, ErrorMessage = "Invalid Gender")]
        public Gender Gender { get; set; }

        [Required]
        [Range(1, 12, ErrorMessage = "Invalid Month")]
        public int Month { get; set; }

        [Required]
        [Range(1, 31, ErrorMessage = "Invalid Day")]
        public int Day { get; set; }
        
        [Required]
        [Range(1800, 2021, ErrorMessage = "Invalid Year")]
        public int Year { get; set; }

        public DateTime GetBirthDay()
        {
            return new DateTime(this.Year, this.Month, this.Day);
        }

        public ExtendedUser Create()
        {
            return new ExtendedUser
            {
                UserName = this.Email,
                FirstName = this.FirstName,
                LastName = this.LastName,
                Gender = this.Gender,
                BirthDay = this.GetBirthDay(),
                VerificationKey = Guid.NewGuid().ToString(),
                IsVerified = false
            };
        }
    }
}