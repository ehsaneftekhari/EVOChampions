using EVOChampions.Error;

namespace EVOChampions.Managers.AccountManagements
{
    public class User : Person
    {
        char gamesSeparator;
        MessageGenerator messageGenerator;

        protected User(User user) : this(user, user.Id, user.Balance) { }

        public User(Person person, int Id, long Balance = 0) : base(person)
        {
            messageGenerator = new MessageGenerator();

            if (person == null)
                throw new ArgumentNullException(messageGenerator.ArgumentNull("person", nameof(person)));

            this.Id = Id;
            this.Balance = Balance;
            gamesSeparator = '$';
        }

        public int Id { get; private set; }

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
