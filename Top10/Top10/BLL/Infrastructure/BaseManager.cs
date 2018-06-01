using Top10.DAL.Repositories.Infrastructure;

namespace Top10.BLL.Infrastructure
{
    public abstract class BaseManager
    {
        private IUnitOfWork _unitOfWork;
        public IUnitOfWork UnitOfWork => _unitOfWork ?? (_unitOfWork = new UnitOfWork());
    }
}