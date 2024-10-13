using Domain.Repositories;
using Domain.UnitOfWork;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Service.Repositories;
using Service.UnitOfWork.Generic;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.


        builder.Services.AddControllers(options =>
        {
            options.ReturnHttpNotAcceptable = true;
        })
             .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling =
                        Newtonsoft.Json.ReferenceLoopHandling.Ignore )
            .AddXmlDataContractSerializerFormatters();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.AddRepository2();

        builder.Services.AddSingleton<FileExtensionContentTypeProvider>();


        //builder.Services.AddDbContext<MyContext>(option => {

        //    option.UseSqlServer(builder.Configuration["ConnectionStrings:SqlCon"]);

        //});

        //builder.Services.AddSingleton<IUnitOfWork,UnitOfWork>();


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

        app.UseStaticFiles();

        app.Run();
    }
}

public static class DependencyInjection
{
    public static IServiceCollection AddRepository(this IServiceCollection services)
    {
        services.AddTransient<IHumanRepository, HumanRrepository>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();

        services.AddDbContext<MyContext>(option =>
        {

            // option.UseSqlServer(builder.Configuration["ConnectionStrings:SqlCon"]);

        });
        return services;
    }
    public static WebApplicationBuilder AddRepository2(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IHumanRepository, HumanRrepository>();
        builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

        builder.Services.AddDbContext<MyContext>(option =>
        {

            option.UseSqlServer(builder.Configuration["ConnectionStrings:SqlCon"]);

        });
        return builder;
    }
}
