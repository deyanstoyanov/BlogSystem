namespace BlogSystem.Web.Models.HomeViewModels
{
    using System;

    using AutoMapper;

    using BlogSystem.Data.Models;
    using BlogSystem.Web.Infrastructure.Mapping;

    public class BlogPostConciseViewModel : IMapFrom<BlogPost>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<BlogPost, BlogPostConciseViewModel>()
                .ForMember(model => model.Author, config => config.MapFrom(post => post.Author.UserName));
        }
    }
}