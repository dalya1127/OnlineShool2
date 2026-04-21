using OnlineShool.Domain;
using OnlineShool.Infrastructura.Sql_Server.Models;

namespace OnlineShool.Application

{
    public class ManagerComment : ICommentDomain
    {
        IComment _commentRepository;
        public ManagerComment(IComment commentRepository)
        {
            _commentRepository = commentRepository;
        }


        private static CommentDomain ConvertToDomain(Comment comment)
        {
            return new CommentDomain
            {
                Id = comment.Id,
                Text = comment.Text,
                IdLessons = comment.IdLessons,
                Date = comment.Date,
                IdUser = comment.IdUser,
                IdAnswerComment = comment.IdAnswerComment
            };
        }


        public async Task<CommentDomain> CreateCommentAsync(
            int IdUser,
            string Text, 
            int IdLessons,
            int? idAnswerComment = null)
        {
            var newComment = await _commentRepository.CreateCommentAsync(
                IdUser,
                Text,
                IdLessons,
                DateTime.Now,
                idAnswerComment);

            return ConvertToDomain(newComment);

        }

        public async Task DeleteCommentAsync(int id)
        {
            await _commentRepository.DeleteCommentAsync(id);
        }

        public async Task<IReadOnlyList<CommentDomain>> GetAllAsync()
        {
            var comments = await _commentRepository.GetAllCommentAsync();

            return comments.Select(ConvertToDomain).ToList();
            
        }

        public async Task<CommentDomain?> GetByIdAsync(int id, CancellationToken ct)
        {
            var comment = await _commentRepository.GetByIdAsync(id, ct);

            return comment == null ? null : ConvertToDomain(comment);
        }

        public async Task<IReadOnlyList<CommentDomain>> GetByLessonIdAsync(int lessonId)
        {
            var comments = await _commentRepository.GetByLessonIdAsync(lessonId);
            return comments.Select(ConvertToDomain).ToList();
        }

        public async Task<IReadOnlyList<CommentDomain>> GetByUserIdAsync(int userId)
        {
            var comments = await _commentRepository.GetByUserIdAsync(userId);
            return comments.Select(ConvertToDomain).ToList();
        }

        public async Task<CommentDomain> UpdateCommentAsync(
            int id,
            int? IdUser = null,
            string? Text = null,
            int? IdLessons = null,
            DateTime? Date = null,
            int? idAnswerComment = null)

        {
            var updatedComment = await _commentRepository.UpdateCommentAsync(
                id,
                IdUser,
                Text,
                IdLessons,
                Date,
                idAnswerComment);
            return ConvertToDomain(updatedComment);
        }
    }
}
