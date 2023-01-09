namespace EVOChampions.Games.MortalCombat
{
    internal class MortalCombatRound : Round
    {
        public MortalCombatRound(Player player1, Player player2) : base(player1, player2) { }

        public override void Start()
        {
            Winner = player1;
        }
    }
}
