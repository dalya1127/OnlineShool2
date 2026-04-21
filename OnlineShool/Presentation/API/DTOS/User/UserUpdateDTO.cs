namespace OnlineShool.Presentation.API.DTOS.User
{
    public record UserUpdateDTO
    {
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic {  get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int IdRole { get; set; }
    }
}
