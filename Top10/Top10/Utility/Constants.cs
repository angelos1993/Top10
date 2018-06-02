using System;

namespace Top10.Utility
{
    public static class Constants
    {
        public static DateTime StartDate = new DateTime(2018, 7, 7, 0, 0, 0);
        public static DateTime EndDate = new DateTime(2018, 7, 17, 0, 0, 0);
        public static int Timer = 90;

        #region pages

        public static class Pages
        {
            public static string Index = "Index.aspx";
            public static string Quiz = "Quiz.aspx";
            public static string TopRated = "TopRated.aspx";
            public static string Admin = "Admin.aspx";
        }

        #endregion
    }
}