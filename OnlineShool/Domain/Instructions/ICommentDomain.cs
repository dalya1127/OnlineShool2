



namespace OnlineShool.Domain;
public interface ICommentDomain
{
    /// <summary>
    /// Получение комментария по его идентификатору
    /// </summary>
    /// <param name="id">Уникальный идентификатор комментария</param>
    /// <param name="ct">Токен Отмены</param>
    /// <returns>Возращается объект <see cref="CommentDomain"/></returns>
    /// <exception>Такого идентификатора не существует</exception>
    Task<CommentDomain?> GetByIdAsync(int id);
    Task<IReadOnlyList<CommentDomain>> GetAllAsync();
    Task<IReadOnlyList<CommentDomain>> GetByLessonIdAsync(int lessonId);
    Task<IReadOnlyList<CommentDomain>> GetByUserIdAsync(int userId);


    

    Task<CommentDomain> CreateCommentAsync(
        int IdUser,
        string Text,
        int IdLessons,
        int? idAnswerComment = null
        );

    Task <CommentDomain>UpdateCommentAsync(
        int id, 
        int? IdUser = null,
        string? Text = null,
        int? IdLessons = null,
        DateTime? Date = null,
        int? idAnswerComment = null
        ) ;

    Task DeleteCommentAsync(int id);
}
