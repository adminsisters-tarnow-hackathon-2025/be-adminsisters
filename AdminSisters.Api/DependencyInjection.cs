using AdminSisters.Api.Common.Interfaces;
using AdminSisters.Api.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AdminSisters.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddCors(options =>
        {
            options.AddPolicy(name: "AllowAllOrigins",
                configurePolicy: policy =>
                {
                    policy.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
        });

        return services;
    }
    public static IServiceCollection RegisterDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Main");
        services.AddDbContext<IRepository, MainDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });
        return services;
    }
}
