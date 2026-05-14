namespace OnlineShool.Presentation.API.DTOS.Comment
{
    public record CommentUpdateDTO
    {
        public int id { get; set; }
        public string? Text { get; set; }
        public int? IdUser { get; set; }
        public int? IdLesson { get; set; }
        public DateTime? Date { get; set; }
        public int? IdAnswer { get; set; }

    }
}
