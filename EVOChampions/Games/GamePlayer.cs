using EVOChampions.Managers.AccountManagements;
using System.Numerics;
using System.Security.Principal;

namespace EVOChampions.Games
{
    public class GamePlayer : TournamentPlayer
    {
        protected GamePlayer(GamePlayer Player) : this(user:Player) { }
        public GamePlayer(TournamentPlayer user) : base(user) { }
    }
}
