using Microsoft.EntityFrameworkCore;
using ChallengeIntuit.DAL;
using ChallengeIntuit.Domain.Abstractions.Service;
using ChallengeIntuit.Service.Services;
using ChallengeIntuit.DAL.Repository;
using ChallengeIntuit.Service.AutoMapper;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ChallengeIntuitContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"),
        b => b.MigrationsAssembly("ChallengeIntuit.DAL"))); 

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

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
