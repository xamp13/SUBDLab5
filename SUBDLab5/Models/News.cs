using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SUBDLab5.Models
{
    public class News
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime Date_of_News { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int AuthorId { get; set; }

        public virtual Category Category { get; set; }

        public virtual Author Author { get; set; }

        [ForeignKey("NewsId")]
        public virtual List<Comment> Comments { set; get; }
    }
}