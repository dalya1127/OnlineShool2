using OnlineShool.Domain;
using OnlineShool.Infrastructura.Instructions;
using OnlineShool.Infrastructura.Sql_Server.Models;


namespace OnlineShool.Application
{
    public class ManagerLesson : ILessonDomain
    {

        ILessonRepository _lessonDomain;
        IImplementingLesson _implementingDomain;
        ILinksLessonsHomeWork _linksLessonsHomeWork;
        IStatusLesson _statusLesson;
        public ManagerLesson(ILessonRepository lessonRepository, IImplementingLesson implementingLessonRep, IStatusLesson statusLesson, ILinksLessonsHomeWork linksLessonsHomeWork)
        {
            _lessonDomain = lessonRepository;
            _implementingDomain = implementingLessonRep;
            _statusLesson = statusLesson;
            _linksLessonsHomeWork = linksLessonsHomeWork;
        }

        private static LessonDomain ConvertLessonToDomain(Lesson lesson)
        {
            return new LessonDomain
            {
                Id = lesson.Id,
                Name = lesson.Name,
                IdCourses = lesson.IdCourses,
                Description = lesson.Description,
                LinkFile = lesson.LinkFile,
                LinkPic = lesson.LinkPic,
                NumberLessons = lesson.NumberLessons
            };
        }


        private static ImplementingLessonDomain ConvertImplemLesToDomain(ImplementingLesson implementingLesson)
        {
            return new ImplementingLessonDomain
            {
                Id = implementingLesson.Id,
                Description = implementingLesson.Description,
                IdLessons = implementingLesson.IdLessons,
                IdStatusLessons = implementingLesson.IdStatusLessons,
                IdUsers = implementingLesson.IdUsers

            };
        }

        private static LinksLessonsHomeWorkDomain ConvertLinksToDomain(LinksLessonsHomeWork linksLessonHomework)
        {
            return new LinksLessonsHomeWorkDomain
            {
                Id = linksLessonHomework.Id,
                IdHomework = linksLessonHomework.IdHomework,
                IdLessons = linksLessonHomework.IdLessons

            };
        }

        private static StatusLessonDomain ConvertStatusToDomain(StatusLesson statusLesson)
        {
            return new StatusLessonDomain
            {
                Id = statusLesson.Id,
                Description = statusLesson.Description,
                Name = statusLesson.Name
            };
        }

        private static List<LessonDomain> ConvertLessonToList(List<Lesson> lesson)
        {
            var result = new List<LessonDomain>();
            foreach (var lessonItem in lesson)
            {
                result.Add(ConvertLessonToDomain(lessonItem));
            }
            return result;


        }

        private static List<ImplementingLessonDomain> ConvertImplemLessonToList(List<ImplementingLesson> implemLesson)
        {
            var result = new List<ImplementingLessonDomain>();
            foreach (var implemItem in implemLesson)
            {
                result.Add(ConvertImplemLesToDomain(implemItem));
            }
            return result;


        }


        private static List<LinksLessonsHomeWorkDomain> ConvertLinkToList(List<LinksLessonsHomeWork> link)
        {
            var result = new List<LinksLessonsHomeWorkDomain>();
            foreach (var linkItem in link)
            {
                result.Add(ConvertLinksToDomain(linkItem));
            }
            return result;


        }


        private static List<StatusLessonDomain> ConvertStatusToList(List<StatusLesson> status)
        {
            var result = new List<StatusLessonDomain>();
            foreach (var statusItem in status)
            {
                result.Add(ConvertStatusToDomain(statusItem));
            }
            return result;


        }

        private static IReadOnlyList<LessonDomain> ConvertLessonToList(IReadOnlyList<Lesson> lesson)
        {
            var result = new List<LessonDomain>();
            foreach (var lessonItem in lesson)
            {
                result.Add(ConvertLessonToDomain(lessonItem));
            }
            return result;


        }

        public async Task<ImplementingLessonDomain> CreateImplementingLessonAsync(int IdUser, int IdLessons, int IdStatusLessons, string? Description = null)
        {
            var newImplem = await _implementingDomain.CreateImplementingLessonAsync(IdStatusLessons, IdUser, IdLessons, Description);
            return ConvertImplemLesToDomain(newImplem);
        }

        public async Task<LessonDomain> CreateLessonAsync(int IdCourses, string Name, int NumberLessons, string? LinkFile = null, string? LinkPic = null, string? Description = null)
        {
            var newLesson = await _lessonDomain.CreateLessonAsync(IdCourses, Name, NumberLessons, LinkFile, LinkPic, Description);
            return ConvertLessonToDomain(newLesson);
        }

