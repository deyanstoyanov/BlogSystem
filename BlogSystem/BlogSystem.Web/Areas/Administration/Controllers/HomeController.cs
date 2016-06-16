namespace BlogSystem.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using BlogSystem.Data.UnitOfWork;

    public class HomeController : AdministrationController
    {
        public HomeController(IBlogSystemData data)
            : base(data)
        {
        }

        // GET: Administration/Home
        public ActionResult Index()
        {
            return this.View();
        }
    }
}