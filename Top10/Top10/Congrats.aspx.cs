using System;
using System.Web.UI;
using Top10.BLL;
using Top10.Utility;

namespace Top10
{
    public partial class Congrats : Page
    {
        private string QueryString => Request.QueryString["q"];
        private string UserIdString => QueryString.Substring(0, QueryString.IndexOf("a", StringComparison.Ordinal));

        private string DateString => QueryString.Substring(QueryString.IndexOf("a", StringComparison.Ordinal) + 1);

        private int UserId => int.TryParse(UserIdString, out int userId) ? userId : 0;

        private DateTime? Date => new DateTime(int.Parse(DateString.Substring(0, 4)),
            int.Parse(DateString.Substring(4, 2)), int.Parse(DateString.Substring(6, 2)));

        private UserManager _userManager;
        private UserManager UserManager => _userManager ?? (_userManager = new UserManager());

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                var user = UserManager.GetUserByUserId(UserId);
                var dateString = Date?.ToString("dd / MM / yyyy") ?? string.Empty;
                var x = user.IsMale == false ? "ت" : string.Empty;
                LtrTxt.Text = LtrTitle.Text =
                    $@"لقد حصل{x} {user.ArabicName} علي الدرجة النهائية في أسئلة اليوم {dateString}";
            }
            catch
            {
                Response.Redirect(Constants.Pages.Index);
            }
        }
    }
}