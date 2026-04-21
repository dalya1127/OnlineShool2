using OnlineShool.Domain;
using OnlineShool.Infrastructura.Instructions;
using OnlineShool.Infrastructura.Sql_Server;
using OnlineShool.Infrastructura.Sql_Server.Models;

namespace OnlineShool.Application
{
    public class ManagerHomework : IHomeWorkDomain
    {
        IHomeWork _homeworkRepository;
        IStatusHomeWork _statusHwRepository;
        IImplementingHomeWork _implementingHomeWorkRepository;
        ICourseRepository _courseRepository;

        public ManagerHomework(IHomeWork homeworkRepository, IStatusHomeWork statusHwRepository, IImplementingHomeWork implementingHomeWorkRepository, ICourseRepository courseRepository)
        {
            _homeworkRepository = homeworkRepository;
            _statusHwRepository = statusHwRepository;
            _implementingHomeWorkRepository = implementingHomeWorkRepository;
            _courseRepository = courseRepository;
        }

        private static HomeWorkDomain ConvertHomeWorkToDomain(HomeWork homeWork)
        {
            return new HomeWorkDomain
            {
                Id = homeWork.Id,
                Description = homeWork.Description,
                LinkFile = homeWork.LinkFile,
            };
        }



        private static IReadOnlyList<HomeWorkDomain> ConvertHomeWorkToList(IReadOnlyList<HomeWork> homeWorks)
        {
            var result = new List<HomeWorkDomain>();
            foreach (var hwItem in homeWorks)
            {

                result.Add(ConvertHomeWorkToDomain(hwItem));
            }
            return result;

        }

        private static List<HomeWorkDomain> ConvertHomeWorkToList(List<HomeWork> homeWorks)
        {
            var result = new List<HomeWorkDomain>();
            foreach (var hwItem in homeWorks)
            {

                result.Add(ConvertHomeWorkToDomain(hwItem));
            }
            return result;
        }


        private static List<ImplementingHomeWorkDomain> ConvertImplementingHWToList(List<ImplementingHomeWork> implementings)
        {
            var result = new List<ImplementingHomeWorkDomain>();
            foreach (var implementongHW in implementings)
            {

                result.Add(ConvertImplementingHWToDomain(implementongHW));
            }
            return result;
        }

        private static ImplementingHomeWorkDomain ConvertImplementingHWToDomain(ImplementingHomeWork implementongHW)
        {
            return new ImplementingHomeWorkDomain
            {
            Id= implementongHW.Id,
            IdUser = implementongHW.IdUser,
            IdHomeWork = implementongHW.IdHomeWork,
            IdStatusHomeWork = implementongHW.IdStatusHomeWork,
            Score = implementongHW.Score,
            };

        }



        private static StatusHomeWorkDomain ConvertStatusHWToDomain(StatusHomeWork statusHW)
        {
            return new StatusHomeWorkDomain
            {
                Id= statusHW.Id,
                Name= statusHW.Name,
                Description= statusHW.Description
            };

        }

        private static List<StatusHomeWorkDomain> ConvertStatusHWToList(List<StatusHomeWork> statusHW)
        {
            var result = new List<StatusHomeWorkDomain>();
            foreach (var statusItem in statusHW)
            {

                result.Add(ConvertStatusHWToDomain(statusItem));
            }
            return result;
        }



        public async Task<HomeWorkDomain> CreateHomeworkAsync(string Name, string? Description, string? LinkFile = null)
        {
            var newHomework = await _homeworkRepository.CreateAsync(Name, Description, LinkFile);
            return ConvertHomeWorkToDomain(newHomework);
        }


        public async Task<ImplementingHomeWorkDomain> CreateImplementingHomeworkAsync(int IdUser, int IdHomeWork, int IdStatusHomeWork, string? LinkFile = null, int? Score = null)
        {
            var newImplementingHW = await _implementingHomeWorkRepository.CreateAsync(IdUser, IdHomeWork, IdStatusHomeWork, LinkFile, Score);
            return ConvertImplementingHWToDomain(newImplementingHW);

        }

        public async Task DeleteHomeworkAsync(int id)
        {
            await _homeworkRepository.DeleteAsync(id);
        }

