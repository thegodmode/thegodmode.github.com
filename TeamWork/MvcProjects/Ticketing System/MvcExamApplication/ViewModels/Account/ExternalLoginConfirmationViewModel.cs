namespace MvcExamApplication.ViewModels.Account
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }
    }
}