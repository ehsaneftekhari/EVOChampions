using EVOChampions.Brackets;
using EVOChampions.Games;
using EVOChampions.Managers;

namespace EVOChampions
{
    public class Tournament
    {
        public Bracket bracket;
        GameCreator gameCreator;
        TournamentPlayer[] players;

        public Tournament(string name, long salary, GameCreator gameCreator)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            if (salary < 0)
                throw new ArgumentOutOfRangeException(nameof(salary));

            if (gameCreator == null)
                throw new ArgumentNullException(nameof(gameCreator));

            Name = name;
            Salary = salary;
            this.gameCreator = gameCreator;
        }

        public string Name { get; set; }

        public long Salary { get; set; }

        public User? Gold
        {
            get
            {
                if (bracket is not null)
                    return GetParent(bracket.Podium1);
                return null;
            }
        }

        public User? Silver
        {
            get
            {
                if (bracket is not null)
                    return GetParent(bracket.Podium2);
                return null;
            }
        }

        public User? Bronze
        {
            get
            {
                if (bracket is not null)
                    return GetParent(bracket.Podium3);
                return null;
            }
        }

        public void Start()
        {
            if (players is null || players.Length == 0)
                throw new Exception("There is no players to start the Tournament");

            bracket = new Bracket(players);
            TournamentDirector director = new TournamentDirector(bracket, gameCreator);
            director.start();
        }

        public void SetUsers(User[] registeredUsers)
        {
            this.players = new TournamentPlayer[registeredUsers.Length];
            for (int i = 0; i < registeredUsers.Length; i++)
            {
                players[i] = new TournamentPlayer(registeredUsers[i]);
            }
        }

        public override string ToString()
        {
            string result = "Tournament:----------------------------------\n";
            if (Gold != null)
            {
                result += string.Format("TournamentName: {0}\nPodiums:\n1.Gold: {1}\n2.Silver: {2}\n3.Bronze: {3}\n", Name, Gold, Silver, Bronze);
                result += string.Format("Bracket:\n{0}\n", bracket.ToString());
            }
            result += "----------------------------------/Tournament\n";
            return result;
        }

        private User? GetParent(TournamentPlayer? player)
        {
            if (player == null)
                return null;
            return (User)player.Parent!;
        }
    }
}
