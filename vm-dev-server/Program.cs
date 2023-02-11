global using vm_dev_server.Data;
using Microsoft.EntityFrameworkCore;

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
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
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


    }
}