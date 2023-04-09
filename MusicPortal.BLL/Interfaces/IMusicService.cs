using Microsoft.Extensions.Hosting;
using MusicPortal.BLL.DTO;
using MusicPortal.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MusicPortal.BLL.Interfaces
{
    public interface IMusicService
    {
        Task<MusicDTO> AddAsync(MusicDTO item);
        Task<MusicDTO> GetAsync(Expression<Func<Music, bool>>? predicate);
        ICollection<MusicDTO> GetAll();     
        Task DeleteAsync(Guid id);
        ICollection<MusicDTO> GetAllMyMusic(Author author);
        Task<MusicDTO> UpdateAsync(MusicDTO item);
        void Dispose();
    }
}
