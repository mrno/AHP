using System;
using FryHard.MvcApplication.Domain.Interfaces;

namespace FryHard.MvcApplication.Domain
{
    public class Person : IBaseObject
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public bool Save()
        {
            return true;
        }
    }
}
