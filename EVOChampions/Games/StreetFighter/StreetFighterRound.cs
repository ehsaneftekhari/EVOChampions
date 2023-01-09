namespace EVOChampions.Games.StreetFighter
{
    internal class StreetFighterRound : Round
    {
        public StreetFighterRound(Player player1, Player player2) : base(player1, player2) { }

        public override void Start()
        {
            Winner = player1;
        }
    }
}
