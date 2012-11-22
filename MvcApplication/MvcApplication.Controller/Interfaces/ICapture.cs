using FryHard.MvcApplication.Domain.Interfaces;

namespace FryHard.MvcApplication.Controller.Interfaces
{
    public interface ICapture
    {
        IBaseObject MyData { get; set; } 
        ICaptureController MyController { get; set; }

        void SaveComplete(IBaseObject savedItem);
        void LoadComplete(IBaseObject loadItem);
    }
}