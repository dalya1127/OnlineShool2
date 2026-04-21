namespace OnlineShool.Domain
{
    public interface IHomeWorkDomain 
    {
        Task<IReadOnlyList<HomeWorkDomain>> GetAllAsync();
        Task<List<HomeWorkDomain>> GetHomeWorkByLessonsAsync(int id);
        Task<List<HomeWorkDomain>> GetHomeWorkByCourseAsync(int id);


        Task<List<StatusHomeWorkDomain>> GetStatusHomeWorkByUser(int IdUser);
        Task<List<StatusHomeWorkDomain>> GetStatusHomeWorkByHomeWork(int id);


        Task<List<ImplementingHomeWorkDomain>> GetImplementingHomeworkByUser(int id);
        Task<List<ImplementingHomeWorkDomain>> GetImplementingHomeworkByHomework(int id);
        Task<HomeWorkDomain> CreateHomeworkAsync(
            string Name,
            string? Description,
            string? LinkFile = null
            );
        Task<HomeWorkDomain> UpdateHomeworkAsync(
            int id ,
            string? Name = null,
            string? Description = null,
            string? LinkFile = null
            );
        Task DeleteHomeworkAsync(int id);


        Task<StatusHomeWorkDomain> CreateStatusHomeworkAsync(
           string Name,
           string? Description
           );

        Task<HomeWorkDomain> UpdateStatusHomeworkAsync(
           int id,
           string? Name = null,
           string? Description = null
           );

        Task DeleteStatusHomeworkAsync(int id);

        Task<ImplementingHomeWorkDomain> CreateImplementingHomeworkAsync(
            int IdUser,
            int IdHomeWork,
            int IdStatusHomeWork,
            string? LinkFile = null,
            int? Score = null
            );
        Task<ImplementingHomeWorkDomain> UpdateImplementingHomeworkAsync(
            int id,
            int IdUser,
            int IdHomeWork,
            int IdStatusHomeWork,
            string? LinkFile = null,
            int? Score = null
            );
        Task DeleteImplementingHomeworkAsync(int id);
    }
}
