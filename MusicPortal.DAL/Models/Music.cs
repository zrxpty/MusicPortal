using MusicPortal.DAL.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MusicPortal.DAL.Models
{
    public class Music
    {
        [Key]
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        [Required]
        [EnumDataType(typeof(GenreEnum))]
        
        public GenreEnum Genre { get; set; }


        public string AuthorId { get; set; }
        public Author? Author { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string filesMusic { get; set; }
        
    }
}
