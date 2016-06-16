namespace BlogSystem.Web.Areas.Administration.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;

    using BlogSystem.Data.Models;
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

        // GET: Administration/BlogPosts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var blogPost = this.Data.Posts.Find(id);
            if (blogPost == null)
            {
                return this.HttpNotFound();
            }

            return this.View(blogPost);
        }

        // GET: Administration/BlogPosts/Create
        public ActionResult Create()
        {
            return this.View();
        }

        // POST: Administration/BlogPosts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = "Id,Title,Content,AuthorId,IsDeleted,DeletedOn,CreatedOn,ModifiedOn")] BlogPost blogPost)
        {
            if (blogPost != null)
            {
                blogPost.Author = this.UserProfile;
                blogPost.AuthorId = this.UserProfile.Id;

                if (this.ModelState.IsValid)
                {
                    this.Data.Posts.Add(blogPost);
                    this.Data.SaveChanges();
                    return this.RedirectToAction("Index");
                }
            }

            return this.View(blogPost);
        }
    }
}