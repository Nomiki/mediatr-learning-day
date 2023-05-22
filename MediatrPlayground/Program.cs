using FluentValidation;
using MediatR;
using MediatrPlayground.Behaviors;
using MediatrPlayground.Dal;
using MediatrPlayground.Models.Base;
using MediatrPlayground.Models.Requests;
using MediatrPlayground.Models.Responses;
using MediatrPlayground.Utils;
using MediatrPlayground.Validators;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(c =>
{
    c.Lifetime = ServiceLifetime.Scoped;
    c.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

// Registering mongodb on localhost
var mongoClient = new MongoClient();
builder.Services.AddSingleton<IMongoClient>(mongoClient);
builder.Services.AddSingleton(sp =>
{
    IMongoClient client = sp.GetRequiredService<IMongoClient>();

    return client.GetDatabase("mediatr-playground");
});

// Password Hasher
builder.Services.AddSingleton<IPasswordHasher, PasswordHasher>();

// Registering mongo repositories
builder.Services.AddTransient<IUserRepository, UserRepository>();

// Validators
builder.Services.AddTransient<IValidator<PostUserRequest>, PostUserValidator>();
// builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

// Pipeline Behaviors
builder.Services.AddScoped<IPipelineBehavior<PostUserRequest, Response<PostUserResponse>>, PostUserValidationBehavior>();

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