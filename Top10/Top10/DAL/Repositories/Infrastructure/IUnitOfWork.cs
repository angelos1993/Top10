namespace Top10.DAL.Repositories.Infrastructure
{
    public interface IUnitOfWork
    {
        FeedbackRepository FeedbackRepository { get; }
        QuestionRepository QuestionRepository { get; }
        UserGradeRepository UserGradeRepository { get; }
        UserRepository UserRepository { get; }
        UserTimeRepository UserTimeRepository { get; }
    }
}