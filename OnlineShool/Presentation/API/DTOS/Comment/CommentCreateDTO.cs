namespace OnlineShool.Presentation.API.DTOS.Comment
{
    public record CommentCreateDTO
    {
        public string Text { get; set; }
        public int IdUser { get; set; }
        public int IdLesson { get; set; }
        public int Date { get; set; }
        public int? IdAnswer { get; set; }

    }
}
