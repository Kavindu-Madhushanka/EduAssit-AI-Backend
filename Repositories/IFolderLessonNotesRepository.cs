using eduasst_backend.DTOs;
using eduasst_backend.Models;
namespace eduasst_backend.Repositories
{
    public interface IFolderLessonNotesRepository
    {
        Task<SubjectFolder> CreateFolder(Folder request);
        Task<LessonData> CreateLesson(Lesson request);

        Task<List<SubjectFolder>> PassAllFolder(Folder request);
        Task<List<LessonData>> PassAllLesson(Lesson request);
        Task<bool>CheckFolder(string  folderName);
        Task<bool>CheckLesson(string lessonTitle);
        Task<bool> DeleteLesson(Lesson request);


    }
}
