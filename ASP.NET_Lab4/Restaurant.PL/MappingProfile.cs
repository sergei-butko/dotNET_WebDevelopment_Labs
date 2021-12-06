using Restaurant.DAL.Models;
using Restaurant.PL.ViewModels;
using AutoMapper;

namespace Restaurant.PL
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Meal, MealViewModel>();
            CreateMap<Order, OrderViewModel>();

            // CreateMap<Album, AlbumViewModel>()
            //     .ForMember(dest => dest.ArtistName, opt => opt.MapFrom(src => src.Artist.Name));
        }
    }
}