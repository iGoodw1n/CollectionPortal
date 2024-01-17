using CollectionLogicLayer.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CollectionLogicLayer.Extensions;

public static class WebApplicationExtension
{
    public static IServiceCollection AddLogicServices(this IServiceCollection services)
    {
        services.AddScoped<ICollectionService, CollectionService>();
        services.AddScoped<ICategoryService, CategoryService>();
        return services;
    }
}
