using Microsoft.AspNetCore.Mvc;
using MVCApplication.Models;

namespace MVCApplication.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.appTitle = "MVC Application";
            var Person = new Person()
            {
                Name = "ahmed",
                DateOfBirth = new DateTime(2000, 7, 25),
                Language = Languge.Frensh,
                Hobbies = new List<string> { "swimming", "reading" }
            };
            var Products = new List<Product>()
            {
                new Product{Id=1,Name="Iphone"},
                new Product{Id=2,Name="Samsong"},
                new Product{Id=3,Name="Laptop"},
                new Product{Id=4,Name="Computer"},
                new Product{Id=5,Name="Ipad"},
            };
            var PersonProductRaper = new PersonProductRapper()
            {
                Person = Person,
                Products = Products
            };
            return View(PersonProductRaper);
        }
    }
}