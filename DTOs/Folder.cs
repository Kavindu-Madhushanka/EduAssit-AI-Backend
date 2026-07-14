using System.ComponentModel.DataAnnotations;

namespace eduasst_backend.DTOs
{
    public class Folder
    {
        
        public int UserID { get; set; }

        
        public string FolderName { get; set; } = String.Empty;
    }
}
