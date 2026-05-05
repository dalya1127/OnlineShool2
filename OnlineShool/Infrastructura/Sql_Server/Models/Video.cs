

namespace OnlineShool.Infrastructura.Sql_Server.Models;

public partial class Video
{
    public int Id { get; set; }

    public string? LinkFile { get; set; }

    public string? Description { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<LinksVideoLesson> LinksVideoLessons { get; set; } = new List<LinksVideoLesson>();
}
