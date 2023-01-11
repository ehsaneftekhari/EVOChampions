namespace EVOChampions.Games.MortalCombat
{
    internal class MortalCombat : Game
    {
        public MortalCombat(GamePlayer player1, GamePlayer player2) : base(player1, player2, new MortalCombatCreator(), 3) { }
    }
}
