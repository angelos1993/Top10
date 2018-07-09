using System;
using System.Data.Entity.SqlServer;
using System.Linq;
using Top10.BLL.Infrastructure;
using Top10.DAL.Model;

namespace Top10.BLL
{
    public class UserTimeManager : BaseManager
    {
        #region Properties

        #endregion

        #region Methods

        public int GetUserTodaysTime(int userId)
        {
            return UnitOfWork.UserTimeRepository.Get(userTime =>
                    userTime.UserId == userId && SqlFunctions.DateDiff("DAY", userTime.Date, DateTime.Now) == 0)
                .Select(userTime => userTime.SpentSeconds).FirstOrDefault();
        }

        public UserTime GetUserTimeForTodayByUserId(int userId)
        {
            return UnitOfWork.UserTimeRepository.Get(userTime =>
                    userTime.UserId == userId && SqlFunctions.DateDiff("DAY", userTime.Date, DateTime.Now) == 0)
                .FirstOrDefault();
        }

        public void AddUserTime(UserTime userTime)
        {
            UnitOfWork.UserTimeRepository.Add(userTime);
        }

        public void UpdateUserTime(UserTime userTime)
        {
            UnitOfWork.UserTimeRepository.Update(userTime);
        }

        #endregion
    }
}