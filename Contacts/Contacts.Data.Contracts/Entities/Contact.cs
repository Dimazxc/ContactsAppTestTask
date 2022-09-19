using System;

using Contacts.Data.Contracts.Entities.Base;

namespace Contacts.Data.Contracts.Entities
{
    public class Contact : EntityBase
    {
        public string Name { get; set; }
        
        public string JobTitle { get; set; }
        
        public string MobilePhone { get; set; }
        
        public DateTime BirthDate { get; set; }
    }
}