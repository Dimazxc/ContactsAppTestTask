using System;

namespace Contacts.Data.Contracts.Repositories.Base
{
    public interface IHasKey<TKey>
        where TKey : IEquatable<TKey>
    {
        TKey Id { get; set; }
    }
}