using EVOChampions.Games;
using EVOChampions.Managers;

namespace EVOChampions.Games.GameApps
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
