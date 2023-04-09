using AutoMapper;
using MusicPortal.BLL.DTO;
using MusicPortal.DAL.Models;
using MusicPortal.WEB.Models.ViewModels;
using System.Collections.Generic;

namespace MusicPortal.WEB.AutoMapperProfiles
{
    public class AuthorProfile: Profile
    {
        public AuthorProfile() {
            CreateMap<Author, AuthorDTO>().ReverseMap();
            CreateMap<AuthorDTO, AuthorVM>().ReverseMap();
            CreateMap<AuthorVM, Author>().ReverseMap();
            CreateMap<Author, AuthorVM>().ReverseMap();
            

        }
    }
}
