using System.ComponentModel.DataAnnotations;
namespace FirstApp.Models
{
    public class User
    {
        [Required(ErrorMessage ="Please Enter Your Name")]
        [Display(Name= "Full Name")]
        [StringLength(20,MinimumLength =5,
            ErrorMessage ="{0} Should Between {2} and {1}")]
        public string? Name { get; set; }
        [Required(ErrorMessage ="Please Enter Your Email")]
        public string? Email { get; set; }
        [Range(15,80,ErrorMessage ="{0} Between {1} and {2}")]
        public int? Age { get; set; }
        public string? Phone { get; set; }
        public List<string> Languge { get; set; }
        public string? Password { get; set; }

        public string? ConfirmPassword { get; set; }
        public string GetUser()
        {
            return $"User object - User name: {Name}, Email: {Email}, Age: {Age}, Phone: {Phone}, Password: {Password}, Confirm Password: {ConfirmPassword}, Languge : {string.Join('|',Languge)}";
        } 
    }
}
