using Catalog.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Npgsql;
using Polly;
using System;

namespace Catalog.Api.Entensions
{
    public static class HostExtensions
    {
        public static IHost MigrateDatabase<TContext>(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var configuration = services.GetRequiredService<IConfiguration>();
                var logger = services.GetRequiredService<ILogger<TContext>>();
                

                try
                {
                    logger.LogInformation("Migrating postresql database.");

                    var retry = Policy.Handle<NpgsqlException>()
                            .WaitAndRetry(
                                retryCount: 5,
                                sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)), // 2,4,8,16,32 sc
                                onRetry: (exception, retryCount, context) =>
                                {
                                    logger.LogError($"Retry {retryCount} of {context.PolicyKey} at {context.OperationKey}, due to: {exception}.");
                                });

                    //if the postgresql server container is not created on run docker compose this
                    //migration can't fail for network related exception. The retry options for database operations
                    //apply to transient exceptions                    
                    retry.Execute(() => ExecuteMigrations(configuration));

                    logger.LogInformation("Migrated postresql database.");
                }
                catch (NpgsqlException ex)
                {
                    logger.LogError(ex, "An error occurred while migrating the postresql database");
                }
            }

            return host;
        }

        private static void ExecuteMigrations(IConfiguration configuration)
        {

                using NpgsqlConnection connection = new NpgsqlConnection(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
                connection.Open();

                using var command = new NpgsqlCommand
                {
                    Connection = connection
                };
                command.CommandText = "DROP TABLE IF EXISTS Brands";
                command.ExecuteNonQuery();

                command.CommandText = "DROP TABLE IF EXISTS Categories";
                command.ExecuteNonQuery();

                command.CommandText = "DROP TABLE IF EXISTS Departments";
                command.ExecuteNonQuery();

                command.CommandText = "DROP TABLE IF EXISTS Products";
                command.ExecuteNonQuery();
                //context.Database.Migrate();
                //Brand
                //command.CommandText = @"CREATE TABLE Brands(Id SERIAL PRIMARY KEY, 
                //                                                Name VARCHAR(24) NOT NULL,
                //                                                DateCreated timestamp without time zone NOT NULL,
                //                                                CreatedBy VARCHAR(24) NOT NULL,
                //                                                DateModified timestamp without time zone,
                //                                                ModifiedBy VARCHAR(24),
                //                                                MainImageUrl VARCHAR(50),
                //                                                Image2Url VARCHAR(50),
                //                                                Image3Url VARCHAR(50)
                //                                                )";
                //command.ExecuteNonQuery();

                //command.CommandText = "INSERT INTO Brands(Name) VALUES('Nike')";
                //command.ExecuteNonQuery();

                //command.CommandText = "INSERT INTO Brands(Name) VALUES('Adidas')";
                //command.ExecuteNonQuery();

                //Category
                //command.CommandText = @"CREATE TABLE Categories(Id SERIAL PRIMARY KEY, 
                //                                                Name VARCHAR(24) NOT NULL
                //                                                DateCreated timestamp without time zone NOT NULL,
                //                                                CreatedBy VARCHAR(24) NOT NULL,
                //                                                DateModified timestamp without time zone,
                //                                                ModifiedBy VARCHAR(24),
                //                                                MainImageUrl VARCHAR(50),
                //                                                Image2Url VARCHAR(50),
                //                                                Image3Url VARCHAR(50)";
                //command.ExecuteNonQuery();

                //command.CommandText = "INSERT INTO Categories(Name) VALUES('Sneaker')";
                //command.ExecuteNonQuery();

                //command.CommandText = "INSERT INTO Categories(Name) VALUES('Jacket')";
                //command.ExecuteNonQuery();

                //command.CommandText = "INSERT INTO Categories(Name) VALUES('Jean')";
                //command.ExecuteNonQuery();

                //command.CommandText = "INSERT INTO Categories(Name) VALUES('T-shirt')";
                //command.ExecuteNonQuery();

                ////Department
                //command.CommandText = @"CREATE TABLE Departments(Id SERIAL PRIMARY KEY, 
                //                                                Name VARCHAR(24) NOT NULL
                //                                                DateCreated timestamp without time zone NOT NULL,
                //                                                CreatedBy VARCHAR(24) NOT NULL,
                //                                                DateModified timestamp without time zone,
                //                                                ModifiedBy VARCHAR(24),
                //                                                MainImageUrl VARCHAR(50),
                //                                                Image2Url VARCHAR(50),
                //                                                Image3Url VARCHAR(50))";
                //command.ExecuteNonQuery();

                //command.CommandText = "INSERT INTO Departments(Name) VALUES('Men')";
                //command.ExecuteNonQuery();

                //command.CommandText = "INSERT INTO Departments(Name) VALUES('Women')";
                //command.ExecuteNonQuery();

                //command.CommandText = "INSERT INTO Departments(Name) VALUES('Toddlers')";
                //command.ExecuteNonQuery();

                //command.CommandText = "INSERT INTO Departments(Name) VALUES('Kids')";
                //command.ExecuteNonQuery();

                ////Product
                //command.CommandText = @"CREATE TABLE Products(Id SERIAL PRIMARY KEY, 
                //                                                Name VARCHAR(24) NOT NULL,
                //                                                Image VARCHAR(24) NOT NULL,
                //                                                BrandId INT NOT NULL,
                //                                                CategoryId INT NOT NULL,
                //                                                DepartmentId INT NOT NULL,
                //                                                DateCreated timestamp without time zone NOT NULL,
                //                                                CreatedBy VARCHAR(24) NOT NULL,
                //                                                DateModified timestamp without time zone,
                //                                                ModifiedBy VARCHAR(24),
                //                                                MainImageUrl VARCHAR(50),
                //                                                Image2Url VARCHAR(50),
                //                                                Image3Url VARCHAR(50)
                //                                                )";
                command.ExecuteNonQuery();
        }
    }
}
