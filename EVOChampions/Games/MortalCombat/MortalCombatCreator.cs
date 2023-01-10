using EVOChampions.Games;
using EVOChampions.Managers.AccountManagements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVOChampions.Games.MortalCombat
{
    internal class MortalCombatCreator : Creator
    {
        public override MortalCombat CteateGame(User user1, User user2)
        {
            Player player1 = new Player(user1);
            Player player2 = new Player(user2);
            return new MortalCombat(player1, player2);
        }

        public override MortalCombatRound CteateRound(Player player1, Player player2)
        {
            Character character1 = new Character(player1);
            Character character2 = new Character(player1);
            return new MortalCombatRound(character1, character2);
        }
    }
}
