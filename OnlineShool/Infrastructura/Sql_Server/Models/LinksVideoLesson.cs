

namespace OnlineShool.Infrastructura.Sql_Server.Models;

public partial class LinksVideoLesson
{
    public int Id { get; set; }

    public int IdLessons { get; set; }

    public int IdVideos { get; set; }

    public virtual Lesson IdLessonsNavigation { get; set; } = null!;

    public virtual Video IdVideosNavigation { get; set; } = null!;
}
