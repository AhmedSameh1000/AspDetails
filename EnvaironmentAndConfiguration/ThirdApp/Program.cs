using ThirdApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.Configure<Google>(builder.Configuration.GetSection("Google"));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
}
else if (app.Environment.IsEnvironment("Staging"))
{
    app.UseExceptionHandler("/Home/Stage");
}
else
{
    app.UseExceptionHandler("/Home/Error");
}

//app.Map("/", async (context) =>
//{
//    context.Response.Headers.ContentType = "text/html";
//    await context.Response.WriteAsync($"<h1>{builder.Configuration.GetSection("mykey").Value}</h1>");
//    await context.Response.WriteAsync($"<h1>{builder.Configuration.GetValue<string>("mykey")}</h1>");
//    await context.Response.WriteAsync($"<h1>{builder.Configuration.GetSection("mykey").Value}</h1>");
//});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();