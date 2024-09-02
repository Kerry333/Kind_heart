using Kind_heart.API;
using Kind_heart.Application.Volunteers;
using Kind_heart.Application.Volunteers.CreateVolunteer;
using Kind_heart.Infrastructure;
using Kind_heart.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ApplicationDbContext>();

builder.Services.AddScoped<CreateVolunteerHandler>();
builder.Services.AddScoped<IVolunteersRepository, VolunteersRepository>();

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
