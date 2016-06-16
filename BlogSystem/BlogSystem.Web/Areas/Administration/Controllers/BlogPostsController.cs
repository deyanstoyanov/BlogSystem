namespace BlogSystem.Web.Areas.Administration.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;

    using BlogSystem.Data.UnitOfWork;

    public class BlogPostsController : AdministrationController
    {
        public BlogPostsController(IBlogSystemData data)
            : base(data)
        {
        }

        // GET: Administration/BlogPosts
        public ActionResult Index()
        {
            var blogPosts = this.Data.Posts.All().Include(b => b.Author);
            return this.View(blogPosts.ToList());
        }
    }
}