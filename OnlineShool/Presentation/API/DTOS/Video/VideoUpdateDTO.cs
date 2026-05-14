namespace OnlineShool.Presentation.API.DTOS.Video
{
    public record VideoUpdateDTO
    {
        public int id { get; set; }
        public string? Name { get; set; }
        public string? LinkFile { get; set; }
        public string? Description { get; set; }
        
    }
}
