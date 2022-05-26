using Microsoft.Extensions.Configuration;

namespace Ticaret.Persistence
{
    static class SqlConfiguration
    {
        static public string ConnectionString
        {
            get
            {
                
                ConfigurationManager configuration = new();
                configuration.SetBasePath(Path.Combine(Environment.CurrentDirectory, "../../Presentation/Ticaret.API"));
                configuration.AddJsonFile("appsettings.json");
                return configuration.GetConnectionString("PostgreSql");
            }
        }
    }
}
