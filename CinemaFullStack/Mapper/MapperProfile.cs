using AutoMapper;
using CinemaFullStackLibrary.Models;
using CinemaFullStackLibrary.RequestModel;
using CinemaFullStackLibrary.ViewModels;

namespace CinemaFullStack.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Cinema,CinemaViewModel>().ReverseMap();
            CreateMap<CinemaHall, CinemaHallViewModel>().ReverseMap();
            CreateMap<Movie, MovieViewModel>().ReverseMap();
            CreateMap<Cinema, CinemaRequestModel>().ReverseMap();
            CreateMap<CinemaHall, CinemaHallRequestModel>().ReverseMap();
            CreateMap<Customer, CustomerRequestModel>().ReverseMap();
            CreateMap<Movie, MovieRequestModel>().ReverseMap();
            CreateMap<TicketSales, TicketSalesViewModel>().ReverseMap();
            CreateMap<Session, SessionRequestModel>().ReverseMap();
            CreateMap<Session, SessionViewModel>().ReverseMap();

          //  CreateMap<Customer, CustomerViewModel>()
              //  .ForMember(src => src.soyadi, opt => opt.MapFrom(dest => dest.soyisim));
        }
    }
}
