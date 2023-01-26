using EVOChampions.Managers;

namespace EVOChampions.Games
{
    public sealed class RoundPlayer : Account
    {
        public string UserName => ((GamePlayer)Parent!).UserName;

        public RoundPlayer(GamePlayer player) : base(player) => health = 100;

        public int health { get; private set; }

        public override string ToString()
        {
            return string.Format("{0} {1}", UserName, health);
        }
    }
}
