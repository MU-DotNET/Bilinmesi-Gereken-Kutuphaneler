var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Request ------------[DeveloperExceptionPage]--[ExceptionHandler]-----------------[UseStatusCodePages]----------------------------------->Response 

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{

    app.UseDeveloperExceptionPage();
    //1. Yol
    //app.UseStatusCodePages();
    //2. Yol
    //app.UseStatusCodePages("text/plain", "Bir hata var durum kodu:{0}");
    //3. Yol
    app.UseStatusCodePages(async context =>
    {
        context.HttpContext.Response.ContentType = "text/plain";
        await context.HttpContext.Response.WriteAsync($"Bir hata var. Durum Kodu: {context.HttpContext.Response.StatusCode}");
    });
}

app.UseExceptionHandler("/Home/Error");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
