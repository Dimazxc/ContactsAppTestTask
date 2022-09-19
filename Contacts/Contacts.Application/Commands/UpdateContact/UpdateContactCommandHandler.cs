using System.Threading;
using System.Threading.Tasks;
using Contacts.Data.Contracts;
using Contacts.Data.Contracts.Entities;
using MediatR;

namespace Contacts.Application.Commands.UpdateContact
{
    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, Unit>
    {
        private readonly IContactsUnitOfWork _unitOfWork;
        
        public UpdateContactCommandHandler(IContactsUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<Unit> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var updatedContact = new Contact()
            {
                Id = request.Id,
                Name = request.Name,
                JobTitle = request.JobTitle,
                MobilePhone = request.MobilePhone,
                BirthDate = request.BirthDate
            };

            _unitOfWork.ContactRepository.Update(updatedContact);
            await _unitOfWork.CommitChangesAsync();
            
            return Unit.Value;;
        }
    }
}