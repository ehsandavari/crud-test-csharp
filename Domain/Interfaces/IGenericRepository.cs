using System.Linq.Expressions;

namespace Domain.Interfaces;

public interface IGenericRepository<T> where T : class
{
    IEnumerable<T> FindAll();
    T? Find(long id);
    IEnumerable<T> Find(Expression<Func<T, bool>> expression);
    bool IsExists(Expression<Func<T, bool>> expression);
    IOrderedQueryable<T> OrderByDescending(Expression<Func<T, object>> expression);
    IOrderedQueryable<T> OrderByAscending(Expression<Func<T, object>> expression);
    void Add(T entity);
    void AddRange(IEnumerable<T> entities);
    void Update(T entity);
    void UpdateRange(IEnumerable<T> entities);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);
}