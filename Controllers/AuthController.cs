using eduasst_backend.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eduasst_backend.DTOs;
using eduasst_backend.Models;

namespace eduasst_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AddDbContext _context;

        public AuthController(AddDbContext context) { 
            _context = context;
        }
    }
}
