namespace OnlineShool.Domain;
/// <summary>
/// Представляет собой комментарий в системе.
/// Содержит Абстрактные поля с настройкой доступа.
/// </summary>
public partial class CommentDomain
{
    
    /// <summary>
    /// Идентификатор комментария
    /// Задается базой данных
    /// </summary>
    public int Id { get; set; }

    public string Text { get; set; } = null!;

    public int IdUser { get; set; }

    public int IdLessons { get; set; }

    public int Date { get; set; }

    public int IdAnswerComment { get; set; }

}
