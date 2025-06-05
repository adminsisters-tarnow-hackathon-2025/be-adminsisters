namespace be_adminsisters;

public class Program
{
    public static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);

        builder.Services.RegisterDbContext(builder.Configuration);
        builder.Services.AddDependencyInjection();

        builder.Services.AddControllers();

        var app = builder.Build();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();

    }
}