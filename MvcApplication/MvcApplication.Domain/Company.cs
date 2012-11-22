using System.Collections.Generic;
using FryHard.MvcApplication.Domain.Interfaces;

namespace FryHard.MvcApplication.Domain
{
    public class Company : IBaseObject
    {
        public string Title { get; set; }
        public IList<Person> Employees { get; set; }
        
        public bool Save()
        {
            return true;
        }
    }
}
