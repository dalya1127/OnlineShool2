namespace OnlineShool.Presentation.API.DTOS.ImplementingLesson
{
    public class ImplementingLessonUpdateDTO
    {
        public int Id { get; set; }

        public int? IdUsers { get; set; }

        public int? IdLessons { get; set; }

        public string? Description { get; set; }

        public int? IdStatusLessons { get; set; }
    }
}
