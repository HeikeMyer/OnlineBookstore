using business.infrastructure.Operations;
using business.infrastructure.Repositories;
using business.operation;
using business.repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookstore.site.Extensions
{
    public static class ServiceProviderExtensions
    {
        public static void AddRepositoryService(this IServiceCollection services)
        {
            services.AddSingleton<IUserRepository, UserRepository>();
        }

        public static void AddOperationService(this IServiceCollection services)
        {
            services.AddSingleton<IUserOperation, UserOperation>();
        }
    }
}
