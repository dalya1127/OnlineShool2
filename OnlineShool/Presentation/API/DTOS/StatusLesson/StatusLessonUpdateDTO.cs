namespace OnlineShool.Presentation.API.DTOS.StatusLesson
{
    public class StatusLessonUpdateDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }
    }
}
