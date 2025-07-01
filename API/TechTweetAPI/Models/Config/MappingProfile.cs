using AutoMapper;
using TechTweetAPI.Models.Domain;
using TechTweetAPI.Models.DTO;

namespace TechTweetAPI.Models.Config
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryCreateDto>().ReverseMap();
            CreateMap<Category, CategoryUpdateDto>().ReverseMap();

            CreateMap<Post, PostDto>().ReverseMap();
            CreateMap<Post, PostCreateDto>().ReverseMap();
            CreateMap<Post, PostUpdateDto>().ReverseMap();
        }
    }
}
