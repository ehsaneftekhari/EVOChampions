namespace EVOChampions.Games
{
    public abstract class Creator
    {
        public abstract Game CteateGame(Player player1, Player player2);
        public abstract Round CteateRound(Player player1, Player player2);
    }
}
