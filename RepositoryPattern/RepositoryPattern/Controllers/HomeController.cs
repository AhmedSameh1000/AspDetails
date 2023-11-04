using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Data;
using RepositoryPattern.IRepository;
using RepositoryPattern.Models;
using System.Diagnostics;

namespace RepositoryPattern.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            //_unitOfWork.BeginTransaction();

            //try
            //{
            //    Category Category = new Category { Name = "Food For not Fun" };
            //    Category Category2 = null;

            //    _unitOfWork.Category.Add(Category);
            //    _unitOfWork.SaveChanges();
            //    _unitOfWork.Category.Add(Category2);
            //    _unitOfWork.SaveChanges();

            //    _unitOfWork.Commit();
            //}
            //catch
            //{
            //    _unitOfWork.Rollback();
            //}
            var data = _unitOfWork.Category.GetFirstOrDefault(c => c.Id == 1, new string[] { "Products" });

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}