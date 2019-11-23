using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using business.entity.Entities;
using business.infrastructure.Operations;

namespace business.entity
{
    public class EntityContext: CustomDbContext
    {
        #region [ Dependencies ]

        private IDbConfigurationOperation DbConfigurationOperation { get; set; }
        private ILoggerFactory LoggerFactory { get; set; }

        public EntityContext(IDbConfigurationOperation dbConfigurationOperation, ILoggerFactory loggerFactory)
        {
            DbConfigurationOperation = dbConfigurationOperation;
            LoggerFactory = loggerFactory;
        }

        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;

            if (DbConfigurationOperation.SqlProfileQuery)
                optionsBuilder.UseLoggerFactory(LoggerFactory);

            optionsBuilder.UseSqlServer(DbConfigurationOperation.ConnectionString);         
        }
    }
}
