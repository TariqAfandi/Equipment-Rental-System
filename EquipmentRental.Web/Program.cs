//using EquipmentRental.Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using rental_System_db.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add DbContext
builder.Services.AddDbContext<RentalDBContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.")));

// Add session support
// Step 1: Add distributed memory cache
builder.Services.AddDistributedMemoryCache();

// Step 2: Configure session options
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Set session timeout
    options.Cookie.HttpOnly = true; // Helps protect against XSS
    options.Cookie.IsEssential = true; // Make the session cookie essential
    options.Cookie.SameSite = SameSiteMode.Lax; // Controls how cookie is sent in cross-site requests
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // Only send over HTTPS
});

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

app.UseAuthentication();
app.UseAuthorization();

// Step 3: Add session middleware to the HTTP pipeline
// This MUST come after UseRouting() and before MapControllerRoute()
app.UseSession();

// Add custom middleware for session authentication if needed
// app.UseMiddleware<SessionAuthMiddleware>();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Ensure database is created and seeded
//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;
//    try
//    {
//        var context = services.GetRequiredService<rental_System_db>();
//        context.Database.Migrate();
//    }
//    catch (Exception ex)
//    {
//        var logger = services.GetRequiredService<ILogger<Program>>();
//        logger.LogError(ex, "An error occurred while migrating or seeding the database.");
//    }
//}

app.Run();