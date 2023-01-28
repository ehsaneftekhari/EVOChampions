namespace EVOChampions.Games.GameApps.StreetFighter
{
    internal class StreetFighter : GameApp
    {
        public StreetFighter(GameAppPlayer player1, GameAppPlayer player2) : base(player1, player2, new StreetFighterCreator(), 4) { }

        public override string Name => "StreetFighter";
    }
}
