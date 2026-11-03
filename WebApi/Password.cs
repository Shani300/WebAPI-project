using System.ComponentModel.DataAnnotations;

namespace WebApi
{
    public class Password
    {
        [Required]
        public string PasswordValue{ get; set; }
    }
}
