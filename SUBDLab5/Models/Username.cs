using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SUBDLab5.Models
{
    public class Username
    {
        public int Id { get; set; }

        [Required]
        public string Nickname { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        [ForeignKey("UsernameId")]
        public virtual List<Comment> Comments { get; set; }

        [ForeignKey("UsernameId")]
        public virtual List<Subscription> Subscriptions { get; set; }
    }
}