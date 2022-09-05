using LabourCommissioner.Abstraction.Repositories;
using LabourCommissioner.Abstraction.Services;
using LabourCommissioner.Common.CustomAuthentication;
using LabourCommissioner.DataRepository.Repositories;
using LabourCommissioner.Services.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Data;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
{
    var services = builder.Services;
    //IConfiguration configuration = builder.Configuration;
    //string connectionString = configuration.GetConnectionString("DefaultConnection");
    //services.AddEntityFrameworkMySql();
    //services.AddDbContextPool<shramsetuContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
    services.AddHttpContextAccessor();
    services.AddControllersWithViews().AddRazorRuntimeCompilation();
    //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x => x.LoginPath = "/account/login");
    services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options=>
    {
        options.LogoutPath = "/account/login";
    });
    services.AddHttpClient();
    services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    services.AddScoped<PermissionRequirementFilter>();
    services.AddScoped<IAuthorizeRepository, AuthorizeRepository>();
    services.AddScoped<ISchemeUserServices, SchemeUserServices>();
    services.AddScoped<ISchemeUserRepository, SchemeUserRepository>();
    services.AddScoped<IRegistrationService, RegistrationService>();
    services.AddScoped<IRegistrationRepository, RegistrationRepository>();
    services.AddScoped<IAccountService, AccountService>();
    services.AddScoped<IAccountRepository, AccountRepository>();
    services.AddScoped<IHomeService, HomeService>();
    services.AddScoped<IHomeRepository, HomeRepository>();
    services.AddScoped<ISchemeService, SchemeService>();
    services.AddScoped<ISchemeRepository, SchemeRepository>();
    services.AddScoped<IBOCWSikshanSahayYojanaService, BOCWSikshanSahayYojanaService>();
    services.AddScoped<IBOCWSikshanSahayYojanaRepository, BOCWSikshanSahayYojanaRepository>();

    services.AddScoped<IGLWBHSCPurashkarYojanaService, GLWBHSCPurashkarYojanaService>();
    services.AddScoped<IGLWBHSCPurashkarYojanaRepository, GLWBHSCPurashkarYojanaRepository>();

    services.AddScoped<IReportsService, ReportsService>();
    services.AddScoped<IReportsRepository, ReportsRepository>();
    services.AddScoped<ClaimsPrincipal>();

    //services.AddScoped(typeof(IReportRepository<>), typeof(ReportRepository<>));


}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseExceptionHandler("/Home/Error");
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.Use(async (context, next) =>
{
    await next();
    if (context.Response.StatusCode == 404)
    {
        context.Request.Path = "/Home/NotFound";
        await next();
    }
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
