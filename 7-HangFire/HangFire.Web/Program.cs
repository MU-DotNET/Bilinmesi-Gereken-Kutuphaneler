using Hangfire;
using HangFire.Web.Services;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddHangfire(config => config.UseSqlServerStorage(() => new SqlConnection(builder.Configuration.GetConnectionString("HangFireConnection"))));
builder.Services.AddHangfireServer();

builder.Services.AddScoped<IEmailSender, EmailSender>();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseHangfireDashboard("/hangfire");

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
