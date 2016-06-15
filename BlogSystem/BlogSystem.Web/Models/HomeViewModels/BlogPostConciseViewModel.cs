namespace BlogSystem.Web.Models.HomeViewModels
{
    using System;

    using BlogSystem.Data.Models;
    using BlogSystem.Web.Infrastructure.Mapping;

    public class BlogPostConciseViewModel : IMapFrom<BlogPost>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}