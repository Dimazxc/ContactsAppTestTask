using System.Threading;
using System.Threading.Tasks;
using Contacts.Data.Contracts;
using MediatR;

namespace Contacts.Application.Commands.DeleteContact
{
    public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand, Unit>
    {
        private readonly IContactsUnitOfWork _unitOfWork;

        public DeleteContactCommandHandler(IContactsUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            var contact = await _unitOfWork.ContactRepository.FindByIdAsync(request.ContactId);

            if (contact == null)
            {
                return Unit.Value;
            }
            
            _unitOfWork.ContactRepository.Remove(contact);
            await _unitOfWork.CommitChangesAsync();

            return Unit.Value;
        }
    }
}