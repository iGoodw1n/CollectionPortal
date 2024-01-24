using API.Services;
using CollectionLogicLayer.Helpers;
using CollectionLogicLayer.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CollectionLogicLayer.Extensions;

public static class WebApplicationExtension
{
    public static IServiceCollection AddLogicServices(this IServiceCollection services, IConfiguration config)
    {
        services.Configure<CloudinarySettings>(config.GetSection("CloudinarySettings"));
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddScoped<ICollectionService, CollectionService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IPhotoService, PhotoService>();
        services.AddScoped<IItemService, ItemService>();
        services.AddScoped<ITagService, TagService>();
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<ICommentService, CommentService>();
        return services;
    }
}
