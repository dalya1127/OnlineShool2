

namespace OnlineShool.Infrastructura.Sql_Server.Models;

public partial class HomeWork
{

    public int Id { get; set; }

    public string? Name { get; set; }
    public string? Description { get; set; }

    public string? LinkFile { get; set; }

    public virtual ICollection<ImplementingHomeWork> ImplementingHomeWorks { get; set; } = new List<ImplementingHomeWork>();

    public virtual ICollection<LinksLessonsHomeWork> LinksLessonsHomeWorks { get; set; } = new List<LinksLessonsHomeWork>();
}
