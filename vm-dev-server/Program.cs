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
                
              //  options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version()));//builder.Configuration.GetConnectionString("DefaultConnection"));
                options.UseMySql(BuildCS(), new MySqlServerVersion(new Version()));
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

        

        private static string BuildCS() {
            var dbUrl = Environment.GetEnvironmentVariable("DBHOST");
            var pas = Environment.GetEnvironmentVariable("DBPASS");
            var uname = Environment.GetEnvironmentVariable("DBUSERNAME");
            var db = Environment.GetEnvironmentVariable("DBNAME");
           

            string conString = $"Server={dbUrl};Database={db};Uid={uname};Pwd={pas}";

            return conString;
        
        }


    }
}