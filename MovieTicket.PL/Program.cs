using MovieTicket.BLL.Infrastructure;
using MovieTicket.BLL.Interfaces;
using MovieTicket.BLL.Services;

namespace MovieTicket.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<ITicketService, TicketService>();
            builder.Services.AddScoped<IMovieService, MovieService>();
            //IServiceCollection services = builder.Services;
            //services.SetBllDependencies();


            string connectionString = builder.Configuration.GetConnectionString("connectionString");
            builder.Services.SetBllDependencies(connectionString);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Movies}/{action=Index}/{id?}");

            app.Run();
        }
    }
}