using Microsoft.EntityFrameworkCore;
using TreeStructure.BLL.Services;
using TreeStructure.BLL.Services.Interfaces;
using TreeStructure.Common.Constants;
using TreeStructure.Common.Helpers;
using TreeStructure.Common.Helpers.Interfaces;
using TreeStructure.DAL;
using TreeStructure.DAL.Repositories;
using TreeStructure.DAL.Repositories.Interfaces;

namespace TreeStructure.API.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddDependencyInjection(this IServiceCollection services,
        IConfiguration configuration)
    {
        InitDatabaseContexts(services, configuration);
        InitApiServices(services);
        InitBllServices(services);
        InitDalServices(services);
    }

    private static void InitDatabaseContexts(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(AppSettingsNameConstants.TreeSctructureConnectionStringName);

        services.AddDbContext<TreeStructureDbContext>(config =>
        {
            config.UseNpgsql(connectionString);
        });
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    private static void InitApiServices(IServiceCollection services)
    {
    }

    private static void InitBllServices(IServiceCollection services)
    {
        services.AddScoped<ITreeService, TreeService>();
        services.AddScoped<INodeService, NodeService>();
        services.AddScoped<IJournalService, JournalService>();
        services.AddScoped<IPaginationHelper, PaginationHelper>();
    }

    private static void InitDalServices(IServiceCollection services)
    {
        services.AddScoped<ITreeRepository, TreeRepository>();
        services.AddScoped<INodeRepository, NodeRepository>();
        services.AddScoped<IJournalRepository, JournalRepository>();
    }
}