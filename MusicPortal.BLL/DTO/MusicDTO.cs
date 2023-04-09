using MusicPortal.DAL.Enum;
using MusicPortal.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPortal.BLL.DTO
{
    public class MusicDTO
    {
        
        public Guid Id { get; set; }
        public string Name { get; set; }
       
        public GenreEnum Genre { get; set; }
        public Author Author { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public string filesMusic { get; set; }
    }
}
