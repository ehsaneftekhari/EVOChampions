namespace EVOChampions.Games.MortalCombat
{
    internal class MortalCombatRound : Round
    {
        public MortalCombatRound(Character character1, Character character2) : base(character1, character2) { }

        public override void Start()
        {
            Winner = Character1;
        }
    }
}
