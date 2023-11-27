using ESHOPBLL.Repository.Interfaces;
using ESHOPBLL.Repository.Services;
using ESHOPDAL.Repository.Interfaces;
using ESHOPDAL.Repository.Services;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<ICartItemServiceBLL, CartItemServiceBLL>();
builder.Services.AddScoped<ICartItemServiceDAL, CartItemServiceDAL>();
builder.Services.AddScoped<ICategoryServiceBLL, CategoryServiceBLL>();
builder.Services.AddScoped<ICategoryServiceDAL, CategoryServiceDAL>();
builder.Services.AddScoped<IDeliveryServiceDAL , DeliveryServiceDAL>();
builder.Services.AddScoped<IDeliveryServiceBLL , DeliveryServiceBLL>();
builder.Services.AddScoped<IFavoriteItemServiceDAL , FavoriteItemServiceDAL>();
builder.Services.AddScoped<IFavoriteItemServiceBLL , FavoriteItemServiceBLL>();
builder.Services.AddScoped<IOrderItemServiceBLL , OrderItemServiceBLL >();
builder.Services.AddScoped<IOrderItemServiceDAL , OrderItemServiceDAL >();
builder.Services.AddScoped<IOrderServiceDAL , OrderServiceDAL >();
builder.Services.AddScoped<IOrderServiceBLL , OrderServiceBLL >();
builder.Services.AddScoped<IPaymentServiceDAL , PaymentServiceDAL >();
builder.Services.AddScoped<IPaymentServiceBLL , PaymentServiceBLL >();
builder.Services.AddScoped<IProductReviewServiceDAL, ProductReviewServiceDAL>();
builder.Services.AddScoped<IProductReviewServiceBLL, ProductReviewServiceBLL>();
builder.Services.AddScoped<IProductServiceDAL, ProductServiceDAL>();
builder.Services.AddScoped<IProductServiceBLL, ProductServiceBLL>();
builder.Services.AddScoped<IUserServiceDAL, UserServiceDAL>();
builder.Services.AddScoped<IUserServiceBLL, UserServiceBLL>();

builder.Services.AddTransient(sp => new SqlConnection(
    builder.Configuration.GetConnectionString("ConnectionString")
    ));


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app   .UseCors(o => o       
         .AllowAnyOrigin()
         .AllowAnyHeader()
         .AllowAnyMethod()
         );

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
