using GAC.Services;
using GAC.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GAC.DI;

public static class RegistrationDependencyInjectionExtensions
{
    public static void AddDependencyInjectedServices(this IServiceCollection services)
    {
        RegisterRepositories(services);
        RegisterServices(services);
    }

    private static void RegisterRepositories(IServiceCollection services)
    {
        // services.AddScoped<IStudentRepository, StudentRepository>();
    }

    private static void RegisterServices(IServiceCollection services)
    {
        services.AddScoped<IStudentService, StudentService>();
        services.AddScoped<IActivityService, ActivityService>();
        services.AddScoped<IActivityTypeService, ActivityTypeService>();
    }
}
