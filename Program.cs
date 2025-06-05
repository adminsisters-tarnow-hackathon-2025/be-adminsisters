namespace be_adminsisters;

public static class Program
{
    public static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);
        
        builder.Services.RegisterDbContext(builder.Configuration);
        builder.Services.AddDependencyInjection();

        builder.Services.AddControllers();

        var app = builder.Build();

        app.ApplyMigrations();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();

    }
}