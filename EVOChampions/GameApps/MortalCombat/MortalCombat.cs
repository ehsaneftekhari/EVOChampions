namespace EVOChampions.GameApps.MortalCombat
{
    internal class MortalCombat : GameApp
    {
        public MortalCombat(GameAppPlayer player1, GameAppPlayer player2) : base(player1, player2, new MortalCombatCreator(), 3) { }

        public override string Name => "MortalCombat";
    }
}
