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
            if (usersServices.SignUp(user) == null)
                return BadRequest();
            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }




        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id,User userToUpdate)
        {
            if (Zxcvbn.Core.EvaluatePassword(userToUpdate.Password).Score <= 2)
                return BadRequest("Weak password");
            try
            {
                if (usersServices.UpdateUser(id,userToUpdate)!=null)
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
            usersServices.RemoveUser(id);
        }
    }
}
