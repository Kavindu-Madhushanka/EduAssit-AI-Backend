using System.ComponentModel.DataAnnotations;

namespace eduasst_backend.Models
{
    public class SubjectFolder
    {
        [Key]
        public int FolderID { get; set; }

        [Required]
        public int UserID { get; set; }

        [Required]
        public string FolderName { get; set; }=String.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


    }
}
