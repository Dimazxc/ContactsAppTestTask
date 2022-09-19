using System.Threading.Tasks;
using Contacts.Common.Attributes;
using Contacts.Common.Configuration;
using Contacts.Data.Contracts;
using Contacts.Data.Contracts.Entities;
using Contacts.Data.Contracts.Repositories.Base;
using Contacts.Data.Internal.Contexts;
using Contacts.Data.Internal.Repositories;

namespace Contacts.Data.Internal
{
    [Dependency(Lifetime = LifetimeScope.Scoped)]
    public class ContactsUnitOfWork : IContactsUnitOfWork
    {
        private readonly ContactsDbContext _context;

        private GenericRepository<Contact> _contactRepository;

        public ContactsUnitOfWork(
            ContactsDbContext context)
        {
            _context = context;
        }
        
        public IGenericRepository<Contact> ContactRepository => 
            _contactRepository ??= new GenericRepository<Contact>(_context);
        
        public async Task CommitChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}