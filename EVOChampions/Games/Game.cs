using EVOChampions.Brackets;
using EVOChampions.Games.GameApps;
using EVOChampions.Managers;

namespace EVOChampions.Games
{
    public class Game
    {
        GameAppCreator gameCreator;
        GamePlayer[] players;
        public Game(string name, long salary, int playersCapacity, GameAppCreator gameCreator)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            if (salary < 0)
                throw new ArgumentOutOfRangeException(nameof(salary));

            if (gameCreator == null)
                throw new ArgumentNullException(nameof(gameCreator));

            Name = name;
            Salary = salary;
            PlayersCapacity = playersCapacity;
            this.gameCreator = gameCreator;
        }

        public string Name { get; set; }

        public long Salary { get; private set; }

        public int PlayersCapacity { get; private set; }

        public Bracket Bracket { get; private set; }

        public User? Gold
        {
            get
            {
                if (Bracket is not null)
                    return GetParentOfPlayer(Bracket.Podium1);
                return null;
            }
        }

        public User? Silver
        {
            get
            {
                if (Bracket is not null)
                    return GetParentOfPlayer(Bracket.Podium2);
                return null;
            }
        }

        public User? Bronze
        {
            get
            {
                if (Bracket is not null)
                    return GetParentOfPlayer(Bracket.Podium3);
                return null;
            }
        }

        public void Start()
        {
            if (players is null || players.Length == 0)
                throw new Exception("There is no players to start the Game");

            Bracket = new Bracket(players);
            TournamentDirector director = new TournamentDirector(Bracket, gameCreator);
            director.start();
        }

        public void SetUsers(User[] registeredUsers)
        {
            players = new GamePlayer[registeredUsers.Length];
            for (int i = 0; i < registeredUsers.Length; i++)
            {
                if (i >= PlayersCapacity)
                    throw new StackOverflowException("there is no enough space to add rest of the users in " + Name + "Game");

                players[i] = new GamePlayer(registeredUsers[i]);
            }
        }

        public override string ToString()
        {
            string result = "Game:----------------------------------------\n";
            if (Gold != null)
            {
                result += string.Format("GameName: {0}\nPodiums:\n1.Gold:   {1}\n2.Silver: {2}\n3.Bronze: {3}\n", Name, Gold, Silver, Bronze);
                result += Bracket.GraphToString();
                result += string.Format("Bracket:\n{0}\n", Bracket.ToString());
            }
            result += "----------------------------------------/Game\n";
            return result;
        }

        private User? GetParentOfPlayer(GamePlayer? player)
        {
            if (player == null)
                return null;
            return (User)player.Parent!;
        }
    }
}
