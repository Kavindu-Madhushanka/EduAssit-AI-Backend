using eduasst_backend.DTOs;
using eduasst_backend.Models;
using Microsoft.EntityFrameworkCore.Internal;
namespace eduasst_backend.Repositories
{
    public interface IAuthRepository
    {
        Task<Users> Register(SignUp request);
        Task<bool> UserCheck(string email);
        Task<Users> Login(SignIn request);
    }
}
