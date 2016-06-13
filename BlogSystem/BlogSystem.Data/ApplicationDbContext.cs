namespace BlogSystem.Data
{
    using System.Data.Entity;

    using BlogSystem.Data.Models;

    using Microsoft.AspNet.Identity.EntityFramework;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", false)
        {
        }

        public virtual IDbSet<BlogPost> Posts { get; set; }

        public virtual IDbSet<PostComment> PostComments { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}