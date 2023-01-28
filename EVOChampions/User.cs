using EVOChampions.Managers;

namespace EVOChampions
{
    public sealed class User : UserRegisterInfo
    {
        char gameSeparator;
        //protected User(User user) : base(user ,user) { }

        public User(UserRegisterInfo person, int id, params string[] games) : base(person)
        {
            if (person == null)
                throw new ArgumentNullException(nameof(person));

            Id = id;
            gameSeparator = '$';
            AddGame(games);
        }
        string? Games { get; set; }

        public int Id { get; private set; }

        public void AddGame(params string[] games)
        {
            string sprator = "";

            if (Games != null)
                sprator = "$";

            if (games != null)
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

            string[] result = Games.Split(gameSeparator);
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

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
