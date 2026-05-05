

namespace OnlineShool.Infrastructura.Sql_Server.Models;

public partial class ImplementingHomeWork
{
    public int Id { get; set; }

    public int IdUser { get; set; }

    public int IdHomeWork { get; set; }

    public int IdStatusHomeWork { get; set; }

    public string? LinkFile { get; set; }

    public int? Score { get; set; }

    public virtual HomeWork IdHomeWorkNavigation { get; set; } = null!;

    public virtual StatusHomeWork IdStatusHomeWorkNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
