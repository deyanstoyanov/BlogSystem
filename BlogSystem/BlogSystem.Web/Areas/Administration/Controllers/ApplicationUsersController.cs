namespace BlogSystem.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using BlogSystem.Data.UnitOfWork;
    using BlogSystem.Web.Areas.Administration.Models.ApplicationUsersViewModels;

    public class ApplicationUsersController : AdministrationController
    {
        public ApplicationUsersController(IBlogSystemData data)
            : base(data)
        {
        }

        // GET: Administration/ApplicationUsers
        public ActionResult Index()
        {
            var model = this.Data.Users.All().ProjectTo<ApplicationUserViewModel>().ToList();

            return this.View(model);
        }

        // GET: Administration/ApplicationUsers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var applicationUser = this.Data.Users.Find(id);
            if (applicationUser == null)
            {
                return this.HttpNotFound();
            }

            return this.View(applicationUser);
        }
    }
}