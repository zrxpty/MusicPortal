using MusicPortal.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPortal.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private Dictionary<string, object> _repositories { get; set; }
        private readonly AppDbContext _db;
        private bool disposed = false;

        public EFUnitOfWork(AppDbContext db)
        {
            _db = db;
        }
        public IRepository<T> GetRepository<T>() where T : class
        {
            if (_repositories == null)
                _repositories = new Dictionary<string, object>();

            var type = typeof(T).Name;

            if (!_repositories.ContainsKey(type))
                _repositories.Add(type, new Repository<T>(_db));

            return (Repository<T>)_repositories[type];
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
