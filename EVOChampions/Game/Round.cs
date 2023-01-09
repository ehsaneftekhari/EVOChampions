using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVOChampions.Game
{
    public abstract class Round
    {
        public Player player1 { get; private set; }
        public Player player2 { get; private set; }

        public Round(Player player1, Player player2)
        {
            if (player1 == null) 
                throw new ArgumentNullException(nameof(player1));
            if(player2 == null)
                throw new ArgumentNullException(nameof(player2));

            this.player1 = player1;
            this.player2 = player2;
        }

        public abstract void Start();

        public Player Winner { get; protected set; }
    }
}
