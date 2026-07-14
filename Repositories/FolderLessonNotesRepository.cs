using eduasst_backend.Models;
using eduasst_backend.DTOs;
using eduasst_backend.Data;
using Microsoft.EntityFrameworkCore;
namespace eduasst_backend.Repositories
{
    public class FolderLessonNotesRepository:IFolderLessonNotesRepository
    {
        private readonly AddDbContext _context;

        public FolderLessonNotesRepository(AddDbContext context) { 
            _context = context;
        }

        public async Task<List<SubjectFolder>> CreateFolder(Folder request) {
            if (await CheckFolder(request.FolderName)) {
                throw new Exception("Folder is alredy created!");

            }

            var SubjectFolder = new SubjectFolder {
                UserID = request.UserID,
                FolderName = request.FolderName,
            };

            _context.subjectfolders.Add(SubjectFolder);
            await _context.SaveChangesAsync();


            var allFolder = await _context.subjectfolders
                .Where(f => f.UserID==request.UserID).ToListAsync();

            return allFolder;




        }

        public async Task<bool> CheckFolder(string foldername) {
            return await _context.subjectfolders.AnyAsync(u=> u.FolderName == foldername);
        }

    }
}
