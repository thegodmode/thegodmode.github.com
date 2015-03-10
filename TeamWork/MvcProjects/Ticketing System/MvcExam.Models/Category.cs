using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcExam.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        
   //     [Required]
        public string Name { get; set; }

        public ICollection<Ticket> Tickets { get; set; }

        public Category()
        {
            this.Tickets = new HashSet<Ticket>();
        }
    }
}
