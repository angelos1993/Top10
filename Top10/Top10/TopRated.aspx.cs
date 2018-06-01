using System;
using System.Web.UI;

namespace Top10
{
    public partial class TopRated : Page
    {
        #region Events

        protected void Page_Load(object sender, EventArgs e)
        {
            PageLoad();
        }

        #endregion

        #region Methods

        private void PageLoad()
        {
            //todo: check if the session is null ... logout
        }

        #endregion

        #region Properties

        #endregion
    }
}