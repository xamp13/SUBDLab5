using System.ComponentModel.DataAnnotations;

namespace SUBDLab5.Models
{
    public class Subscription
    {
        public int Id { get; set; }

        [Required]
        public int UsernameId { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public virtual Username Username { get; set; }

        public virtual Category Category { get; set; }
    }
}