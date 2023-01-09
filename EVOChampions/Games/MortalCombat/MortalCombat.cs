namespace EVOChampions.Games.MortalCombat
{
    internal class MortalCombat : Game
    {
        public MortalCombat(Player player1, Player player2) : base(player1, player2, new MortalCombatCreator(), 3) { }
    }
}
