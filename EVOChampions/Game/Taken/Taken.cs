using EVOChampions.Game.MortalCombat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVOChampions.Game.Taken
{
    internal class Taken : Game
    {
        public Taken(Player player1, Player player2) : base(player1, player2, new TakenRoundCreator(), 4) { }
    }
}
