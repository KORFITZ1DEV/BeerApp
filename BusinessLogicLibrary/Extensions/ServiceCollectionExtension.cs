using BusinessLogic.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModelLibrary;

namespace BusinessLogic.Extensions;

public static class ServiceCollectionExtention
{
    public static IServiceCollection AddBusinessLogicLayer(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddTransient<IBeerLogic, BeerLogic>();
        services.AddTransient<IBeerGroupLogic, BeerGroupLogic>();
        services.AddTransient<IBeerLoverLogic, BeerLoverLogic>();
        services.AddTransient<IRatingLogic, RatingLogic>();
        services.AddTransient<IBreweryLogic, BreweryLogic>();

        return services;
    }
}