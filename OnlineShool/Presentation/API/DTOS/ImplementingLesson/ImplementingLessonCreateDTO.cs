namespace OnlineShool.Presentation.API.DTOS.ImplementingLesson
{
    public class ImplementingLessonCreateDTO
    {
        public int IdUsers { get; set; }

        public int IdLessons { get; set; }

        public string? Description { get; set; }

        public int IdStatusLessons { get; set; }
    }
}
