namespace EVOChampions.Games.Taken
{
    internal class TakenRound : Round
    {
        public TakenRound(Player player1, Player player2) : base(player1, player2) { }

        public override void Start()
        {
            Winner = player1;
        }
    }
}
