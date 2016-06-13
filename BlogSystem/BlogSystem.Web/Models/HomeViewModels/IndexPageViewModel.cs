namespace BlogSystem.Web.Models.HomeViewModels
{
    using BlogSystem.Data.Models;
    using BlogSystem.Web.Infrastructure.Mapping;

    public class IndexPageViewModel : IMapFrom<BlogPost>
    {
        public string Title { get; set; }
    }
}