        public async Task<LinksLessonsHomeWorkDomain> CreateLinksLessonsHomeWorkAsync(int IdHomework, int IdLessons)
        {
            var newLink = await _linksLessonsHomeWork.CreateLinksLessonsHomeWorkAsync(IdHomework, IdLessons);
            return ConvertLinksToDomain(newLink);
        }

        public async Task<StatusLessonDomain> CreateStatusLessonsAsync(string Name, string? Description)
        {
            var newStatus = await _statusLesson.CreateStatusLessonsAsync(Name, Description);
            return ConvertStatusToDomain(newStatus);
        }

        public async Task DeleteImplementingLessonAsync(int id)
        {
            await _implementingDomain.DeleteImplementingLesson(id);
        }

        public async Task DeleteLessonAsync(int id)
        {
            await _lessonDomain.DeleteLessonAsync(id);
        }

        public async Task DeleteLinksLessonsHomeWorkAsync(int id)
        {
            await _linksLessonsHomeWork.DeleteLinksLessonsHomeWorkAsync(id);
        }

        public async Task DeleteStatusLessonsAsync(int id)
        {
            await _statusLesson.DeleteStatusLessons(id);
        }

        public async Task<IReadOnlyList<LessonDomain>> GetAllAsync()
        {
            var newLessons = await _lessonDomain.GetAllAsync();
            return ConvertLessonToList(newLessons);
        }

        public async Task<IReadOnlyList<LessonDomain>> GetByCourseIdAsync(int courseId)
        {
            var newLessons = await _lessonDomain.GetByCourseIdAsync(courseId);
            return ConvertLessonToList(newLessons);
        }

        public async Task<LessonDomain?> GetByIdAsync(int id)
        {
            var newLesson = await _lessonDomain.GetByIdAsync(id);
            return ConvertLessonToDomain(newLesson);
        }

        public async Task<List<ImplementingLessonDomain>> GetImplementingLessonByLessons(int id)
        {
            var newImplems = await _implementingDomain.GetImplementingLessonByLessons(id);
            return ConvertImplemLessonToList(newImplems);
        }

        public async Task<List<ImplementingLessonDomain>> GetImplementingLessonByUser(int id)
        {
            var newImplems = await _implementingDomain.GetImplementingLessonByUser(id);
            return ConvertImplemLessonToList(newImplems);
        }

        public async Task<List<LinksLessonsHomeWorkDomain>> GetLinksLessonsHomeWorkByHomeWork(int id)
        {
            var newLinks = await _linksLessonsHomeWork.GetLinksLessonsHomeWorkByHomeWork(id);
            return ConvertLinkToList(newLinks);
        }

        public async Task<List<LinksLessonsHomeWorkDomain>> GetLinksLessonsHomeWorkByLesson(int id)
        {
            var newLinks = await _linksLessonsHomeWork.GetLinksLessonsHomeWorkByLesson(id);
            return ConvertLinkToList(newLinks);
        }

        public async Task<List<StatusLessonDomain>> GetStatusLessonsByLessons(int id)
        {
            var newStatus = await _statusLesson.GetStatusLessonsByLessons(id);
            return ConvertStatusToList(newStatus);
        }

        public async Task<List<StatusLessonDomain>> GetStatusLessonsByUser(int id)
        {
            var newStatus = await _statusLesson.GetStatusLessonsByUser(id);
            return ConvertStatusToList(newStatus);
        }



        public async Task<ImplementingLessonDomain> UpdateImplementingLessonAsync(int id, int? IdUser = null, int? IdLessons = null, int? IdStatusLessons = null, string? Description = null)
        {
            var newImplem = await _implementingDomain.UpdateImplementingLessonAsync(IdUser, IdLessons, IdStatusLessons);
            return ConvertImplemLesToDomain(newImplem);
        }

        public async Task<LinksLessonsHomeWorkDomain> UpdateLinksLessonsHomeWorkAsync(int id, int? IdHomework = null, int? IdLessons = null)
        {
            var newLinks = await _linksLessonsHomeWork.UpdateLinksLessonsHomeWorkAsync(id,IdHomework, IdLessons);
            return ConvertLinksToDomain(newLinks);
        }

        public async Task<StatusLessonDomain> UpdateStatusLessonsAsync(int id, string? Name = null, string? Description = null)
        {
            var newStatus = await _statusLesson.UpdateStatusLessonsAsync(id,Name, Description);
            return ConvertStatusToDomain(newStatus);
        }

        public async Task<LessonDomain> UpdateLessonAsync(int id, int? IdCourses = null, string? Name = null, int? NumberLessons = null, string? LinkFile = null, string? LinkPic = null, string? Description = null)
        {
            var newLesson = await _lessonDomain.UpdateLessonAsync(id, IdCourses, Name, NumberLessons, LinkFile, LinkPic, Description);
            return ConvertLessonToDomain(newLesson);
        }
    }
}
