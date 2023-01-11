namespace EVOChampions.Games
{
    public sealed class RoundPlayer : GamePlayer
    {
        public RoundPlayer(GamePlayer player) : base(player) => health = 100;
        public int health { get; private set; }
    }
}
