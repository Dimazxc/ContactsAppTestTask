using Contacts.Data.Contracts.Entities.Base;

namespace Contacts.Data.Contracts.Repositories.Base
{
    public interface IGenericRepository<TEntity> :
        ICommonGenericRepository<TEntity, long>
        where TEntity : EntityBase
    {
    }
}