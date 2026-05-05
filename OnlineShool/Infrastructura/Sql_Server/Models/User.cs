

namespace OnlineShool.Infrastructura.Sql_Server.Models;

public partial class User
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Patronymic { get; set; }

    public string Login { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int IdRole { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual Role IdRoleNavigation { get; set; } = null!;

    public virtual ICollection<ImplementingHomeWork> ImplementingHomeWorks { get; set; } = new List<ImplementingHomeWork>();

    public virtual ICollection<ImplementingLesson> ImplementingLessons { get; set; } = new List<ImplementingLesson>();

    public virtual ICollection<PurchasedCourse> PurchasedCourses { get; set; } = new List<PurchasedCourse>();
}
