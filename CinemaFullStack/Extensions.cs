using CinemaFullStack.Services;
using CinemaFullStack.Services.Interface;
using CinemaFullStackLibrary.Repositories;
using CinemaFullStackLibrary.Repositories.Interface;
using System.Reflection;

namespace CinemaFullStack
{
    public static class Extensions
    {
        public static void AddServices(this IServiceCollection Services)
        {
            Services.AddScoped<ICinemaRepository,CinemaRepository>();
            Services.AddScoped<ICinemaHallRepository, CinemaHallRepository>();
            Services.AddScoped<IMovieRepository, MovieRepository>();
            Services.AddScoped<ICustomerRepository, CustomerRepository>();
            Services.AddScoped<ITicketSalesRepository, TicketSalesRepository>();
            Services.AddScoped<ISessionRepository, SessionRepository>();
            Services.AddAutoMapper(Assembly.GetExecutingAssembly());

            Services.AddScoped<ICinemaService,CinemaService>();
            Services.AddScoped<IMovieService,MovieService>();
            Services.AddScoped<ICinemaHallService,CinemaHallService>();
            Services.AddScoped<ICustomerService,CustomerService>();
            Services.AddScoped<ITicketProcessService,TicketProcessService>();
            Services.AddScoped<ISessionService,SessionService>();
        }
    }
}
