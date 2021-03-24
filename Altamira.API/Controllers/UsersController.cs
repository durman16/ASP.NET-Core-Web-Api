using Altamira.Bussiness.Abstract;
using Altamira.Entities.Concrete;
using AutoMapper;
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
        private readonly IMapper _mapper;
        //AltamiraDbContext context;
        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
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
            if (user != null)
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
        public async Task<IActionResult> Put([FromBody] UserDto user)
        {
            var existingUser = await _userService.GetUserById(user.id);
            if (existingUser != null)
            {
                _mapper.Map(user, existingUser);
                //TODO : Update metoduna direk requestten gelen tipi gönderirsen context tarafında hata oluşur. Bu yüzden context'ten aldığın
                //nesneyi map edip onu update metoduna göndermen gerekiyor.
                //Bunun dışında bu tarz güncelleme işlemlerinde request olarak bir DTO kullanılır. User nesnesi ile company, address ve geo güncelleyebiliyorum.
                return Ok(await _userService.UpdateUser(existingUser));
            }
            return NotFound();
        }
        /// <summary>
        /// Create a user
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Post([FromBody] UserDto user)
        {
            if (ModelState.IsValid)
            {
                //TODO : Oluşturma bölümünde de yine DTO kullanılması gerekiyor. 
                var newUser = new User();
                _mapper.Map(user, newUser);
                var createduser = await _userService.CreateUser(newUser);
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
