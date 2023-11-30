using Microsoft.EntityFrameworkCore;

namespace GrupoArellano.Persistence.Repository
{
  public class AsyncRepository : IAsyncRepository
  {
    protected readonly GrupoArellanoDbContext _dbContext;

    public AsyncRepository(GrupoArellanoDbContext dbContext)
    {
      _dbContext = dbContext;
    }

    public virtual async Task<T> GetAsync<T>(object id) where T : class
    {
      if (id == null)
      {
        return null;
      }

      return await _dbContext.Set<T>().FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAllAsync<T>() where T : class
    {
      return await _dbContext.Set<T>().ToListAsync();
    }

    public async Task<IEnumerable<T>> FindAsync<T>(ISpecification<T> specification) where T : class
    {
      if (specification == null)
      {
        return null;
      }
      var query = SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>().AsQueryable(), specification);
      return await query.ToListAsync();
    }

    public async Task<IEnumerable<T>> FindAsyncAsNoTracking<T>(ISpecification<T> specification) where T : class
    {
      if (specification == null)
      {
        return null;
      }
      var query = SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>().AsQueryable(), specification).AsNoTracking();
      return await query.AsNoTracking().ToListAsync();
    }
    public async Task<int> CountAsync<T>(ISpecification<T> specification) where T : class
    {
      if (specification == null)
      {
        throw new ArgumentNullException();
      }
      var query = SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>().AsQueryable(), specification);
      return await query.CountAsync();
    }

    public async virtual Task<IReadOnlyList<T>> GetPagedReponseAsync<T>(int page, int size) where T : class
    {
      return await _dbContext.Set<T>().Skip((page - 1) * size).Take(size).AsNoTracking().ToListAsync();
    }

    public async Task<T> AddAsync<T>(T entity) where T : class
    {
      await _dbContext.Set<T>().AddAsync(entity);
      await _dbContext.SaveChangesAsync();

      return entity;
    }

    public async Task UpdateAsync<T>(T entity) where T : class
    {
      _dbContext.Entry(entity).State = EntityState.Modified;
      await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateEntityNotTrackedAsync<T>(T entity) where T : class
    {
      //En este código, en lugar de cambiar el estado de la entidad existente o tracked, se busca la entidad existente en el contexto(sin rastreo),
      //y luego se copian los valores de la entidad no rastreada a la entidad rastreada.Esto evita el conflicto de rastreo y permitir que los cambios se apliquen correctamente.
      //Esta es una técnica útil cuando trabajas con entidades no rastreadas y necesitas aplicar esos cambios a entidades rastreadas antes de guardar en la base de datos.
      var primaryKey = _dbContext.Model.FindEntityType(typeof(T)).FindPrimaryKey();
      var keyValues = primaryKey.Properties.Select(p => _dbContext.Entry(entity).Property(p.Name).CurrentValue).ToArray();

      var existing = await _dbContext.Set<T>().FindAsync(keyValues);

      if (existing != null)
      {
        _dbContext.Entry(existing).CurrentValues.SetValues(entity);
        await _dbContext.SaveChangesAsync();
      }
      else
      {
        // Manejar la situación donde la entidad no se encuentra en el contexto
        // Puede lanzar una excepción, loggear, o realizar alguna otra acción
        throw new InvalidOperationException($"No se encontró la entidad de tipo {typeof(T)} con las claves primarias especificadas.");
      }
    }

    public async Task DeleteAsync<T>(T entity) where T : class
    {
      _dbContext.Set<T>().Remove(entity);
      await _dbContext.SaveChangesAsync();
    }

    private class SpecificationEvaluator<TEntity> where TEntity : class
    {
      public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec)
      {
        var query = inputQuery;
        if (spec.Criteria != null)
        {
          query = query.Where(spec.Criteria);
        }
        if (spec.OrderBy != null)
        {
          query = query.OrderBy(spec.OrderBy);
        }
        if (spec.OrderByDescending != null)
        {
          query = query.OrderByDescending(spec.OrderByDescending);
        }
        if (spec.Page != null && spec.PageSize != null)
        {
          query = query.Skip((spec.Page.Value - 1) * spec.PageSize.Value).Take(spec.PageSize.Value);
        }
        query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));
        return query;
      }
    }
  }
}
