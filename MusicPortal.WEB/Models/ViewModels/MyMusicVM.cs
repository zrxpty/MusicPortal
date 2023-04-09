
using MusicPortal.DAL.Models;
using System.Collections.Generic;
using System;

namespace MusicPortal.WEB.Models.ViewModels
{
    public class MyMusicVM
    {
        public Guid Id { get; set; }
        public Author Author { get; set; }
        public Music Musics { get; set; }
    }
}
