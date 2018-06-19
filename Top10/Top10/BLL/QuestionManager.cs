using System.Collections.Generic;
using System.Linq;
using Top10.BLL.Infrastructure;
using Top10.DAL.Model;
using Top10.Utility;

namespace Top10.BLL
{
    public class QuestionManager : BaseManager
    {
        #region Properties

        #endregion

        #region Methods

        public List<Question> GetQuestionsForUser(int userId, List<int> questionsIdsAnsweredByUser)
        {
            var questions = UnitOfWork.QuestionRepository
                .Get(question => !questionsIdsAnsweredByUser.Contains(question.Id)).ToList();
            var easyQuestions = questions.Where(question => question.Mark == Constants.Marks.EasyMark).ToList();
            var mediumQuestions = questions.Where(question => question.Mark == Constants.Marks.MediumMark).ToList();
            var hardQuestions = questions.Where(question => question.Mark == Constants.Marks.HardMark).ToList();
            easyQuestions.Shuffle();
            mediumQuestions.Shuffle();
            hardQuestions.Shuffle();
            return new List<Question>
            {
                easyQuestions.FirstOrDefault(),
                mediumQuestions.FirstOrDefault(),
                hardQuestions.FirstOrDefault()
            };
        }

        #endregion
    }
}