using Microsoft.AspNetCore.Mvc;

namespace ThirdApp_3.Controllers
{
    public class ProductController : Controller
    {
        [Route("products")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("product/search/{ProductId?}")]
        public IActionResult Search(int? ProductId)
        {
            ViewBag.ProductId = ProductId;
            return View();
        }

        [Route("product/order")]
        public IActionResult Order()
        {
            return View();
        }
    }
}