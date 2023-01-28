using EVOChampions.Managers;

namespace EVOChampions.GameApps
{
    public sealed class GamePlayer : ParentChildrenKeeper
    {
        public string UserName => ((TournamentPlayer)Parent!).UserName;

        public GamePlayer(TournamentPlayer user) : base(user) { }

        public override string ToString()
        {
            return UserName;
        }
    }
}
