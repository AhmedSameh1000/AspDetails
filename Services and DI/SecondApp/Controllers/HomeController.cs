using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace SecondApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _iproductsService1;
        private readonly IProductService _iproductsService2;
        private readonly IProductService _iproductsService3;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public HomeController
            (
            IProductService IproductsService1,
            IProductService IproductsService2,
            IProductService IproductsService3,
            IServiceScopeFactory serviceScopeFactory
            )
        {
            _iproductsService1 = IproductsService1;
            _iproductsService2 = IproductsService2;
            _iproductsService3 = IproductsService3;
            _serviceScopeFactory = serviceScopeFactory;
        }

        public IActionResult Index(/*[FromServices] IProductService product*/)
        {
            ViewBag.Obj1EqualObj2 = ReferenceEquals(_iproductsService1, _iproductsService2)
                ? "Object 1 == Object 2" : "Object 1 != Object 2";

            ViewBag.Obj2EqualObj3 = ReferenceEquals(_iproductsService2, _iproductsService3)
                ? "Object 2 == Object 3" : "Object 2 != Object 3";

            //var Products = _iproductsService1.GetProducts();
            ViewBag.IdIns1 = ++_iproductsService1.Id_ins;
            ViewBag.IdIns2 = _iproductsService2.Id_ins;
            ViewBag.IdIns3 = _iproductsService3.Id_ins;
            ////

            ViewBag.InstanseId_PS_1 = _iproductsService1.Id;
            ViewBag.InstanseId_PS_2 = _iproductsService2.Id;
            ViewBag.InstanseId_PS_3 = _iproductsService3.Id;

            using (var Scope = _serviceScopeFactory.CreateScope())
            {
                var ProductService1 = Scope.ServiceProvider.GetService<IProductService>();
                var ProductService2 = Scope.ServiceProvider.GetService<IProductService>();

                ViewBag.psChild1 = ProductService1.Id;
                ViewBag.psChild2 = ProductService2.Id;
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}