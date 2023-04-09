using MusicPortal.DAL.Enum;
using MusicPortal.DAL.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace MusicPortal.WEB.Models.ViewModels
{
    public class MusicVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public GenreEnum Genre { get; set; }

        public Author Author { get; set; }

        public string filesMusic { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
