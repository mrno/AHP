using FryHard.MvcApplication.Domain.Interfaces;

namespace FryHard.MvcApplication.Controller.Interfaces
{
    public interface ICaptureController
    {
        ICapture MyForm { get; set; }
        
        void Save(IBaseObject saveObject);
        void Load();
    }
}