using Microsoft.EntityFrameworkCore;
using MusicPortal.DAL.Interface;
using MusicPortal.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MusicPortal.DAL.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private AppDbContext _db;
        private DbSet<TEntity> dbSet;
        public Repository(AppDbContext db)
        {
            _db = db;
            dbSet = db.Set<TEntity>();
        }



        public async Task<TEntity> CreateAsync(TEntity item)
        {
            await dbSet.AddRangeAsync(item);
            return item;
        }


        public async Task DeleteAsync(TEntity item)
        {
            dbSet.Remove(item);
        }


        public IQueryable<TEntity> GetAll()
        {
            
            
            return dbSet.AsQueryable().AsNoTracking();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] incl)
        {
            var data = dbSet.Where(predicate);
            if (incl != null)
            {
                data = incl.Aggregate(data, (current, inclusion) => current.Include(inclusion));
            }
            return data.FirstOrDefault();
        }



        public async Task<TEntity> UpdateAsync(TEntity item)
        {
            _db.Update(item);
            return item;
        }

        public async Task<TEntity> GetNoTrackingAsync(Expression<Func<TEntity, bool>>? predicate, Expression<Func<TEntity, object>>[]? incl = null)
        {
            var data = dbSet.Where(predicate).AsNoTracking();
            if (incl != null)
            {
                data = incl.Aggregate(data, (current, inclusion) => current.Include(inclusion));
            }
            return data.FirstOrDefault();
        }
    }
}
