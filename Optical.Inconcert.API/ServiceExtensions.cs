using Optical.Inconcert.Application;
using Optical.Inconcert.Application.Interfaces;
using Optical.Inconcert.Infrastructure.Repositories;

namespace Optical.Inconcert.API
{
    public static class ServiceExtensions
    {
        public static void AddApplication(this IServiceCollection service)
        {
            service.AddTransient<IUnitOfWork, UnitOfWork>();
            service.AddTransient<IDeudaRepository, DeudaRepository>();
            service.AddTransient<IDeudaApplication, DeudaApplication>();
        }
    }
}
