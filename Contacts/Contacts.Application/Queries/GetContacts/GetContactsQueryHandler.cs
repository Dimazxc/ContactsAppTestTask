using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Contacts.Application.ViewModels;
using Contacts.Data.Contracts;

using MediatR;

namespace Contacts.Application.Queries.GetContacts
{
    public class GetContactsQueryHandler : IRequestHandler<GetContactsQuery, IEnumerable<ContactVM>>
    {
        private readonly IContactsUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        
        public GetContactsQueryHandler(IContactsUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<ContactVM>> Handle(GetContactsQuery request, CancellationToken cancellationToken)
        {
            var contacts = await _unitOfWork.ContactRepository.GetAsync();
            var contactsViewModels = _mapper.Map<IEnumerable<ContactVM>>(contacts);
            
            return contactsViewModels;
        }
    }
}