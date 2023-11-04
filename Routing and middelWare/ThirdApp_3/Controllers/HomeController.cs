using Microsoft.AspNetCore.Mvc;
using ThirdApp_3.Models;

namespace ThirdApp_3.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            //ViewData["ListTitle"] = "Brands";
            //ViewData["ListItems"] = new List<string>()
            //{
            //     "Iphone","Samsung","Dell","Toshipa","HP"
            //};

            var ListModel = new ListModel()
            {
                ListTitle = "Brands",
                ListItems = new List<string> { "Zara", "Dell", "Google" }
            };
            return View(ListModel);
        }

        [Route("about")]
        public IActionResult About()
        {
            return View();
        }

        [Route("contact-us")]
        public IActionResult Contact()
        {
            return View();
        }

        [Route("Display")]
        public IActionResult Display()
        {
            var listModel = new ListModel()
            {
                ListTitle = "Countries",
                ListItems = new List<string>
                {
                    "Egypt", "Iraq", "Amirca"
                }
            };
            return PartialView("_ListPartialView", listModel);
        }
    }
}