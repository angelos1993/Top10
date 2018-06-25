using System.Web;

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

        #endregion
    }
}