namespace BlogSystem.Web.Areas.Administration.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    using BlogSystem.Data.Models;
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

        // GET: Administration/PostComments/Edit/5
        public ActionResult Edit(int? id)
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

            this.ViewBag.BlogPostId = new SelectList(this.Data.Posts.All(), "Id", "Title", postComment.BlogPostId);
            this.ViewBag.UserId = new SelectList(this.Data.Users.All(), "Id", "Email", postComment.UserId);

            return this.View(postComment);
        }

        // POST: Administration/PostComments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include = "Id,Content,BlogPostId,UserId,IsDeleted,DeletedOn,CreatedOn,ModifiedOn")] PostComment
                postComment)
        {
            if (this.ModelState.IsValid)
            {
                this.Data.PostComments.Update(postComment);
                this.Data.SaveChanges();

                return this.RedirectToAction("Index");
            }

            this.ViewBag.BlogPostId = new SelectList(this.Data.Posts.All(), "Id", "Title", postComment.BlogPostId);
            this.ViewBag.UserId = new SelectList(this.Data.Users.All(), "Id", "Email", postComment.UserId);

            return this.View(postComment);
        }
    }
}