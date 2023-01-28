namespace EVOChampions.Games.GameApps.Taken
{
    internal class Taken : GameApp
    {
        public Taken(GameAppPlayer player1, GameAppPlayer player2) : base(player1, player2, new TakenCreator(), 4) { }
        public override string Name => "Taken";
    }
}
