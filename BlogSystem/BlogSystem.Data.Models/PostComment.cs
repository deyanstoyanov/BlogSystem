namespace BlogSystem.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using BlogSystem.Data.Common.Models;

    public class PostComment : AuditInfo, IDeletableEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [AllowHtml]
        public string Content { get; set; }

        [Required]
        public int BlogPostId { get; set; }

        public virtual BlogPost BlogPost { get; set; }

        public virtual ApplicationUser User { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}