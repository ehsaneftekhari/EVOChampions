using System.Security.Principal;

namespace EVOChampions.Managers
{
    public class UserRegisterInfo : ParentChildrenKeeper
    {
        protected UserRegisterInfo(UserRegisterInfo person, ParentChildrenKeeper? account = null) : this(person.NationalId, person.FirstName, person.LastName, person.ZIPCode, person.UserName, account) { }
        public UserRegisterInfo(long NationalId, string FirstName, string LastName, int ZIPCode, string userName, ParentChildrenKeeper? account = null) : base(account)
        {
            this.NationalId = NationalId;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.ZIPCode = ZIPCode;
            UserName = userName;
        }

        public long NationalId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int ZIPCode { get; set; }

        public string UserName { get; set; }

        public override string ToString()
        {
            return string.Format("Firstname: {0}\tLastname: {1}\tUsername: {2}", FirstName, LastName, UserName);
        }
    }
}
