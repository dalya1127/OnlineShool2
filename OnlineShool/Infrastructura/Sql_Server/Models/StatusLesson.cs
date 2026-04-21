using System;
using System.Collections.Generic;

namespace OnlineShool.Infrastructura.Sql_Server.Models;

public partial class StatusLesson
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<ImplementingLesson> ImplementingLessons { get; set; } = new List<ImplementingLesson>();
}
