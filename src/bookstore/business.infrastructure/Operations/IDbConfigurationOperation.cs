namespace business.infrastructure.Operations
{
    public interface IDbConfigurationOperation
    {     
        public string Host { get; }
        public string ConnectionString { get; }
        public bool SqlProfileQuery { get; }
    }
}
