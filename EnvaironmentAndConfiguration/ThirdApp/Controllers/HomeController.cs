using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using ThirdApp.Models;

namespace ThirdApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _webHost;
        private readonly IConfiguration _configuration;
        private readonly IOptions<Google> _google;

        public HomeController(ILogger<HomeController> logger,
            IWebHostEnvironment webHost,
            IConfiguration configuration,
            IOptions<Google> Google)
        {
            _logger = logger;
            _webHost = webHost;
            _configuration = configuration;
            _google = Google;
        }

        public IActionResult Index()
        {
            //ViewBag.ContentRootPath = _webHost.ContentRootPath;
            //ViewBag.WebRootPath = _webHost.WebRootPath;
            //ViewBag.Env_Name = _webHost.EnvironmentName;

            //ViewBag.MyKey = _configuration.GetSection("MyKey").Value;
            //ViewBag.ClientId = _configuration["Google:ClientId"];
            //ViewBag.ClientSecret = _configuration["Google:ClientSecret"];
            //var GoogleSetting = _configuration.GetSection("Google").Get<Google>();
            //var GoogleSetting = new Google();
            //_configuration.GetSection("Google").Bind(GoogleSetting);
            return View(/*GoogleSetting*/_google.Value);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("Home/Error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("Home/Stage")]
        public IActionResult Stage()
        {
            return View();
        }
    }
}

//Change Environment
//in terminal
//$env:ASPNETCORE_URLS="http:localhost:5003"
//$env:ASPNETCORE_ENVIRONMENT="Staging"
//dotnet run --no-launch-profile

//start User Secret
//dotnet user-secrets init
//dotnet user-secrets set "Google:ClientId" "Client I From USerSecrets"
//dotnet user-secrets set "Google:ClientSecret" "Client Secret From USerSecrets"
//dotnet user-secrets list

//access Evironment variable
//$env:Google__ClientId="Client Id From Environment Variable"
//$env:Google__ClientSecret="Client Secret From Environment Variable"
//dotnet run --no-launch-profile