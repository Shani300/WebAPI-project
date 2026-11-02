using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Text.Json;
using Zxcvbn;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UsersController : ControllerBase
    {
        private UsersServices usersServices;


        [HttpPost("checkPassword")]
        public int passwordCheck([FromBody] Password p)
        {
            return Zxcvbn.Core.EvaluatePassword(p.PasswordValue).Score;
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
        public ActionResult<User> PostSignIn([FromBody] User user)
        {
            if (Zxcvbn.Core.EvaluatePassword(user.Password).Score <= 2)
            {
                return BadRequest("Password is too weak.");
            }
            usersServices.SignIn(user);
            return CreatedAtAction(nameof(Get), new { id = user.UserID }, user);
        }




        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
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
