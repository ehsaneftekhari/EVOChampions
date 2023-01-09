using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVOChampions.Manager.AccountManagement
{
    public class Person
    {
        protected Person(Person person) : this(person.NationalId, person.FirstName, person.LastName, person.ZIPCode) { }
        public Person(long NationalId, string FirstName, string LastName, int ZIPCode)
        {
            this.NationalId = NationalId;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.ZIPCode = ZIPCode;
        }

        public long NationalId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int ZIPCode { get; set; }
    }
}
