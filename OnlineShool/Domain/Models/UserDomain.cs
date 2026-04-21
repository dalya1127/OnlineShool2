
namespace OnlineShool.Domain;

public partial class UserDomain
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Patronymic { get; set; }

    public string Login { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;
    public string? Role { get; set; } = null;

    public int IdRole { get; set; }


}
