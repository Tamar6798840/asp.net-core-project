using Microsoft.EntityFrameworkCore;
using MySite.Middleware;
using MySite.Midlleware;
using NLog.Web;
using Repositories;
using Services;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IUserRepositories, UserRepositories>();
builder.Services.AddTransient<IUserSevices, UserSevices>();

builder.Services.AddTransient<IProductRepositories, ProductRepositories>();
builder.Services.AddTransient<IProductServices, ProductServices>();

builder.Services.AddTransient<IOrderRepositories, OrderRepositories>();
builder.Services.AddTransient<IOrderServices, OrderServices>();

builder.Services.AddTransient<ICategoryRepositories, CategoryRepositories>();
builder.Services.AddTransient<ICategoryServices, CategoryServices>();

builder.Services.AddTransient<IRatingRepositories, RatingRepositories>();
builder.Services.AddTransient<IRatingServices, RatingServices>();

builder.Services.AddTransient<ICategoryServices, CategoryServices>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<StshopContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStrings:STshop")));

builder.Host.UseNLog();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


    
app.UseHttpsRedirection();
app.UseRatingMiddleware();
app.UseErrorMiddleware();
app.UseAuthorization();

app.MapControllers();
app.UseStaticFiles();
app.Run();
