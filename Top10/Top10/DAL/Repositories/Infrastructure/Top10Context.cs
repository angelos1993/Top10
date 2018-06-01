using Top10.DAL.Model;

namespace Top10.DAL.Repositories.Infrastructure
{
    public class Top10Context
    {
        private static Top10Entities _instance;

        private Top10Context()
        {
        }

        public static Top10Entities Instance => _instance ?? (_instance = new Top10Entities());
    }
}