using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using MovieApp.Models;
using MovieApp.Data;
using MovieApp.Repository.Interface;
using MovieApp.Repository;
using MovieApp.Helpers;

namespace MovieApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        private UserDbContext dbContext;
        private readonly JWTService _jWTService = new JWTService();


        public UserController(IUserRepository userRepository, JWTService jWTService)
        {
            this.userRepository = userRepository;
            jWTService = _jWTService;

        }

        [HttpGet("GetUsers")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await userRepository.GetUsersAsync();
            return Ok(users);

        }

        [HttpPost("register")]
        public async Task<IActionResult> CreateUser(UserDto userdto)
        {

            User user_ = new User
            {
                
                username = userdto.username,
                password = BCrypt.Net.BCrypt.HashPassword(userdto.password),
                emailAddress = userdto.emailAddress
            };
            return Created("Success", userRepository.CreateUser(user_));
        }
        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {

            var user = userRepository.GetUsers(dto.username);
            if (user == null)
                return BadRequest(new { message = "invalid credentials" });
            if (!BCrypt.Net.BCrypt.Verify(dto.password, user.password))
            {
                return BadRequest(new { message = "invalid credentials" });
            }

            var jwt = _jWTService.Generate(user.id);
            Response.Cookies.Append("jwt", jwt, new CookieOptions
            {
                HttpOnly = true
            });
            return Ok(new
            {
                message = jwt
            }); ;

        }
        [HttpGet("user")]
        public IActionResult User()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];
                var token = _jWTService.Verify(jwt);
                int userId = int.Parse(token.Issuer);
                var user = userRepository.GetById(userId);
                return Ok(user);
            }
            catch (Exception e)
            {
                return Unauthorized();
            }
        }

        [HttpPost("Logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt");
            return Ok(new
            {
                message = "success"
            });
        }
    }
}
