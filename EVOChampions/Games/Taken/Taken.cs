namespace EVOChampions.Games.Taken
{
    internal class Taken : Game
    {
        public Taken(GamePlayer player1, GamePlayer player2) : base(player1, player2, new TakenCreator(), 4) { }
    }
}
