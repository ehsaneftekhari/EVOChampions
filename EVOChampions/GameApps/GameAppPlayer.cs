using EVOChampions.Managers;

namespace EVOChampions.GameApps
{
    public sealed class GameAppPlayer : ParentChildrenKeeper
    {
        public string UserName => ((TournamentPlayer)Parent!).UserName;

        public GameAppPlayer(TournamentPlayer user) : base(user) { }

        public override string ToString()
        {
            return UserName;
        }
    }
}
