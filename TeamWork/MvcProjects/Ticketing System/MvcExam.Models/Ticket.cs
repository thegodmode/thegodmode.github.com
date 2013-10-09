using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace MvcExam.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

     //   [Required]
        public string AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual ExtendedUser Author { get; set; }

     //   [Required]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

//[Required]
        public string Title { get; set; }

      //  [Required]
        public Priority Priority { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        public string ScreenshotUrl { get; set; }

        public virtual ICollection<Comment>  Comments { get; set; }

        public Ticket()
        {
            this.Comments = new HashSet<Comment>();
        }
    }
}