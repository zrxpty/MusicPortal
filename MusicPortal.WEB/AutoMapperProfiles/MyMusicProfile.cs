using AutoMapper;
using MusicPortal.BLL.DTO;
using MusicPortal.DAL.Models;
using MusicPortal.WEB.Models.ViewModels;

namespace MusicPortal.WEB.AutoMapperProfiles
{
    public class MyMusicProfile : Profile
    {
        public MyMusicProfile() {
            CreateMap<MyMusic, MyMusicDTO>().ReverseMap();
            CreateMap<MyMusicDTO, MyMusicVM>().ReverseMap();
            CreateMap<MyMusic, MyMusicVM>().ReverseMap();
        }

    }
}
