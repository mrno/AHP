using System;
using System.Collections.Generic;
using FryHard.MvcApplication.Controller.Interfaces;
using FryHard.MvcApplication.Domain;
using FryHard.MvcApplication.Domain.Interfaces;

namespace FryHard.MvcApplication.Controller
{
    public class CompanyCaptureController : ICaptureController
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
            Company c = new Company() {Title = "My new company"};
            c.Employees = new List<Person>();
            c.Employees.Add(new Person(){FirstName = "Bob", LastName = "Smith", BirthDate = DateTime.Now});
            c.Employees.Add(new Person() { FirstName = "Steve", LastName = "Smith", BirthDate = DateTime.Now });
            c.Employees.Add(new Person() { FirstName = "James", LastName = "Smith", BirthDate = DateTime.Now });
            c.Employees.Add(new Person() { FirstName = "Joe", LastName = "Smith", BirthDate = DateTime.Now });
            MyForm.LoadComplete(c);
        }

        public CompanyCaptureController (ICapture captureForm)
        {
            MyForm = captureForm;
        }

        public void Refresh ()
        {
            Company c = new Company() {Title = "Refreshed company"};
            c.Employees = new List<Person>();
            c.Employees.Add(new Person(){FirstName = "Refreshed Bob", LastName = "Smith", BirthDate = DateTime.Now});
            c.Employees.Add(new Person() { FirstName = "Refreshed Steve", LastName = "Smith", BirthDate = DateTime.Now });
            c.Employees.Add(new Person() { FirstName = "Refreshed James", LastName = "Smith", BirthDate = DateTime.Now });
            c.Employees.Add(new Person() { FirstName = "Refreshed Joe", LastName = "Smith", BirthDate = DateTime.Now });

            ((ICompanyCapture)MyForm).RefreshComplete(c);
        }
    }
}
