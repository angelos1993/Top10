using System.Linq;
using Top10.BLL.Infrastructure;
using Top10.DAL.Model;

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
                .Get(user => user.EnglishName == username && user.Password == password).FirstOrDefault();
        }

        #endregion
    }
}