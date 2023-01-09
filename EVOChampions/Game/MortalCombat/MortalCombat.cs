using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVOChampions.Game.MortalCombat
{
    internal class MortalCombat : Game
    {
        public MortalCombat(Player player1, Player player2) : base(player1, player2, new MortalCombatRoundCreator(), 3) { }
    }
}
