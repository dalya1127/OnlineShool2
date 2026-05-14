namespace OnlineShool.Presentation.API.DTOS.Lesson
{
    public class LessonUpdateDTO
    {
    public int Id { get; set; }

    public int? IdCourses { get; set; }

    public string? Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? LinkPic { get; set; }

    public string? LinkFile { get; set; }

    public int? NumberLessons { get; set; }
    }
}
