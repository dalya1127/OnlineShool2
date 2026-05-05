

namespace OnlineShool.Infrastructura.Sql_Server.Models;

public partial class LinksLessonsHomeWork
{
    public int Id { get; set; }

    public int IdHomework { get; set; }

    public int IdLessons { get; set; }

    public virtual HomeWork IdHomeworkNavigation { get; set; } = null!;

    public virtual Lesson IdLessonsNavigation { get; set; } = null!;
}
