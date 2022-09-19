using Contacts.Data.Contracts.Entities;
using Contacts.Data.Internal.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Data.Internal.Contexts
{
    public class ContactsDbContext : DbContext
    {
        public ContactsDbContext(DbContextOptions<ContactsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
        
        protected override void OnConfiguring
            (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "ContactsDb");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContactEntityConfiguration).Assembly);
        }
    }
}