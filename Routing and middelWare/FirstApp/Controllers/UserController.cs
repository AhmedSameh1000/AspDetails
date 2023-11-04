using FirstApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstApp.Controllers
{
    public class UserController : Controller
    {
        [Route("Register")] 
        public IActionResult Register([FromBody]User user,[FromHeader]string hoppie)
        {
            if (Request.Headers.ContainsKey("hoppie"))
            {
                var hoppie2 = Request.Headers["hoppie"];
            }
            if(!ModelState.IsValid)
            {
                var ErrorsList=new List<string>();  
                foreach (var Values in ModelState.Values)
                {
                    foreach (var value in Values.Errors)
                    {
                        ErrorsList.Add(value.ErrorMessage);
                    }
                }
                return Ok(ErrorsList);
            }
            return Content($"{user.GetUser()}");
        }

  
    }
}
/*
  [Bind
     (nameof(user.Name), 
     nameof(user.Email),
     nameof(user.Password),
     nameof(user.ConfirmPassword))]
Json 
{
    "Name":"Ahmed Sameh",
    "Email":"ahmeds14@gmail.com",
    "Age":23,
    "Password":"123456",
    "ConfirmPassword":"1234546",
    "Phone":"01064423"
}
XML
<User>
    <Name>Ahmed Sameh</Name>
    <Email>Ahmed@gmail.com</Email>
    <Age>23</Age>
    <Phone>014555</Phone>
    <Password>123456</Password>
    <ConfirmPassword>123456</ConfirmPassword>
</User>
 */
