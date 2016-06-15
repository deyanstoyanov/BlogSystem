namespace BlogSystem.Web.Models.HomeViewModels
{
    using System.Collections.Generic;

    public class IndexPageViewModel
    {
        public IEnumerable<BlogPostConciseViewModel> Posts { get; set; }
    }
}