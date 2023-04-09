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
    public interface IAuthorService
    {
        Task AddAuthorAsync(Guid modelId, Guid author);
        Task RemoveSubAuthorAsync(Guid modelId, Guid author);
        Task<AuthorDTO> GetAsync(Expression<Func<Author, bool>>? predicate);
        ICollection<AuthorDTO> GetAll();
        Task DeleteAsync(Guid id);
        /*ICollection<MusicDTO> GetAllMyMusic(Author author);*/
        Task<AuthorDTO> UpdateAsync(AuthorDTO item);
        void Dispose();
    }
}
