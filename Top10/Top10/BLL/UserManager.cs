using System.Collections.Generic;
using System.Linq;
using Top10.BLL.Infrastructure;
using Top10.DAL.Model;
using static Top10.Utility.PasswordUtility;

namespace Top10.BLL
{
    public class UserManager : BaseManager
    {
        #region Properties

        #endregion

        #region Methods

        public User Login(string username, string password)
        {
            return UnitOfWork.UserRepository
                .Get(user => user.EnglishName.ToLower() == username.ToLower() && user.Password == password)
                .FirstOrDefault();
        }

        public IQueryable<User> GetAllUsers()
        {
            return UnitOfWork.UserRepository.GetAll();
        }

        public User GetUserById(int userId)
        {
            return GetAllUsers().FirstOrDefault(user => user.Id == userId);
        }

        public List<KeyValuePair<int, string>> GetAllUserNames()
        {
            return GetAllUsers().Select(user => new {user.Id, user.ArabicName}).ToList()
                .Select(a => new KeyValuePair<int, string>(a.Id, a.ArabicName)).ToList();
        }

        #region Generate Passwords for all users

        public void GeneratePasswordsForAllUsers(bool isAll = false)
        {
            var allUsers = isAll
                ? GetAllUsers().ToList()
                : GetAllUsers().Where(user => user.Password == null || user.Password == string.Empty).ToList();
            foreach (var user in allUsers)
            {
                user.Password = GetRandomPassword();
                UnitOfWork.UserRepository.Update(user);
            }
        }

        #endregion

        #endregion
    }
}