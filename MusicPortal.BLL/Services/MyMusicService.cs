using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MusicPortal.BLL.DTO;
using MusicPortal.BLL.Interfaces;
using MusicPortal.DAL.Interface;
using MusicPortal.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPortal.BLL.Services
{
    public class MyMusicService : IMyMusicInterface
    {
        private IUnitOfWork _uow { get; set; }
        private IMapper _mapper;

        public MyMusicService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task AddAsync(Guid musicGuid, Guid authorGuid)
        {
            var author = await _uow.GetRepository<Author>().GetAsync(x => x.Id == authorGuid.ToString());
            Music music = await _uow.GetRepository<Music>().GetAsync(x => x.Id == musicGuid);

            if (author != null && music != null)
            {
                var existingMyMusic = await _uow.GetRepository<MyMusic>()
                    .GetAsync(mm => mm.Author.Id == author.Id && mm.Musics.Id == music.Id);

                if (existingMyMusic == null)
                {
                    var myMusic = new MyMusic
                    {
                        Author = author,
                        Musics = music
                    };
                    await _uow.GetRepository<MyMusic>().CreateAsync(myMusic);
                    await _uow.SaveChangesAsync();
                }
                // else do nothing, since the music is already added to myMusic
            }
        }
        public async Task DeleteAsync(Guid musicGuid, Guid authorGuid)
        {
            var author = await _uow.GetRepository<Author>().GetAsync(x => x.Id == authorGuid.ToString());
            Music music = await _uow.GetRepository<Music>().GetAsync(x => x.Id == musicGuid);

            if (author != null && music != null)
            {
                var myMusic = await _uow.GetRepository<MyMusic>()
                    .GetAsync(mm => mm.Author.Id == author.Id && mm.Musics.Id == music.Id);

                if (myMusic != null)
                {
                    await _uow.GetRepository<MyMusic>().DeleteAsync(myMusic);
                    await _uow.SaveChangesAsync();
                }
                
            }
        }


        public ICollection<MyMusicDTO> GetAll(Guid idAuthor)
        {
            return _mapper.Map<ICollection<MyMusicDTO>>
                (_uow.GetRepository<MyMusic>()
                .GetAll()
                .Include(music => music.Author)
                .Include(x=>x.Musics).Where(x=> x.Author.Id == idAuthor.ToString()));

            
        }
    }
}
