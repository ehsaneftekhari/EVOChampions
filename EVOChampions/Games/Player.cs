using EVOChampions.Managers.AccountManagements;
using System.Numerics;
using System.Security.Principal;

namespace EVOChampions.Games
{
    public class Player : TournamentUser
    {
        protected Player(Player Player) : this(user:Player) { }
        public Player(TournamentUser user) : base(user) { }
    }
}
