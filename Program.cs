using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OMovies.Data;
using OMovies.SeedData;
using OMovies.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<OMoviesContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("OMoviesContext") ?? throw new InvalidOperationException("Connection string 'OMoviesContext' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<OMoviesContext>();

var connectionString = builder.Environment.IsDevelopment() 
    ? builder.Configuration.GetConnectionString("OMoviesContext") 
    : builder.Configuration.GetConnectionString("ProductionMovieContext");

builder.Services.AddDbContext<OMoviesContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddSingleton<AzureBlobService>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.InitializeAsync(services);
    await RoleInitializer.InitializeAsync(services);
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
