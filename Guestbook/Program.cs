using Guestbook.Context;
using Guestbook.Contracts;
using Guestbook.Repository;

var builder = WebApplication.CreateBuilder(args);

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
