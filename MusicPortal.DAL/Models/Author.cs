using Microsoft.AspNetCore.Identity;
using MusicPortal.DAL.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPortal.DAL.Models
{
    public class Author: IdentityUser
    {
        
        public string NickName { get; set; }
        public ICollection<Music>? Musics { get; set; }

        
        public DateTime? Age { get; set; }

        public GenreEnum? mainGenre { get; set; }

        public string imagePath { get; set; }

        public string? Biography { get; set; }

        public string? linkInstagram { get; set; }

        public string? linkVK { get; set; }

        public string? linkYouTube { get; set; }

        public string? linkOther { get; set; }

        public List<Author> Subscribe { get; set; } =  new List<Author>();
        public List<Author> Subscribers { get; set; } = new List<Author>();
    }
}
