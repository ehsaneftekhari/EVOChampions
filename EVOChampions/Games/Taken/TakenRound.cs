namespace EVOChampions.Games.Taken
{
    internal class TakenRound : Round
    {
        public TakenRound(Character character1, Character character2) : base(character1, character2) { }

        public override void Start()
        {
            Winner = Character1;
        }
    }
}
