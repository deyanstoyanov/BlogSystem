namespace BlogSystem.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class PostComment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "The {0} must be at least {1} characters long.")]
        public string Content { get; set; }

        [Required]
        public int BlogPostId { get; set; }

        public virtual BlogPost BlogPost { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}