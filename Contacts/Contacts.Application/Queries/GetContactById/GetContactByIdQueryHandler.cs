using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Contacts.Application.ViewModels;
using Contacts.Data.Contracts;
using MediatR;

namespace Contacts.Application.Queries.GetContactById
{
    public class GetContactByIdQueryHandler : IRequestHandler<GetContactByIdQuery, ContactVM>
    {
        private readonly IContactsUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetContactByIdQueryHandler(IContactsUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ContactVM> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
        {
            var contact = await _unitOfWork.ContactRepository.FindByIdAsync(request.Id);

            return _mapper.Map<ContactVM>(contact);
        }
    }
}