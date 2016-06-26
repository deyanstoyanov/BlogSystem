namespace BlogSystem.Web.Areas.Administration.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
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

        // GET: Administration/PostComments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var postComment = this.Data.PostComments.Find(id);
            if (postComment == null)
            {
                return this.HttpNotFound();
            }

            return this.View(postComment);
        }
    }
}