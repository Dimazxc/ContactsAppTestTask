using Contacts.Common.Constants;
using Contacts.Data.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contacts.Data.Internal.EntityConfigurations
{
    public class ContactEntityConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contacts");

            builder.Property(c => c.Name)
                .HasMaxLength(DataConstants.ContactNameMaxLenght)
                .IsRequired();
            
            builder.Property(c => c.JobTitle)
                .HasMaxLength(DataConstants.ContactJobTitleMaxLenght)
                .IsRequired();
        }
    }
}