using System;

namespace Contacts.Application.ViewModels
{
    public class ContactVM
    {
        public long Id { get; set; }
        
        public string Name { get; set; }
        
        public string JobTitle { get; set; }
        
        public string MobilePhone { get; set; }
        
        public DateTime BirthDate { get; set; }
    }
}