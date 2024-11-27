using TaskTest.Shared;
using static TaskTest.Data.AdminSeeder;


var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(connectionString));
// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddIdentity<User, IdentityRole>(
    options =>
    {
        options.User.RequireUniqueEmail = true;
    })
    .AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();


builder.Services.AddTransient<ITaskRepository,TaskRepository>();
builder.Services.AddTransient<IFileService,FileService>();
builder.Services.AddTransient<ITaskImageRepository,TaskImageRepository>();
builder.Services.AddTransient<IProgrammingLanguagesRepository, ProgrammingLanguagesRepository>();
builder.Services.AddTransient<ITestRepository, TestRepository>();



var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    await AdminSeeder.SeedDefaultData(scope.ServiceProvider);
}

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




//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Account}/{action=Index}/{id?}");


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
       name: "Admin",
       pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Account}/{action=Index}/{id?}");
});



app.Run();
