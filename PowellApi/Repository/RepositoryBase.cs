using Microsoft.EntityFrameworkCore;
using PowellApi.Models;
using System.Linq.Expressions;
using PowellApi.Contracts;

namespace PowellApi.Repository
{
  public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
  {
    protected PowellApiContext RepositoryContext { get; set;}
    public RepositoryBase(PowellApiContext repositoryContext)
    {
      this.RepositoryContext = repositoryContext;
    }

    public IQueryable<T> FindAll()
    {
      return this.RepositoryContext.Set<T>()
      .AsNoTracking();
    }

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
    {
      return this.RepositoryContext.Set<T>()
      .Where(expression)
      .AsNoTracking();
    }
  }
}