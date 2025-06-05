using System.Reflection;
using be_adminsisters.Common.Extensions;
using be_adminsisters.Common.Interfaces;
using be_adminsisters.Persistence;
using be_adminsisters.Services;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace be_adminsisters;

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
        var portalConnectionString = configuration.GetConnectionString("Main");

        var dataSourceBuilder = new NpgsqlDataSourceBuilder(portalConnectionString);
        dataSourceBuilder.EnableDynamicJson();
        var dataSource = dataSourceBuilder.Build();

        services.AddDbContext<MainDbContext>(options =>
        {
            options.UseNpgsql(dataSource, npgsqlOptions =>
            {
                npgsqlOptions.MigrationsHistoryTable("as_history_migrations");
                npgsqlOptions.UseJsonDocumentDbApi();
            });
            options.UseSnakeCaseNamingConvention();

            options.ReplaceService<IJsonValueReaderWriterSource, CustomJsonValueReaderWriterSource>();
            var environment = configuration.GetValue<string>("Environment") ??
                              Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            if (environment?.Equals("Development", StringComparison.OrdinalIgnoreCase) == true)
            {
                options.EnableSensitiveDataLogging();
            }
        });

        services.AddScoped<IRepository>(provider => provider.GetRequiredService<MainDbContext>());
        return services;
    }
}