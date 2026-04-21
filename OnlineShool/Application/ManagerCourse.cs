using OnlineShool.Domain;
using OnlineShool.Infrastructura.Instructions;
using OnlineShool.Infrastructura.Sql_Server.Models;

namespace OnlineShool.Application
{
    public class ManagerCourse : ICourseDomain
    {
        ICourseRepository _courseRepository;
        IPurchasedCourse _purchasedCourse;
        public ManagerCourse(ICourseRepository courseRepository, IPurchasedCourse purchasedCourse)
        {
            _courseRepository = courseRepository;
            _purchasedCourse = purchasedCourse;
        }

        private static CourseDomain ConvertCourseToDomain(Course course)
        {
            return new CourseDomain
            {
               Name = course.Name,
               Description = course.Description,
               Id = course.Id

            };
        }

        private static PurchasedCourseDomain ConvertPurchasedCourseToDomain(PurchasedCourse purchasedCourse)
        {
            return new PurchasedCourseDomain
            {
                 Id = purchasedCourse.Id,
                 IdCourses = purchasedCourse.IdCourses,
                 IdUser = purchasedCourse.IdUser
            };
        }


        private static IReadOnlyList<CourseDomain> ConvertCourseToList(IReadOnlyList<Course> course)
        {
            var result = new List<CourseDomain>();
            foreach (var courseItem in course)
            {
                result.Add(ConvertCourseToDomain(courseItem));
            }
            return result;


        }

        private static List<PurchasedCourseDomain> ConvertPurchasedCourseToList(List<PurchasedCourse> purchCourse)
        {
            var result = new List<PurchasedCourseDomain>();
            foreach (var purchCourseItem in purchCourse)
            {
                result.Add(ConvertPurchasedCourseToDomain(purchCourseItem));
            }
            return result;


        }


        public async Task<CourseDomain> CreateAsync(string Name, string? Description = null, string? LinkPic = null)
        {
            var newCourse = await _courseRepository.CreateAsync(Name, Description, LinkPic);
            return ConvertCourseToDomain(newCourse);
        }

        public async Task<PurchasedCourseDomain> CreatePurchasedCourseAsync(int IdUser, int IdCourse)
        {
            var newPurchCourse = await _purchasedCourse.CreatePurchasedAsync(IdUser, IdCourse);
            return ConvertPurchasedCourseToDomain(newPurchCourse);
        }

        public async Task DeleteCourseAsync(int id)
        {
            await _courseRepository.DeleteAsync(id);
        }

        public async Task DeletePurchasedCourseAsync(int id)
        {
            await _purchasedCourse.DeletePurchasedAsync(id);
        }

        public async Task<IReadOnlyList<CourseDomain>> GetAllCourseAsync()
        {
            var newCourses = await _courseRepository.GetAllAsync();
            return ConvertCourseToList(newCourses);
        }

        
        public async Task<List<PurchasedCourseDomain>> GetPurchasedCourseByUser(int id)
        {
            var newPurch = await _purchasedCourse.GetPurchasedCourseByUser(id);
            return ConvertPurchasedCourseToList(newPurch);
        }

        public async Task<CourseDomain> UpdateAsync(int Id, string? Name = null, string? Description = null, string? LinkPic = null)
        {
            var newCourse = await _courseRepository.UpdateAsync(Id,Name, Description, LinkPic);
            return ConvertCourseToDomain(newCourse);            
        }

        public async Task<PurchasedCourseDomain> UpdatePurchasedCourseAsync(int id, int? IdUser = null, int? IdCourse = null)
        {
            var newPurchCourse = await _purchasedCourse.UpdatePurchasedAsync(id,IdUser, IdCourse);
            return ConvertPurchasedCourseToDomain(newPurchCourse);
        }
    }
}
