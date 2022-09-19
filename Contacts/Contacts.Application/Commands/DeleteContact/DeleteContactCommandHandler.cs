using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Contacts.Data.Contracts;
using MediatR;

namespace Contacts.Application.Commands.DeleteContact
{
    public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand, HttpStatusCode>
    {
        private readonly IContactsUnitOfWork _unitOfWork;

        public DeleteContactCommandHandler(IContactsUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<HttpStatusCode> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            var contact = await _unitOfWork.ContactRepository.FindByIdAsync(request.Id);

            if (contact == null)
            {
                return HttpStatusCode.NotFound;
            }
            
            _unitOfWork.ContactRepository.Remove(contact);
            await _unitOfWork.CommitChangesAsync();

            return HttpStatusCode.OK;
        }
    }
}