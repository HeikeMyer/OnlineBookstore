using Microsoft.Extensions.DependencyInjection;
using business.entity;
using business.infrastructure.Operations;
using business.infrastructure.Repositories;
using business.operation;
using business.repository;

namespace bookstore.site.Extensions
{
    public static class ServiceProviderExtensions
    {
        public static void AddEntityContext(this IServiceCollection services)
        {
            services.AddSingleton<IDbConfigurationOperation, DbConfigurationOperation>();
            services.AddSingleton<EntityContext>();
        }
        public static void AddRepositoryService(this IServiceCollection services)
        {
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IRoleRepository, RoleRepository>();
        }

        public static void AddOperationService(this IServiceCollection services)
        {          
            services.AddSingleton<IUserOperation, UserOperation>();
        }
    }
}
