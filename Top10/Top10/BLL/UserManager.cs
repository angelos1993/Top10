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

        public void UpdateUser(User user)
        {
            UnitOfWork.UserRepository.Update(user);
        }

        #region Generate Passwords for all users

        public void GeneratePasswordsForAllUsers(bool isAll = false)
        {
            var allUsers = isAll
                ? GetAllUsers().ToList()
                : GetAllUsers().Where(user => user.Password == null || user.Password == string.Empty).ToList();
            foreach (var user in allUsers)
            {
                user.Password = GetUniqueRandomPassword();
                UnitOfWork.UserRepository.Update(user);
            }
        }

        public bool IsPasswordExists(string password)
        {
            return UnitOfWork.UserRepository.Get(user => user.Password == password).Any();
        }

        #endregion

        #endregion
    }
}