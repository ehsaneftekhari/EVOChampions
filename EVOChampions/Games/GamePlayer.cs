using EVOChampions.Managers;
using System.Numerics;
using System.Security.Principal;

namespace EVOChampions.Games
{
    public sealed class GamePlayer : Account
    {
        public string UserName => ((TournamentPlayer)Parent!).UserName;

        public GamePlayer(TournamentPlayer user) : base(user) { }
    }
}
