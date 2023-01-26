namespace EVOChampions.Managers
{
    public sealed class User : UserRegisterInfo
    {
        char tournamentSeparator;
        //protected User(User user) : base(user ,user) { }

        public User(UserRegisterInfo person, int id, params string[] tournaments) : base(person)
        {
            if (person == null)
                throw new ArgumentNullException(nameof(person));

            Id = id;
            tournamentSeparator = '$';
            AddTournament(tournaments);
        }
        string? Tournaments { get; set; }

        public int Id { get; private set; }

        public void AddTournament(params string[] games)
        {
            string sprator = "";

            if (Tournaments != null)
                sprator = "$";

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

            string[] result = Tournaments.Split(tournamentSeparator);
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
