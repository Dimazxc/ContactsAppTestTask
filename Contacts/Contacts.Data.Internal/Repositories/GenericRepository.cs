using Contacts.Data.Contracts.Entities.Base;
using Contacts.Data.Contracts.Repositories.Base;
using Contacts.Data.Internal.Contexts;

namespace Contacts.Data.Internal.Repositories
{
    public class GenericRepository<TEntity> : CommonGenericRepository<TEntity, long>, IGenericRepository<TEntity>
        where TEntity : EntityBase
    {
        public GenericRepository(ContactsDbContext context)
            : base(context)
        {
        }
    }
}