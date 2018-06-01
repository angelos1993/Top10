using System.Linq;
using Top10.BLL.Infrastructure;
using Top10.DAL.Model;

namespace Top10.BLL
{
    public class StudentManager : BaseManager
    {
        #region Properties

        #endregion

        #region Methods

        public Student Login(string username, string password)
        {
            return UnitOfWork.StudentRepository
                .Get(student => student.EnglishName == username && student.Password == password).FirstOrDefault();
        }

        #endregion
    }
}