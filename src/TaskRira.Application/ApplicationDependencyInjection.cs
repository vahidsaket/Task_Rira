using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using TaskRira.Application.MappingProfiles;
using TaskRira.Application.Services.Impl;
using TaskRira.Application.Services;

namespace TaskRira.Application
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IWebHostEnvironment env)
        {
            services.AddServices(env);

            services.RegisterAutoMapper();

            return services;
        }

        private static void AddServices(this IServiceCollection services, IWebHostEnvironment env)
        {
            //services.AddScoped<IWeatherForecastService, WeatherForecastService>();
            services.AddScoped<IUserService, UserService>();
        }

        private static void RegisterAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(IMappingProfilesMarker));
        }
    }

}
