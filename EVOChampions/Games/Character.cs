namespace EVOChampions.Games
{
    public sealed class Character : Player
    {
        public Character(Player player) : base(player) => health = 100;
        public int health { get; private set; }
    }
}
