using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVOChampions.Game.MortalCombat
{
    internal class MortalCombatCreator : Creator
    {
        public override MortalCombat CteateGame(Player player1, Player player2)
        {
            return new MortalCombat(player1, player2);
        }

        public override MortalCombatRound CteateRound(Player player1, Player player2)
        {
            return new MortalCombatRound(player1, player2);
        }
    }
}
