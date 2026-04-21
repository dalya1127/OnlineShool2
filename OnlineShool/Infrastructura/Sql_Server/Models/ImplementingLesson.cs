using System;
using System.Collections.Generic;

namespace OnlineShool.Infrastructura.Sql_Server.Models;

public partial class ImplementingLesson
{
    public int Id { get; set; }

    public int IdUsers { get; set; }

    public int IdLessons { get; set; }

    public string? Description { get; set; }

    public int IdStatusLessons { get; set; }

    public virtual Lesson IdLessonsNavigation { get; set; } = null!;

    public virtual StatusLesson IdStatusLessonsNavigation { get; set; } = null!;

    public virtual User IdUsersNavigation { get; set; } = null!;
}
