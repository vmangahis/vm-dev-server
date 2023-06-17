global using vm_dev_server.Data;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;

namespace vm_dev_server
{
    public class Program
    {
        public static void Main(string[] args)
        {

            

            var builder = WebApplication.CreateBuilder(args);


           
            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddCors();
            builder.Services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(GetConnectionString(builder));//builder.Configuration.GetConnectionString("DefaultConnection"));
                Environment.GetEnvironmentVariable("DATABASE_URL");
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(
                p => p.AddPolicy("cors", build =>
                {
                    build.WithOrigins("github.io").AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed((host) => true);
                }));


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors("cors");

            app.UseAuthorization();

        

            app.MapControllers();


            app.UseDeveloperExceptionPage();


            app.Run();
        }

        public static string GetConnectionString(WebApplicationBuilder wb)
        {
            var dbURL = Environment.GetEnvironmentVariable("DATABASE_URL");
            var conString = wb.Configuration.GetConnectionString("DefaultConnection");
            return string.IsNullOrEmpty(dbURL) ? conString : BuildCS(dbURL);
        }

        private static string BuildCS(string dbURL) {
            var dburl = new Uri(dbURL);
            var userin = dburl.UserInfo.Split(':');
            var builder = new NpgsqlConnectionStringBuilder
            {
                Host = dburl.Host,
                Port = dburl.Port,
                Username = userin[0],
                Password = userin[1],
                Database = dburl.LocalPath.TrimStart('/'),
                SslMode = SslMode.Require,
                TrustServerCertificate = true


            };

            return builder.ToString();
        
        }


    }
}