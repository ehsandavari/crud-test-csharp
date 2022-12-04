using System.Linq.Expressions;
using Domain.Interfaces;

namespace Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly DataBaseContext DataBaseContext;

    protected GenericRepository(DataBaseContext dataBaseContext)
    {
        DataBaseContext = dataBaseContext;
    }

    public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
    {
        return DataBaseContext.Set<T>().Where(expression);
    }

    public bool IsExists(Expression<Func<T, bool>> expression)
    {
        return DataBaseContext.Set<T>().Any(expression);
    }

    public IEnumerable<T> FindAll()
    {
        return DataBaseContext.Set<T>().ToList();
    }

    public IOrderedQueryable<T> OrderByAscending(Expression<Func<T, object>> expression)
    {
        return DataBaseContext.Set<T>().OrderBy(expression);
    }

    public IOrderedQueryable<T> OrderByDescending(Expression<Func<T, object>> expression)
    {
        return DataBaseContext.Set<T>().OrderByDescending(expression);
    }

    public T? Find(long id)
    {
        return DataBaseContext.Set<T>().Find(id);
    }

    public void Add(T entity)
    {
        DataBaseContext.Set<T>().Add(entity);
    }

    public void AddRange(IEnumerable<T> entities)
    {
        DataBaseContext.Set<T>().AddRange(entities);
    }

    public void Update(T entity)
    {
        DataBaseContext.Set<T>().Update(entity);
    }

    public void UpdateRange(IEnumerable<T> entities)
    {
        DataBaseContext.Set<T>().UpdateRange(entities);
    }

    public void Remove(T entity)
    {
        DataBaseContext.Set<T>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        DataBaseContext.Set<T>().RemoveRange(entities);
    }
}