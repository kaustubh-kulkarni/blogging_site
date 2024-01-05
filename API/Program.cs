using Microsoft.EntityFrameworkCore;
using Persistence;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        //Add cors service
        builder.Services.AddCors();

        builder.Services.AddDbContextPool<DatabaseContext>(opt => {
            opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        

        app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200"));

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();


        //Use a single scope to add the migrations
        using var scope = app.Services.CreateScope();
        //Get the service for scope
        var services = scope.ServiceProvider;

        try
        {
            //Get data context
            var context = services.GetRequiredService<DatabaseContext>();
            await context.Database.MigrateAsync();
            await Seed.SeedData(context);
            
        }
        catch (Exception ex)
        {
            //Creating a logger instance within the scope of program.cs to report logs
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "An error occured during migration!");
        }

        app.Run();
    }
}