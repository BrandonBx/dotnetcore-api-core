using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DotnetCore.project.DTOs;
using DotnetCore.project.Exceptions;
using DotnetCore.project.Models;
using DotnetCore.project.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotnetCore.project.Controllers
{
    [Authorize]
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private IMapper _mapper;

        public UserController(
            IUserService userService,
            IMapper mapper)
        {
            _userService = userService;   
            _mapper = mapper;
        }

        [HttpGet]
        public async  Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            IEnumerable<User> users = await _userService.GetAll();
            
            if(users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(long id)
        {
            User user = await _userService.GetById(id);
            if(user == null)
            {
                return null; // TODO : Return NotFound
            }
            return user;
        }
        [HttpPost]
        public async Task<ActionResult<User>> PostUser ([FromBody]UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
             try 
            {
                // save 
                User userCreated = await _userService.Create(user, userDto.Password);
                return Ok(userCreated);
            } 
            catch(AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut]
        public async Task<ActionResult<User>> Update(User user)
        {
            User userUpdated =  await _userService.Update(user);
            return Ok(userUpdated);
        }
    }
}