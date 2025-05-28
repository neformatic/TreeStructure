using FluentValidation;
using FluentValidation.AspNetCore;

namespace TreeStructure.API.Infrastructure;

public static class FluentValidationExtension
{
    public static void AddFluentValidationConfiguration(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();
        services.AddFluentValidationClientsideAdapters();
        services.AddValidatorsFromAssemblyContaining<Program>();
    }
}