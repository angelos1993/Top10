using System.Web;
using Top10.BLL;

namespace Top10.SessionManagement
{
    public class SessionManager
    {
        #region Properties

        private const string Key = "UserSession";

        public SessionObject CurrentSessionObject
        {
            get => HttpContext.Current.Session[Key] as SessionObject;
            set => HttpContext.Current.Session[Key] = value;
        }

        public int CurrentUserId
        {
            set => CurrentSessionObject = new SessionObject(UserManager.GetUserById(value));
        }

        private UserManager _userManager;
        private UserManager UserManager => _userManager ?? (_userManager = new UserManager());

        #endregion
    }
}