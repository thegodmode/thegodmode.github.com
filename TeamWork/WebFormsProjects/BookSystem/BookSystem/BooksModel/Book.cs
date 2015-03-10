using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BookSystem.BooksModel
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Title must be between 5 and 50!!")]
        public string Title { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Author Name is too long (5-50)!")]
        public string Author { get; set; }
       
        public string Isbn { get; set; }

        public string WebSite { get; set; }
        
        [Column(TypeName = "ntext")]
        public string Description { get; set; }
        
        public virtual Category Category { get; set; }
    }
}