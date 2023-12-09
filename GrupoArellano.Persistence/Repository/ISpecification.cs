using System.Linq.Expressions;

namespace GrupoArellano.Persistence.Repository
{
  public interface ISpecification<T>
  {
    Expression<Func<T, bool>> Criteria { get; }
    List<Expression<Func<T, object>>> Includes { get; }
    Expression<Func<T, object>> OrderBy { get; }
    Expression<Func<T, object>> OrderByDescending { get; }
    int? Page { get; }
    int? PageSize { get; }
  }
}
