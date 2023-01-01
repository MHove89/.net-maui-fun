using Blog.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Core
{
    public static class IOC
    {
        public static IServiceCollection RegisterCoreServices(this IServiceCollection services)
        {
            services.AddHttpClient<IBlogService, BlogService>(client =>
            {
            });

            return services;
        }
    }
}
