using eduasst_backend.DTOs;
using eduasst_backend.Models;
namespace eduasst_backend.Repositories
{
    public interface IFolderLessonNotesRepository
    {
        Task<List<SubjectFolder>> CreateFolder(Folder request);
        Task<bool>CheckFolder(string  folderName);
    }
}
