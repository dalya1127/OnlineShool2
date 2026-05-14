namespace OnlineShool.Presentation.API.DTOS.LinksVideoLesson
{
    public class LinksVideoLessonUpdateDTO
    {
        public int Id { get; set; }

        public int? IdLessons { get; set; }

        public int? IdVideos { get; set; }
    }
}
