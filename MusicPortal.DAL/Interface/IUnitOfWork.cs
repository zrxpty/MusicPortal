using MusicPortal.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPortal.DAL.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        public IRepository<T> GetRepository<T>() where T : class;
        public void Save();
        public Task SaveChangesAsync();
    }
}
