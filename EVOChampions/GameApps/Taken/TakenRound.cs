namespace EVOChampions.GameApps.Taken
{
    internal class TakenRound : Round
    {
        public TakenRound(RoundPlayer character1, RoundPlayer character2) : base(character1, character2) { }

        public override void Start()
        {
            Winner = RoundPlayer1;
        }
    }
}
