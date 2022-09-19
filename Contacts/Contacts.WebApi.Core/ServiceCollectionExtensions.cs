using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using AutoMapper;
using Contacts.Application.AutoMapper;
using Contacts.Application.Queries.GetContacts;
using Contacts.Common.Attributes;
using Contacts.Common.Configuration;
using Contacts.Data.Internal;
using Contacts.Data.Internal.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Contacts.WebApi.Core
{
    public static class ServiceCollectionExtensions
    {
        public static void AddContactsContext(this IServiceCollection service, IConfiguration configuration)
        {
            //var connectionString = configuration.GetConnectionString(SectionPaths.DefaultConnectionStringPath);

            var connectionString = "Contacts";
            service.AddDbContext<ContactsDbContext>(options => options.UseInMemoryDatabase(connectionString));
        }

        public static void RegisterAutoMapperProfiles(this IServiceCollection service)
        {
            service.AddAutoMapper(typeof(ContactProfile));
        }

        public static void RegisterMediatr(this IServiceCollection service)
        {
            service.AddMediatR(typeof(GetContactsQueryHandler));
        }

        public static void RegisterDependenciesViaAttribute(this IServiceCollection services)
        {
            var types = GetDependedTypes();

            foreach (var type in types)
            {
                RegisterDependencies(services, type);
            }
        }

        private static IEnumerable<Type> GetDependedTypes()
        {
            var assemblies = new[]
            {
                typeof(ContactsUnitOfWork).Assembly,
            };

            return assemblies.SelectMany(x => x.GetTypes().Where(type => type.IsDefined(typeof(DependencyAttribute))));
        }

        private static void RegisterDependencies(IServiceCollection services, Type type)
        {
            var lifetime = type.GetCustomAttribute<DependencyAttribute>()?.Lifetime ??
                           throw new Exception($"Lifetime is not defined for {type.FullName}");

            foreach (var @interface in type.GetInterfaces())
            {
                switch (lifetime)
                {
                    case LifetimeScope.Transient:
                        services.AddTransient(@interface, type);
                        break;
                    case LifetimeScope.Scoped:
                        services.AddScoped(@interface, type);
                        break;
                    case LifetimeScope.Singleton:
                        services.AddSingleton(@interface, type);
                        break;
                    default:
                        throw new NotSupportedException($"{lifetime} behaviour is not defined");
                }
            }
        }
    }
}