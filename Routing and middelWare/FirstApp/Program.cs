
var builder = WebApplication.CreateBuilder(args);
//is we need to Deal with xml in request and response use that line 
builder.Services.AddControllers().AddXmlSerializerFormatters();
//builder.Services.AddScoped<HomeController>();

//builder.Services.AddScoped<CustomMiddelWare>();
var app = builder.Build();
#region MiddelWareWithRouting
//app.Use(async(HttpContext context,RequestDelegate next) =>
//{
//    await context.Response.WriteAsync("<h1>Middlewre 1</h1>");
//    await next(context);
//});

//app.UseMiddleware<CustomMiddelWare>();

//app.UseCustomMiddleWare();
//app.UseConversionMiddleWare();

//app.Use(async (HttpContext context, RequestDelegate next) =>
//{
//    await context.Response.WriteAsync("<h1>Middlewre 3</h1>");
//});

//app.UseWhen(c => c.Request.Query.ContainsKey("Name"),app => app.UseConversionMiddleWare() ) ;


//app.Run(async (Context) =>
//{
//    await Context.Response.WriteAsync("Hello from Middel ware2");
//});


//enable routing
//app.UseRouting();
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapGet("/Contect", () => "Hello From Contact");
//});

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapGet("/Home", () => "Hello From Home");
//});

//app.MapGet("/Contect", () => "Hello From Contact");
//app.MapGet("/", () => "Hello From Home");
//app.MapPost("/Data", async (context) =>
//{
//    var data = context.Request.Headers["Name"].ToString();
//    await context.Response.WriteAsync(data);
//});

//app.Map("/Data", async (context) =>
//{
//    var data = context.Request.Headers["Name"].ToString();
//    await context.Response.WriteAsync(data);
//});
#endregion

#region DefaultParametars
//Ex: files/sample.txt
//app.Map("files/{filename=default}/{extension=jpg}", async context =>
//{
//    var fileName = context.Request.RouteValues["filename"];
//    var extension = context.Request.RouteValues["extension"];
//    await context.Response.WriteAsync($"In files - {fileName} - {extension}");
//});
////Ex: user/profile/1
//app.Map("user/profile/{userid}", async context =>
//{
//    var userId = context.Request.RouteValues["userid"];
//    await context.Response.WriteAsync($"In User profile - {userId}");
//});
#endregion

#region OptionParameterRoutes
////Ex: files / sample.txt
//app.Map("files/{filename=default}/{extension=jpg}", async context =>
//{
//    var fileName = context.Request.RouteValues["filename"];
//    var extension = context.Request.RouteValues["extension"];
//    await context.Response.WriteAsync($"In files - {fileName} - {extension}");
//});
////Ex: user/profile/1
//app.Map("user/profile/{userid?}", async context =>
//{
//    if (context.Request.RouteValues.ContainsKey("userid"))
//    {
//        var userId = context.Request.RouteValues["userid"];
//        await context.Response.WriteAsync($"In User profile - {userId}");
//    }
//    else
//    {
//        await context.Response.WriteAsync($"User Id is Not Found");
//    }
//});
#endregion

#region RouteParameterDateType
///*
//int 
//double 
//flaot
//Guid
//DateTime
//alpha
//etc....
// */
////Ex: files / sample.txt
//app.Map("files/{filename=default}/{extension=jpg}", async context =>
//{
//    var fileName = context.Request.RouteValues["filename"];
//    var extension = context.Request.RouteValues["extension"];
//    await context.Response.WriteAsync($"In files - {fileName} - {extension}");
//});
////Ex: user/profile/1
//app.Map("user/profile/{userid:Guid?}", async context =>
//{
//    if (context.Request.RouteValues.ContainsKey("userid"))
//    {
//        var userId = context.Request.RouteValues["userid"];
//        await context.Response.WriteAsync($"In User profile - {userId}");
//    }
//    else
//    {
//        await context.Response.WriteAsync($"User Id is Not Found");
//    }
//});
#endregion

#region RouteParameterLength
////Ex: files / sample.txt
////lenght(3)
////maxlength(4)
////minlength(2)
//app.Map("files/{filename=default}/{extension:alpha:length(3)=jpg}", async context =>
//{
//    var fileName = context.Request.RouteValues["filename"];
//    var extension = context.Request.RouteValues["extension"];
//    await context.Response.WriteAsync($"In files - {fileName} - {extension}");
//});
////Ex: user/profile/1
//app.Map("user/profile/{userid:Guid?}", async context =>
//{
//    if (context.Request.RouteValues.ContainsKey("userid"))
//    {
//        var userId = context.Request.RouteValues["userid"];
//        await context.Response.WriteAsync($"In User profile - {userId}");
//    }
//    else
//    {
//        await context.Response.WriteAsync($"User Id is Not Found");
//    }
//});
#endregion

#region DealWithStaticFile
//app.UseStaticFiles();
//when you need to change defautl from wwwroot to any file you create it 
//var builder = WebApplication.CreateBuilder(new WebApplicationOptions()
//{
//   WebRootPath="Your file Name"
//});
app.UseStaticFiles();
#endregion

app.MapControllers();

app.Run(); 
