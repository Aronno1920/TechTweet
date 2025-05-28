using AutoMapper;
using TechTweetAPI.Models.Domain;
using TechTweetAPI.Models.DTO.Category;

namespace TechTweetAPI.Models.Config
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
        }
    }
}
