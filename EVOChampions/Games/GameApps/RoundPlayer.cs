using EVOChampions.Managers;

namespace EVOChampions.Games.GameApps
{
    public sealed class RoundPlayer : ParentChildrenKeeper
    {
        public string UserName => ((GameAppPlayer)Parent!).UserName;

        public RoundPlayer(GameAppPlayer player) : base(player) => Health = 100;

        public int Health { get; private set; }

        public override string ToString()
        {
            return string.Format("{0} Health: {1}", UserName, Health);
        }
    }
}
