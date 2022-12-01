using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PTPichincha.Infraestructure.Persistance.Data;
using PTPichincha.Infraestructure.Persistance.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PTPichincha.Infraestructure.Persistance.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDBContext _dbContext;
        private DbSet<T> _dbSet;    
        public Repository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
            this._dbSet = _dbContext.Set<T>();
        }

        public async Task<T> Add(T Entity)
        {
                await _dbSet.AddAsync(Entity);
                return Entity;
        }
        public async Task<T> Update(T Entity)
        {
            _dbSet.Update(Entity);
            return await Task.FromResult(Entity);
        }

        public async Task<T> FindById(Expression<Func<T, bool>> Id)
        {
           IQueryable<T> query = _dbSet;
#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
            return await query.AsNoTrackingWithIdentityResolution().FirstOrDefaultAsync(Id);


        }
        
        
        public async Task<IEnumerable<T>> GetAll()
        {
            IQueryable<T> query = _dbSet;
            return await query.AsNoTrackingWithIdentityResolution().ToListAsync();
        }

        public async Task<bool> Remove(T Entity)
        {
            _dbContext.Entry<T>(Entity).State = EntityState.Detached;
             _dbSet.Remove(Entity);
            return await  Task.FromResult(true);
        }

        public async Task<int> SaveChanger()
        {
            return await  _dbContext.SaveChangesAsync();
        }

    }
}
