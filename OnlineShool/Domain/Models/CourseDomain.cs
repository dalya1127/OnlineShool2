
namespace OnlineShool.Domain;

public partial class CourseDomain
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string? LinkPic { get; set; }


}
