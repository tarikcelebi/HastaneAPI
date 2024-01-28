using HastaneAPI.Entities;
using System.Linq.Expressions;

namespace HastaneAPI.Context.Repositories.Abstract
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        //Task<T> GetByID(int id);
        Task<bool> Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(int id);
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> prop);

    }
}
