using DonationApi.Libs.PaymentGateway;
using DonationApi.Libs.PaymentGateway.Midtrans;
using DonationApi.Models;
using DonationApi.Repositories;
using DonationApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database
builder.Services.AddDbContext<DatabaseContext>(option =>
    option.UseNpgsql(builder.Configuration["Database:ConnectionString"]));

// Repositories
builder.Services.AddScoped<IDonationRepository, DonationRepository>();

// Services
builder.Services.AddScoped<IDonationService, DonationService>();

// Libs
builder.Services.AddSingleton<IPaymentGateway, MidtransPaymentGateway>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
