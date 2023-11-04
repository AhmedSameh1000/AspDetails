using FirstApp.Models;
using Microsoft.AspNetCore.Mvc;
using data = System.IO;
public class HomeController : Controller
{
    private readonly IWebHostEnvironment _webHost;
    public HomeController(IWebHostEnvironment webHost)
    {
        this._webHost = webHost;
    }
    [Route("")]
    public IActionResult Index()
    {
        return Content("Welcome Home");
    }
    [Route("Contact/{Phone?}/{IsLoggedIn?}")]
    public IActionResult Contact(int ?Phone,bool? IsLoggedIn)
    {
        return Content($"Number >> {Phone} || {IsLoggedIn}");

    }
    [Route("Info")]
    public IActionResult Info(string Data)
    {
        var Name=Guid.NewGuid().ToString(); 
        data.File.WriteAllText(data.Path.Combine(_webHost.WebRootPath, (Name + ".txt")),Data);

        var res = data.File.ReadAllText(data.Path.Combine(_webHost.WebRootPath, (Name + ".txt")));
        if (data.File.Exists(data.Path.Combine(_webHost.WebRootPath, (Name + ".txt"))))
        {
            data.File.Delete(data.Path.Combine(_webHost.WebRootPath, (Name + ".txt")));
        }
        return Ok(res);
    }

    [Route("Image")]
    [HttpPost]
    public IActionResult Upluad(IFormFile File)
    {
        var RootPath = data.Path.Combine(_webHost.WebRootPath,"Data");
        //var imageDist = System.IO.Path.Combine(RootPath, File.FileName);
        var Extension=data.Path.GetExtension(File.FileName);
        using (FileStream fileStreams = new(Path.Combine(RootPath, (Guid.NewGuid().ToString()+Extension) /*File.FileName*/), FileMode.Create))
        {
            File.CopyTo(fileStreams);
        }
        //using (var sreamReader = new StreamReader(File.OpenReadStream()))
        //{
        //    string fileContent = sreamReader.ReadToEnd();
        //};


        //if (System.IO.File.Exists(imageDist))
        //{
        //    System.IO.File.Delete(imageDist);
        //}
        return Ok();
    }
    [Route("PDFs")]
    [HttpGet]
    public IActionResult Files()
    {
        var RootPath = data.Path.Combine(_webHost.WebRootPath, "Data");
        var pdfFileNames = Directory.GetFiles(RootPath, "*.*")
          .Select(Path.GetFileName)
          .ToList();
        //var RootPath2 = data.Path.Combine(_webHost.WebRootPath, "Data", "data2");

        //Directory.Delete(RootPath2);

        //var Files = Directory.GetDirectories(Environment.CurrentDirectory);

        //var Files2 = data.Path.Combine(_webHost.WebRootPath, "Data");

        return Ok(pdfFileNames);
    }

    [HttpPost]
    [Route("Create")]
    public IActionResult Create(Book book)
    {
        return Ok(book.GetBook());
    }
}


//RouteData
//QueryString
///01092532838/false?Phone=01554942386&IsLoggedIn=true
///
#region HomeDetails
//using Microsoft.AspNetCore.Mvc;
//using Data = System.IO;
//namespace FirstApp.Controllers
//{
//    public class HomeController :Controller
//    {

//        private readonly IWebHostEnvironment _hostingEnvironment;

//        public HomeController(IWebHostEnvironment hostingEnvironment)
//        {
//            _hostingEnvironment = hostingEnvironment;
//        }
//using Microsoft.AspNetCore.Mvc;

//[Route("Image")]
//[HttpPost]
//public IActionResult Upluad(IFormFile Image)
//{
//    var RootPath = _webHost.WebRootPath;
//    var imageDist = System.IO.Path.Combine(RootPath, Image.FileName);

//    //using (FileStream fileStreams = new(Path.Combine(RootPath, Image.FileName), FileMode.Create))
//    //{
//    //    Image.CopyTo(fileStreams);
//    //}
//    if (System.IO.File.Exists(imageDist))
//    {
//        System.IO.File.Delete(imageDist);
//    }
//    return Ok();
//}

//        [Route("")]
//        public ContentResult Index()
//        {
//            //var Content = new ContentResult()
//            //{
//            //    Content= "<h1>Hello From Index</h1>",
//            //    ContentType = "text/html",
//            //    StatusCode=StatusCodes.Status200OK
//            //};
//            return  Content("<h1>Hello From Index</h1>","text/html");
//        }

//        [Route("Contact")]
//        public string Contact()
//        {
//            return "Contact Us";
//        }
//        [Route("Person")]
//        public JsonResult Person()
//        {

