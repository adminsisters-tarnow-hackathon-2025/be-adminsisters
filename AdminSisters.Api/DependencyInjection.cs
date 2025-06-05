using System.Reflection;
using AdminSisters.Api.Common.Extensions;
using AdminSisters.Api.Common.Interfaces;
using AdminSisters.Api.Persistence;
using AdminSisters.Api.Services;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Text.Json;


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
        var portalConnectionString = configuration.GetConnectionString("Portal");

        var dataSourceBuilder = new NpgsqlDataSourceBuilder(portalConnectionString);
        dataSourceBuilder.EnableDynamicJson();
        var dataSource = dataSourceBuilder.Build();

        services.AddDbContext<MainDbContext>(options =>
        {
            options.UseNpgsql(dataSource, npgsqlOptions =>
            {
                npgsqlOptions.MigrationsHistoryTable("ab_history_migrations");
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