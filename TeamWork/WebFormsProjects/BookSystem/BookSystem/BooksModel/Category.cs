using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookSystem.BooksModel
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Name must be between 5 and 50!")]
        public string Name { get; set; }

        public  virtual ICollection<Book> Books { get; set; }
        public Category()
        {
            this.Books = new HashSet<Book>();
        }
    }
}