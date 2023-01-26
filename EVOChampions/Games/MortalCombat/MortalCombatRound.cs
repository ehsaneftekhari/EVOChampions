namespace EVOChampions.Games.MortalCombat
{
    internal class MortalCombatRound : Round
    {
        public MortalCombatRound(RoundPlayer character1, RoundPlayer character2) : base(character1, character2) { }

        public override void Start()
        {
            Winner = RoundPlayer1;
        }
    }
}
