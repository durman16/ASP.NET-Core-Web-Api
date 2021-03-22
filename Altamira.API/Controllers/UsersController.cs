using Altamira.Bussiness.Abstract;
using Altamira.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Altamira.API.Controllers
{
    //[Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        //AltamiraDbContext context;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        /// <summary>
        /// Get All Users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            //var identity = HttpContext.User.Identity as ClaimsIdentity;
            //IList<Claim> claim = identity.Claims.ToList();
            //var email = claim[0].Value;
            var users = await _userService.GetUsers();
            return Ok(users);
        }
        /// <summary>
        /// Get a user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/{id}")]
        [Authorize]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _userService.GetUserById(id);
            if (user!=null)
                return Ok(user);
            return NotFound();
        }
        /// <summary>
        /// Update a user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("[action]")]
        [Authorize]
        public async Task<IActionResult> Put([FromBody]User user)
        {
            if (await _userService.GetUserById(user.id) != null)
                return Ok(await _userService.UpdateUser(user));
            return NotFound();
        }
        /// <summary>
        /// Create a user
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Post([FromBody]User user)
        {
            if (ModelState.IsValid)
            {
                var createduser = await _userService.CreateUser(user);
                return CreatedAtAction("Get", new { id = createduser.id }, createduser);
            }
            return BadRequest(ModelState);
        }


        /// <summary>
        /// Delete a user
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete]
        [Route("[action]/{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _userService.GetUserById(id) != null)
            {
                await _userService.DeleteUser(id);
                return Ok();
            }
            return NotFound();
        }
    }
}
