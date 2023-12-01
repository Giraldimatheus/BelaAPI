
using BelaApi.Interfaces;
using BelaApi.Services;
using Microsoft.Extensions.Options;
using System.Text.Json.Serialization;

namespace BelaApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<Context>(); // libera a injeção de dependencia.
            builder.Services.AddControllers();
            builder.Services.AddTransient<IClienteAppService, ClienteAppService>();
            builder.Services.AddTransient<IContatoAppService, ContatoAppService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}