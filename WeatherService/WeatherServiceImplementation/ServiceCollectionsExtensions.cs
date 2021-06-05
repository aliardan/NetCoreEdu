using Microsoft.Extensions.DependencyInjection;

namespace WeatherServiceImplementation
{
    public static class ServiceCollectionsExtensions
    {
        public static void AddServiceMethodImplementation(this IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddTransient<IWeatherService, WeatherService>();
        }
    }
}
