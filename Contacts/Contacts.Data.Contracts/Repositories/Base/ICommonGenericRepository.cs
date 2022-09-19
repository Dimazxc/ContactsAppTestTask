using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contacts.Data.Contracts.Repositories.Base
{
    public interface ICommonGenericRepository<TEntity, TKey>
        where  TKey: IEquatable<TKey>
        where TEntity: IHasKey<TKey>
    {
        Task<IList<TEntity>> GetAsync();

        Task AddAsync(TEntity entity);

        ValueTask<TEntity> FindByIdAsync(TKey id);

        void Update(TEntity entity);

        void Remove(TEntity entity);
    }
}