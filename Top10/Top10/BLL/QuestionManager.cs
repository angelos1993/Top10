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
            var questionsIds = UnitOfWork.QuestionRepository
                .Get(question => !questionsIdsAnsweredByUser.Contains(question.Id)).Select(question => question.Id);
            questionsIds.ToList().Shuffle();
            return GetQuestionsByIdList(questionsIds.Take(3).ToList());
        }

        public List<Question> GetQuestionsByIdList(List<int> questionsIds)
        {
            return UnitOfWork.QuestionRepository.Get(question => questionsIds.Contains(question.Id)).ToList();
        }

        #endregion
    }
}