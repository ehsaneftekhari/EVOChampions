using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVOChampions.Game
{
    public abstract class RoundCreator
    {
        public abstract Round Cteate(Player player1, Player player2);
    }
}
