using System;
using Contacts.Common.Configuration;

namespace Contacts.Common.Attributes
{
    public class DependencyAttribute : Attribute
    {
        public LifetimeScope Lifetime { get; set; }
    }
}