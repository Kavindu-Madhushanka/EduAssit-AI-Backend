using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using eduasst_backend.DTOs;
using eduasst_backend.Data;
using eduasst_backend.Models;
using eduasst_backend.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;

namespace eduasst_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FolderLessonNotesController : ControllerBase
    {
        private readonly IFolderLessonNotesRepository _folderRepository;
        public FolderLessonNotesController(IFolderLessonNotesRepository folderRepository)
        {

            _folderRepository = folderRepository;
        }
        [HttpPost("foldercreate")]

        public async Task<IActionResult> CreateFolder([FromBody] Folder request)
        {
            try
            {
                SubjectFolder createdfolders = await _folderRepository.CreateFolder(request);

                return Ok(new
                {
                    message = "Folder Created",
                    folder = createdfolders

                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }

        [HttpPost("createlesson")]
        public async Task<IActionResult> CreateLessons([FromBody] Lesson request)
        {
            try
            {
                LessonData createdlesson = await _folderRepository.CreateLesson(request);
                return Ok(new
                {
                    message = "Lesson created!",
                    lessons = createdlesson,
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("getallfolders")]
        public async Task<IActionResult> GetAllFolders([FromBody] Folder request)
        {
            try
            {

                List<SubjectFolder> allFolders = await _folderRepository.PassAllFolder(request);


                return Ok(allFolders);
            }
            catch
            {
                return BadRequest(new { message = "Empty Folders!" });

            }


        }


        [HttpPost("getalllesson")]
        public async Task<IActionResult> GetAllLesson([FromBody] Lesson request)
        {
            try
            {
                List<LessonData> allLesson = await _folderRepository.PassAllLesson(request);

                return Ok(allLesson);
            }
            catch {
                return BadRequest(new { message = "No Lessons!" });
            }
        }

        [HttpPost("deletelesson")]
        public async Task<IActionResult> DeleteLesson([FromBody] Lesson request)
        {
            try
            {
                bool isDeleted = await _folderRepository.DeleteLesson(request);

                if (!isDeleted)
                {
                    return NotFound(new { message = "Lesson not found!" });
                }

                return Ok(new { message = "Lesson Deleted Successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


    }
}
