using OnlineShool.Infrastructura.Sql_Server.Models;
public interface IComment
{
    Task<Comment?> GetByIdAsync(int id, CancellationToken ct);
    Task<IReadOnlyList<Comment>> GetAllCommentAsync();
    Task<IReadOnlyList<Comment>> GetByLessonIdAsync(int lessonId);
    Task<IReadOnlyList<Comment>> GetByUserIdAsync(int userId);

    Task<Comment> CreateCommentAsync(
        int IdUser,
        string Text,
        int IdLessons,
        DateTime Date, 
        int? idAnswerComment = null
        );

    Task <Comment>UpdateCommentAsync(
        int id , 
        int? IdUser = null,
        string? Text = null,
        int? IdLessons = null,
        DateTime? Date = null,
        int? idAnswerComment = null
        ) ;

    Task DeleteCommentAsync(int id);
}
