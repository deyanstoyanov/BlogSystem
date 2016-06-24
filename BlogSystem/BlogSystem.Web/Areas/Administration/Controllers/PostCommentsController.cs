namespace BlogSystem.Web.Areas.Administration.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;

    using BlogSystem.Data.UnitOfWork;

    public class PostCommentsController : AdministrationController
    {
        public PostCommentsController(IBlogSystemData data)
            : base(data)
        {
        }

        // GET: Administration/PostComments
        public ActionResult Index()
        {
            var postComments = this.Data.PostComments.All().Include(p => p.BlogPost).Include(p => p.User).ToList();

            return this.View(postComments);
        }
    }
}