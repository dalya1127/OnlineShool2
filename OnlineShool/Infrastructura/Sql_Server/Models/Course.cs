

namespace OnlineShool.Infrastructura.Sql_Server.Models;

public partial class Course
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string? LinkPic { get; set; }

    public virtual ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();

    public virtual ICollection<PurchasedCourse> PurchasedCourses { get; set; } = new List<PurchasedCourse>();
}
