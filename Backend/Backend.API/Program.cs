using Backend.Application.Operations;
using Backend.Application.Repository;
using Backend.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;

namespace Backend.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            AddInimco(builder.Services); //more beautiful would be an extension method

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();

            var summaries = new[]
            {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

            app.MapGet("/getperson/{personId}", (string personIdString, [FromServices] int myOperationInjector , HttpContext httpContext) =>
            {
                var personId = Guid.Parse(personIdString);
                var operationParameters = new RetrievePersonParams
                {
                    Id = personId
                };
                
                //use injected service to grab operation object
                //var result = operation.execute(params)

                //return result. possibly in wrapper object.

                var forecast = Enumerable.Range(1, 5).Select(index =>
                    new WeatherForecast
                    {
                        Date = DateTime.Now.AddDays(index),
                        TemperatureC = Random.Shared.Next(-20, 55),
                        Summary = summaries[Random.Shared.Next(summaries.Length)]
                    })
                    .ToArray();
                return forecast;
            })
            .WithName("GetWeatherForecast");

            app.Run();
        }

        public static void AddInimco(IServiceCollection services)
        {
            services.AddSingleton<IPersonRepositoryFactory, InimcoDbContextFactory>();

            //var iAsyncOperationType = typeof(IAsyncOperation);
            //var allFoundOperations = AppDomain.CurrentDomain.GetAssemblies()
            //    .SelectMany(x => x.GetTypes())
            //    .Where(x => iAsyncOperationType.IsAssignableFrom(x) && x.IsClass);

            //foreach (var operation in allFoundOperations)
            //{
            //    builder.Services.AddTransient<IAsyncOperation, AddSkillToPerson>();
            //    builder.Services.AddTransient<IAsyncOperation, AddSkillToPerson>();
            //    builder.Services.AddTransient<IAsyncOperation, AddSkillToPerson>();
            //    builder.Services.AddTransient<IAsyncOperation, AddSkillToPerson>();
            //}
        }
    }
}