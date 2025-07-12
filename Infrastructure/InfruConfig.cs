using Core.Domain.Aggregates.Books.Repository;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;
using Infrastructure.Persistence.Repositories;

namespace Infrastructure;

public static class InfruConfig
{
	public static IServiceCollection AddInfruConfig(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddDbContext<ApplicationContext>(option =>
		{
			option.UseSqlServer(configuration.GetConnectionString("SvcDbContext"));
		});


		services.AddScoped<IBooksRepository, BooksRepository>();

		return services;
	}
}
