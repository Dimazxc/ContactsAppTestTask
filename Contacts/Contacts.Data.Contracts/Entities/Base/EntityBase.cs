using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Contacts.Data.Contracts.Repositories.Base;

namespace Contacts.Data.Contracts.Entities.Base
{
    public abstract class EntityBase : IHasKey<long>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual long Id { get; set; }
    }
}