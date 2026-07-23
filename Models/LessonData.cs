using System.ComponentModel.DataAnnotations;

namespace eduasst_backend.Models
{
    public class LessonData
    {
        [Key]
        public int LessonId { get; set; }

        [Required]
        public int FolderId { get; set; }

        [Required]
        public string LessonTitle { get; set; } = string.Empty;

        [Required]
        public string VideoUrl {  get; set; } = string.Empty;

        public DateTime UploadDate { get; set; } = DateTime.UtcNow;


    }
}
