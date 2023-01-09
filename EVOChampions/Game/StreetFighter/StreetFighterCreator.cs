using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVOChampions.Game.StreetFighter
{
    internal class StreetFighterCreator : Creator
    {
        public override StreetFighter CteateGame(Player player1, Player player2)
        {
            return new StreetFighter(player1, player2);
        }

        public override StreetFighterRound CteateRound(Player player1, Player player2)
        {
            return new StreetFighterRound(player1, player2);
        }
    }
}
