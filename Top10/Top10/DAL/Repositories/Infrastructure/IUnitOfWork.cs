namespace Top10.DAL.Repositories.Infrastructure
{
    public interface IUnitOfWork
    {
        FeedbackRepository FeedbackRepository { get; }
        QuestionRepository QuestionRepository { get; }
        StudentGradeRepository StudentGradeRepository { get; }
        StudentRepository StudentRepository { get; }
        StudentTimeRepository StudentTimeRepository { get; }
    }
}