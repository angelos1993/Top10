using System.Collections.Generic;
using System.Linq;
using Top10.BLL.Infrastructure;
using Top10.DAL.Model;

namespace Top10.BLL
{
    public class FeedbackManager : BaseManager
    {
        #region Properties

        #endregion

        #region Methods

        public void AddFeedback(Feedback feedback)
        {
            UnitOfWork.FeedbackRepository.Add(feedback);
        }

        public List<Feedback> GetAllFeedbacks()
        {
            return UnitOfWork.FeedbackRepository.GetAll().ToList();
        }

        #endregion
    }
}