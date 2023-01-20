using EVOChampions.Games;
using System.Diagnostics.SymbolStore;

namespace EVOChampions.Managers
{
    public sealed class User : UserRegisterInfo
    {
        char gamesSeparator;
        //protected User(User user) : base(user ,user) { }

        public User(UserRegisterInfo person, int id, long balance = 0, params string[] games) : base(person)
        {
            if (person == null)
                throw new ArgumentNullException(nameof(person));

            Id = id;
            Balance = balance;
            gamesSeparator = '$';
            AddGames(games);
        }
        string? Games { get; set; }

        public long Balance { private set; get; }

        public int Id { get; private set; }

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

        public bool HasGame(string game)
        {
            string[] games = GetGames();
            foreach (string name in games)
            {
                if (name == game) return true;
            }
            return false;
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
