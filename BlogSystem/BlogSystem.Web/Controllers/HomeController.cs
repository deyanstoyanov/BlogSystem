namespace BlogSystem.Web.Controllers
{
    using System.Web.Mvc;

    using BlogSystem.Data.Models;
    using BlogSystem.Data.Repositories;
    using BlogSystem.Data.UnitOfWork;
    using AutoMapper.QueryableExtensions;

    using BlogSystem.Web.Models.HomeViewModels;

    public class HomeController : Controller
    {
        private IBlogSystemData data;

        public HomeController()
        {
        }

        public HomeController(IBlogSystemData data )
        {
            this.data = data;
        }
        
        public ActionResult Index()
        {
            var posts = this.data.Posts.All().ProjectTo<IndexPageViewModel>();

            return this.View(posts);
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