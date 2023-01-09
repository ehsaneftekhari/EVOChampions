using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVOChampions.Game.Taken
{
    internal class TakenGameCreator : GameCreator
    {
        public override Taken Cteate(Player player1, Player player2)
        {
            return new Taken(player1, player2);
        }
    }
}
