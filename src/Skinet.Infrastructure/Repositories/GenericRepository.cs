using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Skinet.Core.Domain.Entities;
using Skinet.Core.Domain.RepositoryContracts;
using Skinet.Core.Domain.Specifications;
using Skinet.Infrastructure.Data;
using Skinet.Infrastructure.SpecificationEvaluator;

namespace Skinet.Infrastructure.Repositories
{
  public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
  {
    private readonly StoreDbContext _db;

    public GenericRepository(StoreDbContext db)
    {
        _db = db;
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        T? matchingItem = await _db.Set<T>().FirstOrDefaultAsync(temp => temp.Id == id);

        if (matchingItem == null)
        {
            throw new ArgumentException(nameof(matchingItem));
        }

        return matchingItem;
    }

    public async Task<List<T>> ListAllAsync()
    {
        List<T> matchingItems = await _db.Set<T>().ToListAsync();

        return matchingItems;
    }

    public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
    {
      return await ApplySpecification(spec).FirstOrDefaultAsync();
    }

    public async Task<List<T>> ListAsync(ISpecification<T> spec)
    {
      return await ApplySpecification(spec).ToListAsync();
    }

    public async Task<int> CountAsync(ISpecification<T> spec)
    {
      return await ApplySpecification(spec).CountAsync();
    }

    private IQueryable<T> ApplySpecification(ISpecification<T> spec)
    {
      return SpecificationEvaluator<T>.GetQuery(_db.Set<T>().AsQueryable(), spec);
    }
  }
}