//            //string
//            //Response.ContentType = "application/json";
//            //return "{'fname':'ahmed','lname':'sameh',age:23,}";
//            var Persons = new List<object>{
//                new {fname = "ahmed",lname = "sameh",age = 23},
//                new {fname = "ahmed",lname = "sameh",age = 23},
//                new {fname = "ahmed",lname = "sameh",age = 23},
//            };
//            //return new JsonResult(Persons);
//            return Json(Persons);
//        }

//        [Route("VirtualFileResult")]
//        public VirtualFileResult VirtualFileResult()
//        {
//            //return new VirtualFileResult("asp.pdf", "application/pdf");
//            return File("asp.pdf", "application/pdf");
//        }


//        [Route("PhysicalFileResult")]
//        public PhysicalFileResult PhysicalFileResult()
//        {
//            return PhysicalFile("asp.pdf", "application/pdf");
//        }
//        [Route("FileContentResult")]
//        public FileContentResult FileContentResult()
//        {
//            byte[] Bytes = Data.File.ReadAllBytes(Data.Path.Combine(_hostingEnvironment.WebRootPath,"logo.png"));
//            return new FileContentResult(Bytes, "image/png");
//        }


//        [Route("book")]
//        public IActionResult Book()
//        {
//            //Book id should be applied
//            if (!Request.Query.ContainsKey("bookid"))
//            {
//                //Response.StatusCode = 400;
//                //return Content("Book id is not supplied");
//                return BadRequest("Book Id Cant Be Null");
//            }

//            //Book id can't be empty
//            if (string.IsNullOrEmpty(Convert.ToString(Request.Query["bookid"])))
//            {
//                return Json(new { statusCode = "400", message = "Book id can not be null or empty" });
//            }

//            //Book id should be between 1 to 1000
//            int bookId = Convert.ToInt16(ControllerContext.HttpContext.Request.Query["bookid"]);
//            if (bookId <= 0)
//            {
//                //Response.StatusCode = 404;
//                //return Content("Book id can't be less than or equal to zero");
//                //return new NotFoundResult();
//                return NotFound("Not found data");

//                //return new StatusCodeResult(404);
//            }
//            if (bookId > 1000)
//            {
//                Response.StatusCode = 404;
//                return Content("Book id can't be greater than 1000");
//            }

//            //isloggedin should be true
//            if (Convert.ToBoolean(Request.Query["isloggedin"]) == false)
//            {
//                //Response.StatusCode = 401;
//                //return Content("User must be authenticated");
//                return Unauthorized("User Not Authenticated");
//            }

//            return PhysicalFile(Environment.CurrentDirectory +
//                "/asp.pdf", "application/pdf");

//        }

//        [Route("GetBook")]
//        public IActionResult GetBook()
//        {
//            return RedirectToAction("NewBook", "Home" ,new { id=10});
//        }

//        [Route("NewBook")]
//        public IActionResult newBook()
//        {
//            return PhysicalFile(Environment.CurrentDirectory +
//            "/asp.pdf", "application/pdf");
//        }


//        [Route("DealWithFiles")]
//        public void GetFile()
//        {
//            // Get the path to the wwwroot folder
//            string webRootPath = _hostingEnvironment.WebRootPath;

//            // Combine the path to the wwwroot folder with the relative path to your file
//            string filePath = Path.Combine(webRootPath, "asp.pdf");
//            var Name = Guid.NewGuid().ToString();
//            string Dist = Path.Combine(webRootPath, (Name + Data.Path.GetExtension(filePath)));

//            //string Destination = Path.Combine(webRootPath, "newasp.pdf");

//            //var NameWithOutEXT = Data.Path.GetFileNameWithoutExtension(filePath);
//            //var Extension=Data.Path.GetExtension(filePath);
//            //var Size = filePath.Length;

//                Data.File.Copy(filePath, Dist);

//            //if (Data.File.Exists(filePath))
//            //{
//            //    // Copy the file to the destination
//            //   Data.File.Copy(filePath, Destination, true);
//            //}


//            //using (FileStream fileStreams = new(Path.Combine(webRootPath,Name), FileMode.Create))
//            //{
//            //    filePath.CopyTo();
//            //}

//            //if (Data.File.Exists(filePath))
//            //{
//            //    // You can now work with the file, for example, read its contents
//            //    //string fileContents =Data.File.ReadAllText(filePath);
//            //    Data.File.Delete(filePath);

//            //    // Do something with the file contents
//            //    //return Content(fileContents);
//            //}
//            //else
//            //{
//            //    // File not found
//            //    //return NotFound();
//            //}
//        }

//    }
//}

#endregion