        public async Task DeleteImplementingHomeworkAsync(int id)
        {
            await _implementingHomeWorkRepository.DeleteImplementingHW( id);
        }

        public async Task<IReadOnlyList<HomeWorkDomain>> GetAllAsync()
        {
            var newHW = await _homeworkRepository.GetAllAsync();
            return ConvertHomeWorkToList(newHW);
           
        }

        public async Task<List<HomeWorkDomain>> GetHomeWorkByCourseAsync(int id)
        {
            //var course = await _courseRepository.GetByIdAsync(id);
            //var actualLinks = course.Lessons.AsEnumerable()
            //    .Select(x => x.LinksLessonsHomeWorks)
            //    .ToList();
            //var result = await _homeworkRepository
            //    .Select(x => {
            //        foreach (var links in actualLinks) {
            //        links.FirstOrDefault(x.)}
            //    });

            //return ConvertHomeWorkToList(course);
            throw new NotImplementedException();
        }

        public async Task<List<HomeWorkDomain>> GetHomeWorkByLessonsAsync(int id)
        {
            //var newHW = await _homeworkRepository.GetHomeWorkByLessonsAsync(id);
            //return ConvertHomeWorkToList(newHW);
            throw new NotImplementedException();

        }

        public async Task<List<ImplementingHomeWorkDomain>> GetImplementingHomeworkByHomework(int id)
        {
            var newHW = await _implementingHomeWorkRepository.GetImplementingHomeworkByHomeworkAsync(id);

            return ConvertImplementingHWToList(newHW);
        }

        public async Task<List<ImplementingHomeWorkDomain>> GetImplementingHomeworkByUser(int id)
        {
            var newHW = await _implementingHomeWorkRepository.GetImplementingHomeworkByUserAsync(id);
            return ConvertImplementingHWToList(newHW);
        }

        public async Task<List<StatusHomeWorkDomain>> GetStatusHomeWorkByHomeWork(int id)
        {
           var newStatus = await _statusHwRepository.GetStatusHomeWorkByHomeWork(id);
            return ConvertStatusHWToList(newStatus);
        }

        public async Task<List<StatusHomeWorkDomain>> GetStatusHomeWorkByUser(int IdUser)
        {
            var newStatus = await _statusHwRepository.GetStatusHomeWorkByUser(IdUser);
            return ConvertStatusHWToList(newStatus);
        }


        public async Task<HomeWorkDomain> UpdateHomeworkAsync(int id, string? Name = null, string? Description = null, string? LinkFile = null)
        {
            var newHW = await _homeworkRepository.UpdateAsync(id,Name, Description,LinkFile);
            return ConvertHomeWorkToDomain(newHW);
        }

        public async Task<StatusHomeWorkDomain> CreateStatusHomeworkAsync(string Name, string? Description)
        {
            var newStatus = await _statusHwRepository.CreateStatusHomeWorkAsync(Name, Description);
            return ConvertStatusHWToDomain(newStatus);
        }



        public async Task DeleteStatusHomeworkAsync(int id)
        {
            await _statusHwRepository.DeleteStatusHomeWork(id);
        }

        public async Task<ImplementingHomeWorkDomain> UpdateImplementingHomeworkAsync(int id, int IdUser, int IdHomeWork, int IdStatusHomeWork, string? LinkFile = null, int? Score = null)
        {
            var newImplem = await _implementingHomeWorkRepository.UpdateAsync(id,IdUser, IdHomeWork, IdStatusHomeWork, LinkFile, Score);
            return ConvertImplementingHWToDomain(newImplem);
        }

        public async Task<StatusHomeWorkDomain> UpdateStatusHomeworkAsync(int id, string? Name, string? Description)
        {
            //var updateStatus = await _statusHwRepository.UpdateStatusHomeWorkAsync(id, Name, Description);
            //return ConvertStatusHWToDomain(updateStatus);
            throw new NotImplementedException();
        }

        Task<HomeWorkDomain> IHomeWorkDomain.UpdateStatusHomeworkAsync(int id, string? Name, string? Description)
        {
            throw new NotImplementedException();
        }
    }
}
