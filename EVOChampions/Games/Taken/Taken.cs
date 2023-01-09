namespace EVOChampions.Games.Taken
{
    internal class Taken : Game
    {
        public Taken(Player player1, Player player2) : base(player1, player2, new TakenCreator(), 4) { }
    }
}
