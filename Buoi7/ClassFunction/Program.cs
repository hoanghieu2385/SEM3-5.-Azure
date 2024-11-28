using ClassFunction.Presentations;
using ClassFunction.Respositories;
using ClassFunction.Services;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = FunctionsApplication.CreateBuilder(args);
        IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        string connectionString = configuration.GetConnectionString("EduConnect");
        builder.Services.AddDbContext<EduDbContext>(options => options.UseSqlServer(connectionString));
        builder.Services.AddScoped<IClassRepository, ClassRepository>();
        builder.Services.AddScoped<IClassService,ClassService>();
        builder.Services.AddAutoMapper(typeof(MappingProfile));
        builder.ConfigureFunctionsWebApplication();

        // Application Insights isn't enabled by default. See https://aka.ms/AAt8mw4.
        // builder.Services
        //     .AddApplicationInsightsTelemetryWorkerService()
        //     .ConfigureFunctionsApplicationInsights();

        builder.Build().Run();
    }
}