using eduasst_backend.Data;
using eduasst_backend.DTOs;
using eduasst_backend.Models;
using eduasst_backend.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eduasst_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase {
        private readonly IAuthRepository _authRepo;
        public AuthController(IAuthRepository authRepo) {
            _authRepo = authRepo;
        }
        [HttpPost("signup")]
        public async Task<IActionResult> Register([FromBody] SignUp request) {
            try {
                Users createdUser = await _authRepo.Register(request);
                return Ok(new
                {
                    message = "User registered successfully!",
             
                    email = createdUser.Email,
                    userid=createdUser.Id
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("signin")]
        public async Task<IActionResult> Login([FromBody] SignIn request) {
            try
            {
                Users loginuser = await _authRepo.Login(request);
                return Ok(new
                {
                    message = "User login successfully!",
                    email = loginuser.Email,
                    userid=loginuser.Id
                });
            }
            catch (Exception ex) {
                return BadRequest(new { message = ex.Message });
            }
           
             
        }

        
    }
}
