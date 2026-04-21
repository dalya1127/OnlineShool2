using System;
using System.Collections.Generic;

namespace OnlineShool.Infrastructura.Sql_Server.Models;

public partial class Comment
{
    public int Id { get; set; }

    public string Text { get; set; } = null!;

    public int IdUser { get; set; }

    public int IdLessons { get; set; }

    public int Date { get; set; }

    public int IdAnswerComment { get; set; }

    public virtual Lesson IdLessonsNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
