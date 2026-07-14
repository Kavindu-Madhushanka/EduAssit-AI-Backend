using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using eduasst_backend.DTOs;
using eduasst_backend.Data;
using eduasst_backend.Models;
using eduasst_backend.Repositories;

namespace eduasst_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FolderLessonNotesController : ControllerBase
    {
        private readonly IFolderLessonNotesRepository _folderRepository;
            public FolderLessonNotesController(IFolderLessonNotesRepository folderRepository) { 

            _folderRepository = folderRepository;
        }
        [HttpPost("foldercreate")]

        public async Task<IActionResult> CreateFolder([FromBody] Folder request)
        {
            try
            {
                List<SubjectFolder> createdfolders = await _folderRepository.CreateFolder(request);

                return Ok(new{
                    message = "Folder Created",
                    folder=createdfolders

                    });
            }
            catch (Exception ex) { 
                return BadRequest(new {message=ex.Message});
            }

        }


    }
}
