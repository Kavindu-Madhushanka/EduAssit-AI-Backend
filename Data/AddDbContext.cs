using eduasst_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace eduasst_backend.Data

{
    public class AddDbContext:DbContext
    {
        public AddDbContext(DbContextOptions<AddDbContext> options):base(options) { 
        }
        public DbSet<Users> usersdata { get; set; }
        public DbSet<SubjectFolder> subjectfolders { get; set; }

        public DbSet<LessonData> lessons { get; set; }
    };
    

}
