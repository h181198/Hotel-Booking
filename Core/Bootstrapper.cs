using Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Core
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddSingleton<IReservationService, ReservationService>();

            return services;
        }
    }
}
