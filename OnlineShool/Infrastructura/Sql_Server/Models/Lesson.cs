using System;
using System.Collections.Generic;

namespace OnlineShool.Infrastructura.Sql_Server.Models;

public partial class Lesson
{
    public int Id { get; set; }

    public int IdCourses { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? LinkPic { get; set; }

    public string? LinkFile { get; set; }

    public int NumberLessons { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual Course IdCoursesNavigation { get; set; } = null!;

    public virtual ICollection<ImplementingLesson> ImplementingLessons { get; set; } = new List<ImplementingLesson>();

    public virtual ICollection<LinksLessonsHomeWork> LinksLessonsHomeWorks { get; set; } = new List<LinksLessonsHomeWork>();

    public virtual ICollection<LinksVideoLesson> LinksVideoLessons { get; set; } = new List<LinksVideoLesson>();
}
