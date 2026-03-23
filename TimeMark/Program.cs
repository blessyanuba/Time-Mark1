using Microsoft.EntityFrameworkCore;
using Time.Application.Interfaces;
using Time.Domain.Interface.IRepository;
using Time.Infrastructure.Repositories;
using TimeMark.Data;
using TimeMark.Filters;
using TimeMark.Interfaces;
using TimeMark.Repositories;
using TimeMark.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
	options.Filters.Add<ApiExceptionFilter>();
});

builder.Services.AddScoped<ApiExceptionFilter>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EasyDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();