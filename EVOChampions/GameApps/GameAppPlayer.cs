using EVOChampions.Managers;

namespace EVOChampions.GameApps
{
    public sealed class GameAppPlayer : ParentChildrenKeeper
    {
        public string UserName => ((GamePlayer)Parent!).UserName;

        public GameAppPlayer(GamePlayer user) : base(user) { }

        public override string ToString()
        {
            return UserName;
        }
    }
}
