using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NetAtlas.Authorisation;
using NetAtlas.Data;
using NetAtlas.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<NetAtlasContext>(options =>
    options.UseSqlServer(connectionString));builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
//, options.SignIn.RequireConfirmedEmail = true

builder.Services.AddDefaultIdentity<NetAtlasUser>(options => { options.SignIn.RequireConfirmedAccount = false;// options.SignIn.RequireConfirmedEmail = true;
})
    .AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<ApplicationDbContext>();
       
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IAuthorizationHandler,
                      AutorisationMembre>();

builder.Services.AddSingleton<IAuthorizationHandler,
                      AuthorisationAdminstrateur>();

builder.Services.AddSingleton<IAuthorizationHandler,
                      AutorisationModerateur>();


var app = builder.Build();

/*using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();
    context.Database.Migrate();
    // requires using Microsoft.Extensions.Configuration;
    // Set password with the Secret Manager tool.
    // dotnet user-secrets set SeedUserPW <pw>

    var testUserPw = builder.Configuration.GetValue<string>("SeedUserPW");

    //await SeedData.Initialize(services, "El21mars#");
}*/

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
