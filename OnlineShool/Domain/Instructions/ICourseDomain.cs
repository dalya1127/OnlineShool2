

namespace OnlineShool.Domain;
public interface ICourseDomain
{
    Task<IReadOnlyList<CourseDomain>> GetAllCourseAsync();

    Task<CourseDomain> CreateAsync(
        string Name,
        string? Description = null,
        string? LinkPic = null
        );

    Task<CourseDomain>UpdateAsync(
        int Id,
        string? Name = null,
        string? Description = null,
        string? LinkPic = null
        );

    Task<List<PurchasedCourseDomain>> GetAllAsync();
    Task<List<PurchasedCourseDomain>> GetPurchasedCourseByUser(int id);
    Task<PurchasedCourseDomain> CreatePurchasedCourseAsync(
        int IdUser,
        int IdCourse
        );
    Task<PurchasedCourseDomain> UpdatePurchasedCourseAsync(
        int id,
        int? IdUser = null,
        int? IdCourse = null
        );
    Task DeletePurchasedCourseAsync(int id);
    Task DeleteCourseAsync(int id);
}
