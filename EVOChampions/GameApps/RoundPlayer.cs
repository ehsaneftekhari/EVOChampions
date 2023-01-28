using EVOChampions.Managers;

namespace EVOChampions.GameApps
{
    public sealed class RoundPlayer : ParentChildrenKeeper
    {
        public string UserName => ((GameAppPlayer)Parent!).UserName;

        public RoundPlayer(GameAppPlayer player) : base(player) => health = 100;

        public int health { get; private set; }

        public override string ToString()
        {
            return string.Format("{0} {1}", UserName, health);
        }
    }
}
