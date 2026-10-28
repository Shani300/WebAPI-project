using System.ComponentModel.DataAnnotations;

namespace WebApi
{
    //In C#, a two-letter abbreviation is written Id, not ID: UserId.
    //If you rename it, users.txt still has the old names, so read it with
    //new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
    public class User
    {

        public int UserID{ get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]

        public string LastName { get; set; }
    }
}
