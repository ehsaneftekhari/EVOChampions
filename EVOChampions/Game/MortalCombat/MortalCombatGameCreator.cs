using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVOChampions.Game.MortalCombat
{
    internal class MortalCombatGameCreator : GameCreator
    {
        public override MortalCombat Cteate(Player player1, Player player2)
        {
            return new MortalCombat(player1, player2);
        }
    }
}
