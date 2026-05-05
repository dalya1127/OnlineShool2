

using Microsoft.EntityFrameworkCore;

using OnlineShool.Infrastructura.Sql_Server.Models;




namespace OnlineShool.Infrastructura.Sql_Server.Realization
{
    public class CommentManager : IComment
    {
        public readonly IDbContextFactory<ApplicationDbContext> _factory;
        public CommentManager(IDbContextFactory<ApplicationDbContext> factory)
        {
            _factory = factory;
        }
        public async Task<Comment> CreateCommentAsync
        (int IdUser,
        string Text,
        int IdLessons,
        DateTime Date,
        int? idAnswerComment = null)
        {
            var _context = _factory.CreateDbContext();
            Comment newComment = new Comment()
            {
                IdUser = IdUser,
                Text = Text,
                IdLessons = IdLessons,
                

            };
            await _context.Comments.AddAsync(newComment);
            await _context.SaveChangesAsync();
            return newComment;
        }



        public async Task DeleteCommentAsync(int id)
        {
            var _context = _factory.CreateDbContext();
            var removeComment = await _context.Comments.FindAsync(id);
            if (removeComment == null)
            {
                return;
            }
            _context.Remove(removeComment);
            await _context.SaveChangesAsync();
        }



        public async Task<IReadOnlyList<Comment>> GetAllCommentAsync()
        {
            var _context = _factory.CreateDbContext();
            var result = await _context.Comments.ToListAsync();
            return result;
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            var _context = _factory.CreateDbContext();
            var result = await _context.Comments
                .FindAsync(id);
            return result;
        }

        public async Task<IReadOnlyList<Comment>> GetByLessonIdAsync(int lessonId)
        {
            var _context = _factory.CreateDbContext();
            var result = await _context.Comments
                .Where(x => x.IdLessons == lessonId)
                .ToListAsync();
            return result;
        }

        public async Task<IReadOnlyList<Comment>> GetByUserIdAsync(int userId)
        {
            var _context = _factory.CreateDbContext();
            var result = await _context.Comments
                .Where(x => x.IdUser == userId)
                .ToListAsync();
            return result;
        }

        public async Task<Comment> UpdateCommentAsync(int id ,int? IdUser = null, string? Text = null, int? IdLessons = null, DateTime? Date = null, int? idAnswerComment = null)
        {


            var _context = _factory.CreateDbContext();
            var updateComment = await _context.Comments.FindAsync(id);
            if (updateComment == null)
            {
                throw new Exception("Коментарий не найден");
            }
            if (Text != null) updateComment.Text = (string)Text;
            if (IdUser != null) updateComment.IdUser = (int)IdUser;
            if (IdLessons != null) updateComment.IdLessons = (int)IdLessons;
            await _context.SaveChangesAsync();

            return updateComment;
        }


    }
}
