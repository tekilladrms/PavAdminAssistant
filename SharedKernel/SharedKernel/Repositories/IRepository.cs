

using SharedKernel.Primitives;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SharedKernel.Repositories;

public interface IRepository<TEntity> where TEntity : Entity
{
    public Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    public Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
    public void Add(TEntity entity, CancellationToken cancellationToken = default);
    public TEntity Update(TEntity entity, CancellationToken cancellationToken = default);
    public void Delete(Guid id, CancellationToken cancellationToken = default);
    public void Delete(TEntity entity, CancellationToken cancellationToken = default);
}