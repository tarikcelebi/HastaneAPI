using HastaneAPI.Context.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HastaneAPI.Context.Repositories.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        public AppDbContext dbContext;
        public DbSet<T> dbset;
        public ILogger logger;

        public GenericRepository(AppDbContext dbContext, ILogger logger)
        {
            this.dbContext = dbContext;
            this.logger = logger;
            this.dbset = dbContext.Set<T>();
        }



        public async Task<bool> Add(T entity)
        {
            await dbset.AddAsync(entity);
            return true;

        }

        public virtual Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> prop)
        {
            return await dbset.Where(prop).ToListAsync();
        }

        public virtual Task<IEnumerable<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        //public async Task<T> GetByID(int id)
        //{
        //    return await dbset.FirstAsync(id);
        //}

        public virtual Task<bool> Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
