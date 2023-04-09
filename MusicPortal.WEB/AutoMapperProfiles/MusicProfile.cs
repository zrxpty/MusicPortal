using AutoMapper;
using MusicPortal.BLL.DTO;
using MusicPortal.DAL.Models;
using MusicPortal.WEB.Models.ViewModels;

namespace MusicPortal.WEB.AutoMapperProfiles
{
    public class MusicProfile : Profile
    {
        public MusicProfile() { 
            CreateMap<Music, MusicDTO>().ReverseMap();
            CreateMap<MusicDTO, MusicVM>().ReverseMap();
            CreateMap<Music, MusicVM>().ReverseMap();
        }
    }
}
