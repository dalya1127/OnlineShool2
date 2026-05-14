using OnlineShool.Domain;

namespace OnlineShool.Presentation.API.DTOS.ImplementingHw
{
    public class ImplementingUpdateDTO
    {
        public int Id { get; set; }

        public int? IdUser { get; set; }

        public int? IdHomeWork { get; set; }

        public int? IdStatusHomeWork { get; set; }

        public string? LinkFile { get; set; }

        public int? Score { get; set; }

        public virtual HomeWorkDomain IdHomeWorkNavigation { get; set; } = null!;
    }
}
