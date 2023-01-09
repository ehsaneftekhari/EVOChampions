using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVOChampions.Game.Taken
{
    internal class TakenRound : Round
    {
        public TakenRound(Player player1, Player player2) : base(player1, player2) { }

        public override void Start()
        {
            Winner = player1;
        }
    }
}
