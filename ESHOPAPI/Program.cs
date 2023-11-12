using ESHOPBLL.Repository.Interfaces;
using ESHOPBLL.Repository.Services;
using ESHOPDAL.Repository.Interfaces;
using ESHOPDAL.Repository.Services;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient(sp => new SqlConnection(
    builder.Configuration.GetConnectionString("ConnectionString")
    ));

builder.Services.AddScoped<IUserServiceDAL, UserServiceDAL>();
builder.Services.AddScoped<IUserServiceBLL, UserServiceBLL>();
builder.Services.AddScoped<ICategoryServiceBLL, CategoryServiceBLL>();
builder.Services.AddScoped<ICategoryServiceDAL, CategoryServiceDAL>();
builder.Services.AddScoped<IProductServiceDAL, ProductServiceDAL>();
builder.Services.AddScoped<IProductServiceBLL, ProductServiceBLL>();
builder.Services.AddScoped<IProductReviewServiceDAL, ProductReviewServiceDAL>();
builder.Services.AddScoped<IProductReviewServiceBLL, ProductReviewServiceBLL>();
builder.Services.AddScoped<ICartItemServiceBLL, CartItemServiceBLL>();
builder.Services.AddScoped<ICartItemServiceDAL, CartItemServiceDAL>();

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
