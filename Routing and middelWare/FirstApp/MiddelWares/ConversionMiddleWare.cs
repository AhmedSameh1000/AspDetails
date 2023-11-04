namespace FirstApp.MiddelWares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ConvensionMiddleWare
    {
        private readonly RequestDelegate _next;
        public ConvensionMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Query.ContainsKey("FirstName") &&
                httpContext.Request.Query.ContainsKey("LastName"))
            {
                var FirstName = httpContext.Request.Query["FirstName"];
                var Lastname = httpContext.Request.Query["LastName"];
                await httpContext.Response.WriteAsync($"Hello {FirstName} {Lastname}");
            }
                await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ConversionMiddleWareExtensions
    {
        public static IApplicationBuilder UseConversionMiddleWare(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ConvensionMiddleWare>();
        }
    }
}
