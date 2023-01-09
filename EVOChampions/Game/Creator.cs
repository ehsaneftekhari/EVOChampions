using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVOChampions.Game
{
    public abstract class Creator
    {
        public abstract Game CteateGame(Player player1, Player player2);
        public abstract Round CteateRound(Player player1, Player player2);
    }
}
