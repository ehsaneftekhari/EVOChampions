namespace EVOChampions.Games.Taken
{
    internal class TakenCreator : Creator
    {
        public override Taken CteateGame(Player player1, Player player2)
        {
            return new Taken(player1, player2);
        }

        public override TakenRound CteateRound(Player player1, Player player2)
        {
            return new TakenRound(player1, player2);
        }
    }
}
