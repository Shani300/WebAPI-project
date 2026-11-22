using Microsoft.AspNetCore.Mvc;
using Services;
using Entity;
using Zxcvbn;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UsersController : ControllerBase
    {
        private IUsersServices usersServices;

        //Who gives the controller an IUsersServices? The assignment asks to register it in Program.cs with AddScoped, using the interface as the service type
        public UsersController(IUsersServices usersServices)
        {
            this.usersServices = usersServices;
        }

        [HttpPost("checkPassword")]
        public int PasswordCheck([FromBody] Password password)
        {
            return Zxcvbn.Core.EvaluatePassword(password.PasswordValue).Score;
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            User user=usersServices.GetUserByID(id);
            if(user!=null)  return Ok(user);
            return NotFound();
        }

        // POST api/<UsersController>
        [HttpPost("login")]
        //The assignment asks a login with a wrong password to return 204 (NoContent). What should this return when the login fails?
        public ActionResult<User> PostLogin([FromBody] LoginUser loginUser)
        {
            User user = usersServices.Login(loginUser);
            if (user != null)
                return Ok(user);
            return NotFound();
        }

        [HttpPost("signin")]
        public ActionResult<User> PostSignUp([FromBody] User user)
        {
            //The assignment asks the users controller to use the password service's interface. Where is the password service? The password check is done here directly
            if (Zxcvbn.Core.EvaluatePassword(user.Password).Score <= 2)
            {
                return BadRequest("Password is too weak.");
            }
            usersServices.SignIn(user);
            return CreatedAtAction(nameof(Get), new { id = user.UserID }, user);
        }




        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        //The route has {id}, but Put has no id parameter: how does the id get into userToUpdate? The assignment asks PUT to update the user with this id
        public ActionResult Put(User userToUpdate)
        {
            if (Zxcvbn.Core.EvaluatePassword(userToUpdate.Password).Score <= 2)
                return BadRequest("Weak password");
            try
            {
                if (usersServices.Update(userToUpdate))
                    return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return StatusCode(500);

        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
