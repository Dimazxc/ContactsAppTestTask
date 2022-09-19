using AutoMapper;
using Contacts.Application.ViewModels;
using Contacts.Data.Contracts.Entities;

namespace Contacts.Application.AutoMapper
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            ContactConfig();
        }

        private void ContactConfig()
        {
            CreateMap<Contact, ContactVM>()
                .ForMember(dst => dst.Id,
                    opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.Name,
                    opt => opt.MapFrom(src => src.Name))
                .ForMember(dst => dst.JobTitle, 
                    opt => opt.MapFrom(src => src.JobTitle))
                .ForMember(dst => dst.MobilePhone, opt => opt.MapFrom(src => src.MobilePhone))
                .ForMember(dst => dst.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
                .ReverseMap();
        }
    }
}