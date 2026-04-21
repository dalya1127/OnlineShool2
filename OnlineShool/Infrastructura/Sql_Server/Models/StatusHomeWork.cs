using System;
using System.Collections.Generic;

namespace OnlineShool.Infrastructura.Sql_Server.Models;

public partial class StatusHomeWork
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<ImplementingHomeWork> ImplementingHomeWorks { get; set; } = new List<ImplementingHomeWork>();
}
