using MediatR;

namespace Contacts.Application.Commands.DeleteContact
{
    public class DeleteContactCommand : IRequest<Unit>
    {
        public long ContactId { get; set; }
    }
}