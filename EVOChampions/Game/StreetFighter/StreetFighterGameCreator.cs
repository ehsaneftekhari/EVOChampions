using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVOChampions.Game.StreetFighter
{
    internal class StreetFighterGameCreator : GameCreator
    {
        public override StreetFighter Cteate(Player player1, Player player2)
        {
            return new StreetFighter(player1, player2);
        }
    }
}
