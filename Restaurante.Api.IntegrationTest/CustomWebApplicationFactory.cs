using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Restaurante.Infra.Writting.Data;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using Microsoft.Extensions.Logging;

namespace Restaurante.Api.IntegrationTest
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Remove the app's ApplicationDbContext registration.
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                        typeof(DbContextOptions<WritingContext>));


                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                // Add a database context using an in-memory 
                // database for testing.
                services.AddDbContext<WritingContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryDbForTesting");
                });


                // Build the service provider
                var sp = services.BuildServiceProvider();

                // Create a scope to obtain a reference to the database
                // context (ApplicationDbContext).
                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var context = scopedServices.GetRequiredService<WritingContext>();
                    var logger = scopedServices.GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();

                    // Ensure the database is created.
                    context.Database.EnsureCreated();

                    try
                    {
                        // Seed the database with test data.
                        SeedSampleData(context);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, "An error occurred seeding the database with test messages. Error: {Message}", ex.Message);
                    }
                }
            })
                .UseEnvironment("Test");
        }
        
        public HttpClient GetAnonymousClient()
        {
            return CreateClient();
        }

        public static void SeedSampleData(WritingContext context)
        {
            context.IngredienteCategorias.AddRange(
                new Domain.Entities.IngredienteCategoria { Descricao = "Carne" },
                new Domain.Entities.IngredienteCategoria { Descricao = "Peixe" },
                new Domain.Entities.IngredienteCategoria { Descricao = "Tempero" }
            );

            context.SaveChanges();
        }
    }
}
