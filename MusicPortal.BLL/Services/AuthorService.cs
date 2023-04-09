using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MusicPortal.BLL.DTO;
using MusicPortal.BLL.Interfaces;
using MusicPortal.DAL.Interface;
using MusicPortal.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MusicPortal.BLL.Services
{
    public class AuthorService : IAuthorService
    {
        private IUnitOfWork _uow { get; set; }
        private IMapper _mapper;

        public AuthorService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }


        public async Task<AuthorDTO> GetAsync(Expression<Func<Author, bool>> predicate)
        {
            return _mapper.Map<AuthorDTO>(await _uow.GetRepository<Author>().GetAsync(predicate, x=> x.Musics, x => x.Subscribers, x=>x.Subscribe));
        }

        public ICollection<AuthorDTO> GetAll() 
        { 
            return _mapper.Map<ICollection<AuthorDTO>>(_uow.GetRepository<Author>().GetAll().Include(x => x.Subscribe).Include(x => x.Subscribers).Include(x=> x.Musics));
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<AuthorDTO> UpdateAsync(AuthorDTO item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            Author author = await _uow.GetRepository<Author>().GetAsync(x => x.Id == item.Id);
            if (author == null)
            {
                author = _mapper.Map<Author>(item);
            }

            _mapper.Map(item, author);

            author = await _uow.GetRepository<Author>().UpdateAsync(author);
            await _uow.SaveChangesAsync();
            return _mapper.Map<AuthorDTO>(author);
        }
        public async Task AddAuthorAsync(Guid authorGuid, Guid authorToSubGuid)
        {
            var author = await _uow.GetRepository<Author>().GetAsync(x => x.Id == authorGuid.ToString());
            var authorToSub = await _uow.GetRepository<Author>().GetAsync(x => x.Id == authorToSubGuid.ToString());

            if (author != null && authorToSub != null)
            {
                if (author.Subscribe == null && author.Subscribers == null
                    && authorToSub.Subscribe == null && authorToSub.Subscribers == null)
                    author.Subscribe = new List<Author>();
                
                author.Subscribe.Add(authorToSub);
                authorToSub.Subscribers.Add(author);
                await _uow.SaveChangesAsync();
            }
        }
        public async Task RemoveSubAuthorAsync(Guid authorGuid, Guid authorToUnSubGuid)
        {
            var author = await _uow.GetRepository<Author>().GetAsync(x => x.Id == authorGuid.ToString());
            var authorToUnsub = await _uow.GetRepository<Author>().GetAsync(x => x.Id == authorToUnSubGuid.ToString());

            if (author != null && authorToUnsub != null)
            {
                author.Subscribe?.Remove(authorToUnsub);
                authorToUnsub.Subscribers?.Remove(author);
                await _uow.SaveChangesAsync();
            }
        }






        public void Dispose()
        {
            throw new NotImplementedException();
        }

       
    }
}
