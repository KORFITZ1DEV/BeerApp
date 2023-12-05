using DataAccessLibrary.DataAccess;
using DataAccessLibrary.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using ModelLibrary;

namespace DataAccessLibrary.Extensions;

public static class ServiceCollectionExtention
{
    public static IServiceCollection AddDataAccessLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DataContext>(options =>
        {
            options.UseNpgsql("host = localhost; port = 5432; Database = beerdata; Username = caspermortensen; password = beer;");
        });

        services.AddTransient<IModelContext<BeerModel>, BeerContext>();
        services.AddTransient<IModelContext<BeerLoverModel>, BeerLoverContext>();
        services.AddTransient<IModelContext<BeerGroupModel>, BeerGroupContext>();
        services.AddTransient<IModelContext<RatingModel>, RatingContext>();

        return services;
    }
}