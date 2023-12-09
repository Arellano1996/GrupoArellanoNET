using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoArellano.Persistence.Repository
{
  public interface IAsyncRepository
  {
    Task<T> GetAsync<T>(object id) where T : class;
    Task<IEnumerable<T>> GetAllAsync<T>() where T : class;
    Task<IEnumerable<T>> FindAsync<T>(ISpecification<T> specification) where T : class;
    Task<IEnumerable<T>> FindAsyncAsNoTracking<T>(ISpecification<T> specification) where T : class;
    Task<int> CountAsync<T>(ISpecification<T> specification) where T : class;
    Task<T> AddAsync<T>(T entity) where T : class;
    Task UpdateAsync<T>(T entity) where T : class;
    Task UpdateEntityNotTrackedAsync<T>(T entity) where T : class;
    Task DeleteAsync<T>(T entity) where T : class;
    Task<IReadOnlyList<T>> GetPagedReponseAsync<T>(int page, int size) where T : class;
  }
}
