namespace MvcExam.Models
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    
    public class ExtendedUser : User
    {
       // [Required]
        public int Points { get; set; }
    }
}