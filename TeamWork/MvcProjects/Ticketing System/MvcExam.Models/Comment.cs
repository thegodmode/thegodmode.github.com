using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace MvcExam.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string Content { get; set; }

   //     [Required]
        public string AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual ExtendedUser Author { get; set; }

       // public int TicketId { get; set; }

        public virtual Ticket Ticket { get; set; }
    }
}