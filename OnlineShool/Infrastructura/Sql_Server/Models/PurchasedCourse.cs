using System;
using System.Collections.Generic;

namespace OnlineShool.Infrastructura.Sql_Server.Models;

public partial class PurchasedCourse
{
    public int Id { get; set; }

    public int IdUser { get; set; }

    public int IdCourses { get; set; }

    public virtual Course IdCoursesNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
