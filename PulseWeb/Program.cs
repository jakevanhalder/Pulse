using Microsoft.EntityFrameworkCore;
using PulseWeb.Data;
using Microsoft.Extensions.DependencyInjection;
using PulseWeb.Repository.IRepository;
using PulseWeb.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PulseWebContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PulseWebContext") ?? throw new InvalidOperationException("Connection string 'PulseWebContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));

builder.Services.AddScoped<IGoalRepository, GoalRepository>();
builder.Services.AddScoped<IToDoRepository, ToDoRepository>();
builder.Services.AddScoped<IBudgetRepository, BudgetRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
