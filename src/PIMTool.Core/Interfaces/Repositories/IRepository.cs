using System.Linq.Expressions;

namespace PIMTool.Core.Interfaces.Repositories
{
    public interface IRepository<T>
    {
        IQueryable<T> Get();

        Task<T?> GetAsync(decimal id, CancellationToken cancellationToken = default);

        Task<IEnumerable<T>> GetAsync(Expression<Func<T,bool>>? filter = null, string includeProperties = "", Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null);

        Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);

        Task AddAsync(T entity, CancellationToken cancellationToken = default);

        void Delete(params T[] entities);

        Task SaveChangesAsync(CancellationToken cancellationToken = default);

        void Update(T entity);
    }
}