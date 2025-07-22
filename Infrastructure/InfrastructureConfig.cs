using Core.Domain.Aggregates.Books.Repository;
using Core.Domain.Aggregates.Copies.Repository;
using Core.Domain.Aggregates.Loans.Repository;
using Core.Domain.Aggregates.Reservations.Repository;
using Core.Domain.Aggregates.Users.Repository;
using Core.Domain.UnitOfWork;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Persistence.Repositories;
using Infrastructure.Persistence.UnitOfWork;

namespace Infrastructure;

public static class InfrastructureConfig
{
	public static IServiceCollection AddInfrastructureConfig(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddDbContext<ApplicationContext>(option =>
		{
			option.UseSqlServer(configuration.GetConnectionString("SvcDbContext"));
		});

		services.AddScoped<IUnitOfWork, UnitOfWork>();
		services.AddScoped<IBooksRepository, BooksRepository>();
		services.AddScoped<ICopiesRepository, CopiesRepository>();
		services.AddScoped<IUsersRepository, UsersRepository>();
		services.AddScoped<IReservationRepository, ReservationRepository>();
		services.AddScoped<ILoansRepository, LoansRepository>();

		return services;
	}
}
