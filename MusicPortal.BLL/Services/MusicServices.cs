using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MusicPortal.BLL.DTO;
using MusicPortal.BLL.Interfaces;
using MusicPortal.DAL;
using MusicPortal.DAL.Interface;
using MusicPortal.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MusicPortal.BLL.Services
{
    public class MusicServices : IMusicService
    {
        private IUnitOfWork _uow { get; set; }
        private IMapper _mapper;

        public MusicServices(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        

        public async Task<MusicDTO> AddAsync(MusicDTO item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            Music music = _mapper.Map<Music>(item);
            


            await _uow.GetRepository<Music>().CreateAsync(music);
            await _uow.SaveChangesAsync();


            return item;
        }

        

        public async Task DeleteAsync(Guid id)
        {
            Music music = await _uow.GetRepository<Music>().GetAsync(x => x.Id == id);
            if (music != null)
            {
                await _uow.GetRepository<Music>().DeleteAsync(music);
                await _uow.SaveChangesAsync();
            }
        }

        public void Dispose()
        {
            _uow.Dispose();
        }

       

        public ICollection<MusicDTO> GetAll()
        {
            return _mapper.Map<ICollection<MusicDTO>>(_uow.GetRepository<Music>().GetAll().Include(music => music.Author));
        }

        public ICollection<MusicDTO> GetAllMyMusic(Author author)
        {
            return _mapper.Map<ICollection<MusicDTO>>(_uow.GetRepository<Music>().GetAll()
                .Include(music => music.Author)
                .Where(a => a.AuthorId == author.Id));
        }

        public async Task<MusicDTO> GetAsync(Expression<Func<Music, bool>>? predicate)
        {
           
            return _mapper.Map<MusicDTO>(await _uow.GetRepository<Music>().GetAsync(predicate, x=> x.Author));
        }

        

        public async Task<MusicDTO> UpdateAsync(MusicDTO item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            Music music = await _uow.GetRepository<Music>().GetAsync(x => x.Id == item.Id);
            if (music == null)
            {
                music = _mapper.Map<Music>(item);
            }

            _mapper.Map(item, music);

            music = await _uow.GetRepository<Music>().UpdateAsync(music);
            await _uow.SaveChangesAsync();
            return _mapper.Map<MusicDTO>(music);
        }
    }
}
