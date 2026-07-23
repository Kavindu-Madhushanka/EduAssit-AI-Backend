namespace eduasst_backend.DTOs
{
    public class Lesson
    {
        public int? LessonId { get; set; }
        public int FolderId { get; set; }

        public string LessonTitle { get; set; }=string.Empty;

        public string VideoUrl {  get; set; }=string.Empty;
    }
}
