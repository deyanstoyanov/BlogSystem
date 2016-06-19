namespace BlogSystem.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using BlogSystem.Data.UnitOfWork;
    using BlogSystem.Web.Areas.Administration.Models.HomeViewModels;

    public class HomeController : AdministrationController
    {
        public HomeController(IBlogSystemData data)
            : base(data)
        {
        }

        // GET: Administration/Home
        public ActionResult Index()
        {
            var blogPosts = this.Data.Posts.All().Count();
            var model = new IndexAdminPageViewModel { BlogPostsCount = blogPosts };

            return this.View(model);
        }
    }
}