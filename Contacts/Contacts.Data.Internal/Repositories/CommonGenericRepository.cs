using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contacts.Data.Contracts.Repositories.Base;
using Contacts.Data.Internal.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Data.Internal.Repositories
{
    public class CommonGenericRepository<TEntity, TKey> : ICommonGenericRepository<TEntity, TKey>
        where TKey : IEquatable<TKey>
        where TEntity : class, IHasKey<TKey>
    {
        private readonly ContactsDbContext _context;
        protected readonly DbSet<TEntity> dbSet;

        protected CommonGenericRepository(ContactsDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            dbSet = context.Set<TEntity>();
        }
        
        public async Task<IList<TEntity>> GetAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async Task AddAsync(TEntity entity)
        {
            await dbSet.AddAsync(entity);
        }

        public async ValueTask<TEntity> FindByIdAsync(TKey id)
        {
            return await dbSet.FindAsync(id);
        }

        public void Update(TEntity entity)
        {
            dbSet.Update(entity);
        }

        public void Remove(TEntity entity)
        {
            dbSet.Remove(entity);
        }
    }
}