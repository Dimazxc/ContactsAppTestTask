using System;
using MediatR;

namespace Contacts.Application.Commands.UpdateContact
{
    public class UpdateContactCommand : IRequest<Unit>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        
        public string JobTitle { get; set; }
        
        public string MobilePhone { get; set; }
        
        public DateTime BirthDate { get; set; }
    }
}