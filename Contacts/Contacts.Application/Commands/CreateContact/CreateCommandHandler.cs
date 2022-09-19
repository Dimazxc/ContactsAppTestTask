using System.Threading;
using System.Threading.Tasks;

using Contacts.Data.Contracts;
using Contacts.Data.Contracts.Entities;
using MediatR;

namespace Contacts.Application.Commands.CreateContact
{
    public class CreateCommandHandler : IRequestHandler<CreateContactCommand, long>
    {
        private readonly IContactsUnitOfWork _unitOfWork;

        public CreateCommandHandler(IContactsUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<long> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var contact = new Contact
            {
                Name = request.Name,
                JobTitle = request.JobTitle,
                BirthDate = request.BirthDate,
                MobilePhone = request.MobilePhone
            };

            await _unitOfWork.ContactRepository.AddAsync(contact);
            await _unitOfWork.CommitChangesAsync();
            
            return contact.Id;
        }
    }
}