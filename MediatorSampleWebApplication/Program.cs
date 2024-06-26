using MediatorSample.Infrastructure.Interfaces;
using MediatorSample.Infrastructure.Repositories;
using MediatR;

namespace MediatorSample.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddMediatR(typeof(Program));
            builder.Services.AddSingleton<IStudentRepository, StudentRepository>();
            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
