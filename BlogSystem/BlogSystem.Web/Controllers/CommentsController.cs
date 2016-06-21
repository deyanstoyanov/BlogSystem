namespace BlogSystem.Web.Controllers
{
    using System.Web.Mvc;

    using BlogSystem.Data.Models;
    using BlogSystem.Data.UnitOfWork;
    using BlogSystem.Web.Models.CommentInputModels;

    [Authorize]
    public class CommentsController : BaseController
    {
        public CommentsController(IBlogSystemData data)
            : base(data)
        {
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int id, CommentInputModel comment)
        {
            if (this.ModelState.IsValid)
            {
                var newComment = new PostComment { Content = comment.Content, BlogPostId = id, User = this.UserProfile };

                this.Data.PostComments.Add(newComment);
                this.Data.SaveChanges();

                return this.RedirectToAction("Post", "Blog", new { id });
            }

            return this.Content("Content is required");
        }
    }
}