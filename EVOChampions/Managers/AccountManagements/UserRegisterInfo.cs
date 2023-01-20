using System.Security.Principal;

namespace EVOChampions.Managers.AccountManagements
{
    public class UserRegisterInfo : Account
    {
        protected UserRegisterInfo(UserRegisterInfo person, Account? account = null) : this(person.NationalId, person.FirstName, person.LastName, person.ZIPCode, person.UserName, account) { }
        public UserRegisterInfo(long NationalId, string FirstName, string LastName, int ZIPCode, string userName, Account? account = null) : base(account)
        {
            this.NationalId = NationalId;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.ZIPCode = ZIPCode;
            this.UserName = userName;
        }

        public long NationalId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int ZIPCode { get; set; }

        public string UserName { get; set; }
    }
}
