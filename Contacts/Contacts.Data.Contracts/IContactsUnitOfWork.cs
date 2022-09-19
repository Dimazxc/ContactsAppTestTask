using System.Threading.Tasks;
using Contacts.Data.Contracts.Entities;
using Contacts.Data.Contracts.Repositories.Base;

namespace Contacts.Data.Contracts
{
    public interface IContactsUnitOfWork
    {
        Task CommitChangesAsync();
        
        IGenericRepository<Contact> ContactRepository { get; }
    }
}