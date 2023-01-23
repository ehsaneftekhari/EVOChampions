using EVOChampions.Brackets;
using EVOChampions.Games;
using EVOChampions.Managers;

namespace EVOChampions
{
    public class Tournament
    {
        Bracket bracket;
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

        public User? Podium1 => GetParent(bracket.Podium1);

        public User? Podium2 => GetParent(bracket.Podium2);

        public User? Podium3 => GetParent(bracket.Podium3);

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

        private User? GetParent(TournamentPlayer? player)
        {
            if (player == null)
                return null;
            return (User)player.Parent!;
        }
    }
}
