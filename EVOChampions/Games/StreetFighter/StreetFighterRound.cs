namespace EVOChampions.Games.StreetFighter
{
    internal class StreetFighterRound : Round
    {
        public StreetFighterRound(Character character1, Character character2) : base(character1, character2) { }

        public override void Start()
        {
            Winner = Character1;
        }
    }
}
