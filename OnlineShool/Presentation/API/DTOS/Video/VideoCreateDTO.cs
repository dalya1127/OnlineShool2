namespace OnlineShool.Presentation.API.DTOS.Video
{
    public record VideoCreateDTO
    {
        public string Name { get; set; }
        public string LinkFile { get; set; }
        public string Description { get; set; }
    }
}
