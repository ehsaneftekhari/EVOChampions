using EVOChampions.Brackets;
using EVOChampions.Games;
using EVOChampions.Managers;
using EVOChampions.Managers.AccountManagements;

namespace EVOChampions
{
    internal class Tournament
    {
        private Bracket bracket;
        GameCreator gameCreator;
        TournamentPlayer[] players;

        public Tournament(string name, User[] registeredUsers, GameCreator gameCreator)
        {
            Name = name;
            SetUsers(registeredUsers);
            this.gameCreator = gameCreator;
        }

        public string Name { get; set; }

        public User? Podium1 => GetParent(bracket.Podium1);
        public User? Podium2 => GetParent(bracket.Podium2);
        public User? Podium3 => GetParent(bracket.Podium3);

        private User? GetParent(TournamentPlayer? player)
        {
            if (player == null)
                return null;
            return (User)player.Parent!;
        }

        public void Start()
        {
            bracket = new Bracket(players);
            TournamentDirector director = new TournamentDirector(bracket, gameCreator);
            director.start();
        }

        private void SetUsers(User[] registeredUsers)
        {
            this.players = new TournamentPlayer[registeredUsers.Length];
            for(int i = 0; i < registeredUsers.Length; i++)
            {
                players[i] = new TournamentPlayer(registeredUsers[i]);
            }
        }
    }
}
