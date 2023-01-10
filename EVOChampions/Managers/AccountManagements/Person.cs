using System.Security.Principal;

namespace EVOChampions.Managers.AccountManagements
{
    public class Person : Account
    {
        protected Person(Person person, Account? account = null) : this(person.NationalId, person.FirstName, person.LastName, person.ZIPCode, account) { }
        public Person(long NationalId, string FirstName, string LastName, int ZIPCode, Account? account = null) : base(account)
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
