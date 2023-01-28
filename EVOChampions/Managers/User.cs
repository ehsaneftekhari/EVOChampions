namespace EVOChampions.Managers
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
            AddTournament(games);
        }
        string? Tournaments { get; set; }

        public int Id { get; private set; }

        public void AddTournament(params string[] games)
        {
            string sprator = "";

            if (Tournaments != null)
                sprator = "$";

            if (games != null)
                foreach (string gameName in games)
                {
                    Tournaments += string.Format("{0}{1}", sprator, gameName);
                    sprator = "$";
                }
        }

        public string[] GetTournaments()
        {
            if (Tournaments == null)
                return new string[0];

            string[] result = Tournaments.Split(gameSeparator);
            return result;
        }

        public bool HasTournament(string game)
        {
            string[] games = GetTournaments();
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
