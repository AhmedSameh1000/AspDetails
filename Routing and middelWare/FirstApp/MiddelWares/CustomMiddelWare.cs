namespace FirstApp.MiddelWares
{
    public class CustomMiddelWare : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("<h1>Custom Middlewre 2 start</h1>");
            await next(context);
            await context.Response.WriteAsync("<h1>Custom Middlewre 2 end</h1>");
        }

    }
    public static class CustomMiddelWare2
    {
        public static IApplicationBuilder UseCustomMiddleWare(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CustomMiddelWare>();
        }
    }
}

