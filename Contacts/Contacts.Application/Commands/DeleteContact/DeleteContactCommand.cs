using System.Net;
using MediatR;

namespace Contacts.Application.Commands.DeleteContact
{
    public class DeleteContactCommand : IRequest<HttpStatusCode>
    {
        public long Id { get; set; }
    }
}