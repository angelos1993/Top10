namespace Top10.DAL.Repositories.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        #region IUnitOfWork Members

        private FeedbackRepository _feedbackRepository;
        private QuestionRepository _questionRepository;
        private UserGradeRepository _userGradeRepository;
        private UserRepository _userRepository;
        private UserTimeRepository _userTimeRepository;

        #endregion

        #region Repositries Properties

        public FeedbackRepository FeedbackRepository =>
            _feedbackRepository ?? (_feedbackRepository = new FeedbackRepository());

        public QuestionRepository QuestionRepository =>
            _questionRepository ?? (_questionRepository = new QuestionRepository());

        public UserGradeRepository UserGradeRepository =>
            _userGradeRepository ?? (_userGradeRepository = new UserGradeRepository());

        public UserRepository UserRepository =>
            _userRepository ?? (_userRepository = new UserRepository());

        public UserTimeRepository UserTimeRepository =>
            _userTimeRepository ?? (_userTimeRepository = new UserTimeRepository());

        #endregion
    }
}