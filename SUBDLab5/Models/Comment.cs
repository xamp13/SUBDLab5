using System.ComponentModel.DataAnnotations;

namespace SUBDLab5.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        public string Comment_Text { get; set; }

        [Required]
        public int NewsId { get; set; }

        [Required]
        public int UsernameId { get; set; }

        public virtual News News { get; set; }

        public virtual Username Username { get; set; }
    }
}