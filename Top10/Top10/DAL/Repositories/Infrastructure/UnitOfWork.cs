namespace Top10.DAL.Repositories.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        #region IUnitOfWork Members

        private FeedbackRepository _feedbackRepository;
        private QuestionRepository _questionRepository;
        private StudentGradeRepository _studentGradeRepository;
        private StudentRepository _studentRepository;
        private StudentTimeRepository _studentTimeRepository;

        #endregion

        #region Repositries Properties

        public FeedbackRepository FeedbackRepository =>
            _feedbackRepository ?? (_feedbackRepository = new FeedbackRepository());

        public QuestionRepository QuestionRepository =>
            _questionRepository ?? (_questionRepository = new QuestionRepository());

        public StudentGradeRepository StudentGradeRepository =>
            _studentGradeRepository ?? (_studentGradeRepository = new StudentGradeRepository());

        public StudentRepository StudentRepository =>
            _studentRepository ?? (_studentRepository = new StudentRepository());

        public StudentTimeRepository StudentTimeRepository =>
            _studentTimeRepository ?? (_studentTimeRepository = new StudentTimeRepository());

        #endregion
    }
}