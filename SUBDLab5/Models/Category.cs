using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SUBDLab5.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [ForeignKey("CategoryId")]
        public virtual List<News> News { get; set; }

        [ForeignKey("CategoryId")]
        public virtual List<Subscription> Subscriptions { get; set; }
    }
}