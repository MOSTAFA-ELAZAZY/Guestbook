using FluentValidation;
using FluentValidation.AspNetCore;
using Guestbook.Context;
using Guestbook.Contracts;
using Guestbook.Dto.user;
using Guestbook.Repository;
using Guestbook.Validation.User;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddFluentValidation(x =>
{
    x.ImplicitlyValidateChildProperties = true;
});
builder.Services.AddTransient<IValidator<UserForCreationDto>, UserValidator>();
builder.Services.AddTransient<IValidator<UserForLoginDto>, LoginValidator>();

// Add services to the container.

builder.Services.AddControllers();

// Add Our DbContext as Service 
builder.Services.AddSingleton<DbContext>();
// Add Scop For Our Classes
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
