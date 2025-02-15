using ChallengeIntuit.DAL.DTOs.Request;
using ChallengeIntuit.DAL.DTOs.Response;
using ChallengeIntuit.Domain.Abstractions.Service;
using ChallengeIntuit.Domain.DTOs.Request;
using ChallengeIntuit.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChallengeIntuit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<PaginationDTO<User>>> GetAll([FromQuery] FilterDTO filterDTO)
        {
            var users = await _userService.GetAllUsers(filterDTO);
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById([FromRoute] int id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet("searchByName/{name}")]
        public async Task<ActionResult<IEnumerable<User>>> SearchByName([FromRoute] string name)
        {
            var users = await _userService.SearchUsers(name);
            if (users == null || !users.Any())
            {
                return NotFound();
            }
            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser([FromBody] UserCreateDTO user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }
            var createdUser = await _userService.CreateUser(user);
            return Ok(createdUser);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UserUpdateDTO user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _userService.UpdateUser(user);
            if (!result)
            {
                return BadRequest();
            }
            return NoContent();
        }

        [HttpPut("{id}/delete")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            var result = await _userService.DeleteUser(id);
            if (!result)
            {
                return BadRequest();
            }
            return NoContent();
        }
    }
}
