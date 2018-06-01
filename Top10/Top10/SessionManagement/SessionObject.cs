using Top10.DAL.Model;

namespace Top10.SessionManagement
{
    public class SessionObject
    {
        #region Constructor

        public SessionObject(User user)
        {
            UserId = user.Id;
            UserArabicName = user.ArabicName;
            UserEnglishName = user.EnglishName;
            IsAdmin = user.IsAdmin;
        }

        #endregion

        #region Properties

        public int UserId { get; set; }
        public string UserArabicName { get; set; }
        public string UserEnglishName { get; set; }
        public bool IsAdmin { get; set; }

        #endregion

        #region Methods

        #endregion
    }
}