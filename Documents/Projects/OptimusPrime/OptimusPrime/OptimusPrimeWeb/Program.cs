
using OptimusPrimeWeb.Services;
using OptimusPrimeWeb.Validations;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder.Services);

// Add services to the container.
builder.Services.AddControllersWithViews();

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

void ConfigureServices(IServiceCollection services)
{
    services.AddTransient<IUserInputValidateConsumer, SortUserInputValidationConsumer>();
    services.AddTransient<IUserInputServices, SortUserInputServices>();
    services.AddTransient<IRandomIntegerGeneratorServices, RandomIntegerGeneratorServices>();

}