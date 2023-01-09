using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVOChampions.Game.StreetFighter
{
    internal class StreetFighter : Game
    {
        public StreetFighter(Player player1, Player player2) : base(player1, player2, new StreetFighterRoundCreator(), 4) { }
    }
}
