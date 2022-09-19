using Contacts.Application.ViewModels;
using MediatR;

namespace Contacts.Application.Queries.GetContactById
{
    public class GetContactByIdQuery: IRequest<ContactVM>
    {
        public long Id { get; set; }
    }
}