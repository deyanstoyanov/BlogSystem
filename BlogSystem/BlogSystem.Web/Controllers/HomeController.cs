namespace BlogSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using BlogSystem.Data.UnitOfWork;
    using BlogSystem.Web.Models.HomeViewModels;

    public class HomeController : BaseController
    {
        public HomeController(IBlogSystemData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            var posts = this.Data.Posts.All().ProjectTo<BlogPostConciseViewModel>();

            var model = new IndexPageViewModel { Posts = posts.ToList() };

            return this.View(model);
        }

        public ActionResult About()
        {
            this.ViewBag.Message = "Your application description page.";

            return this.View();
        }

        public ActionResult Contact()
        {
            this.ViewBag.Message = "Your contact page.";

            return this.View();
        }
    }
}