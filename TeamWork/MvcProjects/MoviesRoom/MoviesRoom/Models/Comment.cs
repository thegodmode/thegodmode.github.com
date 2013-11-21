using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesRoom.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
       
        [Column(TypeName = "Text")]
        [Required(ErrorMessage = "Text is required")]
        public string Text { get; set; }

        [Required(ErrorMessage = "User is required")]
        public string UserId { get; set; }
        
        [ForeignKey("UserId")]
        public virtual ExtendedUser User { get; set; }
      
        [Required(ErrorMessage = "Film is required")]
        public int FilmId { get; set; }

        [ForeignKey("FilmId")]
        public virtual Film Film { get; set; }

        public bool IsAdmin { get; set; }
    }
}