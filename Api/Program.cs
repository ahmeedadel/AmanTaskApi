using Api.Models;
using Api.Repository;
using Api.Services;
using Api.Models;
using Api.Repository;
using Api.Services;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// binding the configuration to a the email model
builder.Services.Configure<Email>(builder.Configuration.GetSection("EmailSettings"));

//configuring Swagger documentation

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Add db Context & connection string
builder.Services.AddDbContext<EmailSenderDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EmailSenderConnectionString")));


// Registering services
builder.Services.AddScoped<IMessageRepository, MessageRepository>();
builder.Services.AddScoped<IMessageService, MessageService>();
builder.Services.AddTransient<IEmailService, EmailService>();


// Enabling cross-origin resource sharing
string corsText = "EnableCors";
builder.Services.AddCors(options =>
{
    options.AddPolicy(corsText,
    builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
});
var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(corsText);

app.MapControllers();

app.Run();
