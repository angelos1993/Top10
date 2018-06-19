﻿using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using Top10.BLL.Infrastructure;

namespace Top10.BLL
{
    public class UserGradeManager : BaseManager
    {
        #region Properties

        #endregion

        #region Methods

        public bool IsUserHasAnswersToday(int userId)
        {
            return UnitOfWork.UserGradeRepository.Get(userGrade =>
                userGrade.UserId == userId && SqlFunctions.DateDiff("DAY", userGrade.Date, DateTime.Now) == 0).Any();
        }

        public List<int> GetQuestionsIdsAnsweredByUser(int userId)
        {
            return UnitOfWork.UserGradeRepository.Get(userGrade => userGrade.UserId == userId)
                .Select(userGrade => userGrade.QuestionId).ToList();
        }

        #endregion
    }
}