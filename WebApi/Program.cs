using Microsoft.EntityFrameworkCore;
using Repository;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<IUsersRepository, UsersRepository>();
builder.Services.AddTransient<IUsersServices, UsersServices>();
builder.Services.AddTransient<IPasswordValidity, PasswordStrength>();

builder.Services.AddDbContext<MyShopContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString
        ("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MyShop;Integrated Security=True;Trust Server Certificate=TrueData Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MyShop;Integrated Security=True;Trust Server Certificate=True")),ServiceLifetime.Transient);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
