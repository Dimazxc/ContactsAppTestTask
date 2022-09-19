using System.Collections.Generic;
using Contacts.Application.ViewModels;
using MediatR;

namespace Contacts.Application.Queries.GetContacts
{
    public class GetContactsQuery : IRequest<IEnumerable<ContactVM>>
    {
    }
}