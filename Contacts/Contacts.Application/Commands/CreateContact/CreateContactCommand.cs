using System;
using MediatR;

namespace Contacts.Application.Commands.CreateContact
{
    public sealed class CreateContactCommand : IRequest<long>
    {
        public string Name { get; set; }
        
        public string JobTitle { get; set; }
        
        public string MobilePhone { get; set; }
        
        public DateTime BirthDate { get; set; }
    }
}