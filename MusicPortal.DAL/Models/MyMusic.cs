using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPortal.DAL.Models
{
    public class MyMusic
    {
        public Guid Id { get; set; }
        public Author Author { get; set; }
        public Music Musics { get; set; }
    }
}
