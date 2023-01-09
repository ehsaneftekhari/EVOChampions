namespace EVOChampions.Games.StreetFighter
{
    internal class StreetFighter : Game
    {
        public StreetFighter(Player player1, Player player2) : base(player1, player2, new StreetFighterCreator(), 4) { }
    }
}
