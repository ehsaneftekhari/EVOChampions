using EVOChampions.Games;

namespace EVOChampions.Managers.AccountManagements
{
    public class User : Person
    {
        char gamesSeparator;

        //protected User(User user) : base(user ,user) { }

        public User(Person person, string userName, int id, long balance = 0) : base(person)
        {
            if (person == null)
                throw new ArgumentNullException(nameof(person));

            Id = id;
            Balance = balance;
            UserName = userName;
            gamesSeparator = '$';
        }

        public int Id { get; private set; }

        public string UserName { get; private set; }

        string? Games { get; set; }

        public long Balance { private set; get; }

        public void AddGames(params string[] games)
        {
            string sprator = "";

            if (Games != null)
                sprator = "$";

            foreach (string gameName in games)
            {
                Games += string.Format("{0}{1}", sprator, gameName);
                sprator = "$";
            }
        }

        public string[] GetGames()
        {
            if (Games == null)
                return new string[0];

            string[] result = Games.Split(gamesSeparator);
            return result;
        }

        public long AddBalance(long additionalBalance)
        {
            Balance += additionalBalance;
            return Balance;
        }

        public long ReduceBalance(long ReduceingBalance)
        {
            if (ReduceingBalance > Balance)
                throw new InvalidOperationException(nameof(ReduceingBalance) + "is more than this User’s Balance");

            Balance -= ReduceingBalance;
            return Balance;
        }
    }
}
