using eduasst_backend.Models;
using eduasst_backend.Data;
using eduasst_backend.DTOs;
using Microsoft.EntityFrameworkCore;
namespace eduasst_backend.Repositories
{
    public class AuthRepository:IAuthRepository
    {
        private readonly AddDbContext _context;

        public AuthRepository(AddDbContext context) {
            _context = context;
        }

        public async Task<Users> Register(SignUp request) {
            if (await UserCheck(request.Email)) {
                throw new Exception("Email is already registered!");
            }
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var Users = new Users
            {
                Email = request.Email,
                PasswordHash = passwordHash,
                FullName=request.FullName
            };

            _context.usersdata.Add(Users);
            await _context.SaveChangesAsync();

            return Users;

        }

        public async Task<Users> Login(SignIn request) {
            var user= await _context.usersdata.FirstOrDefaultAsync(u=> u.Email == request.Email);
            if (user == null)
            {
                throw new Exception("Invalid Email or Password!");
            }

            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);

            if (!isPasswordValid) {
                throw new Exception("Invalid Email or Password!");
            }

            return user;
        }
        public async Task<bool> UserCheck(string email)
        {
          
            return await _context.usersdata.AnyAsync(u => u.Email == email);
        }
    }
}
