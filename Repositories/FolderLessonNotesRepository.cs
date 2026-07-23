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

        public async Task<SubjectFolder> CreateFolder(Folder request) {
            if (await CheckFolder(request.FolderName)) {
                throw new Exception("Folder is alredy created!");

            }

            var SubjectFolder = new SubjectFolder {
                UserID = request.UserID,
                FolderName = request.FolderName,
            };

            _context.subjectfolders.Add(SubjectFolder);
            await _context.SaveChangesAsync();
            return SubjectFolder;
        }



        public async Task<LessonData> CreateLesson(Lesson request) {
            if (await CheckLesson(request.LessonTitle)) {
                throw new Exception("This Lesson alredy have!");
            }

            var LessonData = new LessonData { 
                FolderId = request.FolderId,
                LessonTitle = request.LessonTitle,
                VideoUrl = request.VideoUrl,
            };
            _context.lessons.Add(LessonData);
            await _context.SaveChangesAsync();

            return LessonData;

        }

        public async Task<bool> DeleteLesson(Lesson request)
        {
     
            var lesson = await _context.lessons.FirstOrDefaultAsync(l => l.LessonId == request.LessonId && l.FolderId == request.FolderId);

            if (lesson == null)
            {
                return false; 
            }

            _context.lessons.Remove(lesson);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> CheckFolder(string foldername) {
            return await _context.subjectfolders.AnyAsync(u=> u.FolderName == foldername);
        }

        public async Task<bool> CheckLesson(string lessonTitle) {
            return await _context.lessons.AnyAsync(u => u.LessonTitle == lessonTitle);
        }

        public async Task<List<SubjectFolder>> PassAllFolder(Folder folder) {
            var allFolders=await _context.subjectfolders.Where(f=> f.UserID == folder.UserID).ToListAsync();
            return allFolders;
        }

        public async Task<List<LessonData>> PassAllLesson(Lesson lesson) {
            var allLesson=await _context.lessons.Where(f=> f.FolderId==lesson.FolderId).ToListAsync();
            return allLesson;
        }





    }
}
