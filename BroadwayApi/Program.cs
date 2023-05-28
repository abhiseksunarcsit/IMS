using IMS_Morning.DataAccess.Interfaces;
using IMS_Morning.DataAccess.Repositories;
using IMS_Morning.Services.Interfaces;
using IMS_Morning.Services.Service;
using IMS_Morning.Services.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddTransient<ICustomerRepositories,CustomerRepositories>();
        builder.Services.AddTransient<ICustomerServices, CustomerServices>();
        builder.Services.AddTransient<IProductRepositories,ProductRepositories>();
        builder.Services.AddTransient<IProductServices,ProductServices>();
        builder.Services.AddTransient<ICategoriesRepositories,CategoriesRepositories>();
        builder.Services.AddTransient<ICategoriesServices,CategoriesServices>();
        builder.Services.AddTransient<IOrdersRepositories, OrdersRepositories>();
        builder.Services.AddTransient<IOrdersServices,OrdersServices>();



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