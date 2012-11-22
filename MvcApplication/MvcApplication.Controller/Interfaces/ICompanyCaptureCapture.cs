using FryHard.MvcApplication.Domain.Interfaces;

namespace FryHard.MvcApplication.Controller.Interfaces
{
    public interface ICompanyCapture : ICapture
    {
        void RefreshComplete(IBaseObject refreshItem);
    }
}