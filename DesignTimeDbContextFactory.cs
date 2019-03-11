    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<TContext>
    {
        public TContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<TContext>();

            var connectionString = configuration.GetConnectionString("ConnectionStringName");

            builder.UseSqlServer(connectionString);

            return new TContext(builder.Options);
        }
    }
    
    //Required dependencies
    // dotnet add package Microsoft.EntityFrameworkCore.Design
    // dotnet add package Microsoft.EntityFrameworkCore.InMemory
    // dotnet add package Microsoft.EntityFrameworkCore.SqlServer 
    // dotnet add package Microsoft.EntityFrameworkCore.Tools 
    // dotnet add package Microsoft.Extensions.Configuration 
    // dotnet add package Microsoft.Extensions.Configuration.Json
