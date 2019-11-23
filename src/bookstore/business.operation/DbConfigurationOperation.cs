using Microsoft.Extensions.Configuration;
using business.infrastructure.Operations;

namespace business.operation
{
    public class DbConfigurationOperation : IDbConfigurationOperation
    {
        #region [ Dependecies ]

        private IConfiguration Configuration { get; set; }

        public DbConfigurationOperation(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        #endregion      

        public string Host => Configuration.GetSection("Host").Value;
        public string ConnectionString => Configuration.GetConnectionString(Host);
        public bool SqlProfileQuery => bool.Parse(Configuration.GetSection("System:Diagnostics:SqlProfileQuery").Value);
    }
}
