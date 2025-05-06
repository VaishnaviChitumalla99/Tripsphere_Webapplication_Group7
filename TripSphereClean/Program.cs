using Microsoft.EntityFrameworkCore;
using TripSphere.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// ✅ Add session services
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();

// Add EF Core with SQL Server
builder.Services.AddDbContext<TripsphereDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// ✅ Enable session middleware before authorization
app.UseSession();
app.UseAuthorization();

// ✅ Allow API routing
app.MapControllers();

// MVC fallback route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
