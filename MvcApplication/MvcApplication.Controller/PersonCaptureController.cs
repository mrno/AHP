using FryHard.MvcApplication.Controller.Interfaces;
using FryHard.MvcApplication.Domain;
using FryHard.MvcApplication.Domain.Interfaces;

namespace FryHard.MvcApplication.Controller
{
    public class PersonCaptureController : ICaptureController
    {
        public ICapture MyForm { get; set; }
        public void Save(IBaseObject saveObject)
        {
            //Do save stuff here
            if (saveObject.Save())
                MyForm.SaveComplete(saveObject);
        }

        public void Load()
        {
            //Do load stuff here
            Person p = new Person();
            MyForm.LoadComplete(p);
        }

        public PersonCaptureController(ICapture captureForm)
        {
            MyForm = captureForm;
        }
    }
}
