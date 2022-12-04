using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;

namespace Persistence;

public static class DependencyInjection
{
    public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DataBaseContext>(options =>
            options.UseNpgsql(
                configuration.GetConnectionString("DefaultConnection"),
                builder => builder.MigrationsAssembly(typeof(DataBaseContext).Assembly.FullName)
                    .UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)
            )
        );

        #region Repositories

        services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddTransient<ICustomerRepository, CustomerRepository>();

        #endregion

        services.AddTransient<IUnitOfWork, UnitOfWork>();
    }
}