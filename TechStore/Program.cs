using Microsoft.EntityFrameworkCore;
using TechStore.Models.Data;
using TechStoreLibrary.Models.Data;
using TechStoreLibrary.Models.Repo;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TechStoreWebsite")
    ?? throw new InvalidOperationException("Connection string \"TechStoreWebsite\" not found."),
    optionsBuilder => optionsBuilder.MigrationsAssembly("TechStore")));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IRepository, EFRepository>();

var app = builder.Build();

SeedData.EnsurePopulated(app);

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

app.MapGet("/", (HttpContext context) =>
{
    context.Response.Redirect("/Home");
    return Task.CompletedTask;
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

