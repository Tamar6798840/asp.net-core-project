using AutoMapper;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LoginRegister.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserSevices userService ;
       private readonly ILogger<UserController> _logger;
        private readonly IMapper _mapper;

        public UserController(IUserSevices userService, ILogger<UserController> logger, IMapper mapper)
        {
            this.userService=userService;
            _logger=logger;
            _mapper=mapper;
        }


        // POST: api/<loginController>
        [HttpPost("login")]
        public  async Task<ActionResult<UserDTO>> Login([FromBody] UserLoginDTO userDto)
        {
            
            User user =  await userService.GetUserByUserNameAndPasswordAsync(userDto.UserName, userDto.Password);
            if (user == null) {
                _logger.LogError("Someone didnt register and try login");
               
                return BadRequest();
               
            }
           _logger.LogInformation(userDto.UserName + "  login with password" + userDto.Password);

            UserDTO userToReturn= _mapper.Map<User, UserDTO>(user);
            return Ok(userToReturn);
        }
        // POST api/<loginController>
        [HttpPost]
        public async Task<ActionResult<UserDTO>> AddUser([FromBody] UserDTO userDTO)
        {
            User newUser = _mapper.Map<UserDTO, User>(userDTO);
             newUser =  await userService.AddUserAsync(newUser);
            return CreatedAtAction(nameof(Login), new { id = newUser.UserId }, userDTO);
        }

        [HttpPost("checkPassword")]
        public ActionResult CheckPassword([FromBody] string pwd)
        {
            return Ok(userService.Checkpassword(pwd));
        }

        // PUT api/<loginController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(int id, [FromBody] UserDTO userToUpdateDTO)
        {
            User userToUpdate = _mapper.Map<UserDTO, User>(userToUpdateDTO);
            if ( await userService.UpdateUserAsync(id, userToUpdate))
                return Ok();
            return BadRequest();
        }


    }
}
