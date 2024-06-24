///Service Lifetimes
///Singleton - One instance of a resource, reused anytime it's requested.
///single instance will serve all the incoming requests. It will not be disposed untill project is running.
///
///Scoped - Single instance will serve all the requests from a scope,
///For another scope a new instance will be created. Beyond scope it will be disposed.
///
///Transient - A new instance is created for every request. After completing the request it is disposed.
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StudentApplication.Data;
using StudentApplication.Models;
using StudentApplication.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
var connectionString = "Server=(local)\\SQLEXPRESS;Database=StudentNewDatabase;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true";

builder.Services.AddDbContextPool<StudentDbContext>(options =>
    options.UseSqlServer(connectionString));
//AddDbContextPool is better than AddDbContext as it reuses the same
//StudentDbContext instance

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<StudentDbContext>();

builder.Services.AddMvc();
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
builder.Services.AddTransient<TestService>();//Factory of Transient type, will provide new instance whenever requested
builder.Services.AddKeyedSingleton<TestService>("single");
builder.Services.AddKeyedTransient<TestService>("transient");
builder.Services.AddKeyedScoped<TestService>("scoped");
//builder.Services.AddSingleton<IStudentServices, StudentDataSource>();
builder.Services.AddTransient<IStudentServices, StudentDatabase>();

//Keyed services
//builder.Services.AddKeyedSingleton<IStudentServices, StudentDataSource>("First");
//builder.Services.AddKeyedSingleton<IStudentServices, StudentDatabase>("Second");
//builder.Services.AddScoped<TestService>();

var app = builder.Build();

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