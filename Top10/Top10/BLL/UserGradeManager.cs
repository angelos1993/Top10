using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using Top10.BLL.Infrastructure;
using Top10.DAL.Model;
using Top10.DAL.VMs;

namespace Top10.BLL
{
    public class UserGradeManager : BaseManager
    {
        #region Properties

        #endregion

        #region Methods

        public IQueryable<UserGrade> GetTodaysUserGradesQueryable(int userId)
        {
            return UnitOfWork.UserGradeRepository.Get(userGrade =>
                userGrade.UserId == userId && SqlFunctions.DateDiff("DAY", userGrade.Date, DateTime.Now) == 0);
        }

        public List<TodaysQuestionsVm> GeTodaysQuestionsVms(int userId)
        {
            var userGradesQueryable = GetTodaysUserGradesQueryable(userId);
            var questionsQueryable = UnitOfWork.QuestionRepository.GetAll();
            return userGradesQueryable.Join(questionsQueryable, userGrade => userGrade.QuestionId,
                question => question.Id, (userGrade, question) => new TodaysQuestionsVm
                {
                    Question = question.Text,
                    Mark = question.Mark,
                    TrueAnswer = question.CorrectChoice.Trim() == "A"
                        ? question.ChoiceA
                        : question.CorrectChoice.Trim() == "B"
                            ? question.ChoiceB
                            : question.CorrectChoice.Trim() == "C"
                                ? question.ChoiceC
                                : question.CorrectChoice.Trim() == "D"
                                    ? question.ChoiceD
                                    : string.Empty,
                    UserAnswer = userGrade.Answer.Trim() == "A"
                        ? question.ChoiceA
                        : userGrade.Answer.Trim() == "B"
                            ? question.ChoiceB
                            : userGrade.Answer.Trim() == "C"
                                ? question.ChoiceC
                                : userGrade.Answer.Trim() == "D"
                                    ? question.ChoiceD
                                    : "لم يتم الإختيار"
                }).ToList();
        }

        public List<int> GetQuestionsIdsAnsweredByUser(int userId)
        {
            return UnitOfWork.UserGradeRepository.Get(userGrade => userGrade.UserId == userId)
                .Select(userGrade => userGrade.QuestionId).ToList();
        }

        public List<TopUserVm> GeTopUserVms(bool isAdmin)
        {
            var topUserVms = UnitOfWork.UserGradeRepository.GetAll().GroupBy(userGrade => userGrade.User.ArabicName)
                .Select(userGrade => new TopUserVm
                {
                    Username = userGrade.Key,
                    TotalGrades = userGrade.Sum(ug => ug.Grade)
                }).OrderByDescending(topUserVm => topUserVm.TotalGrades).ThenBy(topUserVm => topUserVm.Username);
            return isAdmin ? topUserVms.ToList() : topUserVms.Take(10).ToList();
        }

        public void AddUserAnswers(List<UserGrade> userGradesList)
        {
            userGradesList.ForEach(userGrade => UnitOfWork.UserGradeRepository.Add(userGrade));
        }

        public bool IsUserAnsweredToday(int userId)
        {
            return GetTodaysUserGradesQueryable(userId).Any();
        }

        #endregion
    }
}