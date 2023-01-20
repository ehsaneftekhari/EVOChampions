using EVOChampions.Games;
using EVOChampions.Managers.AccountManagements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVOChampions.Games.MortalCombat
{
    internal class MortalCombatCreator : GameCreator
    {
        protected override MortalCombat CteateGame(TournamentPlayer user1, TournamentPlayer user2)
        {
            GamePlayer player1 = new GamePlayer(user1);
            GamePlayer player2 = new GamePlayer(user2);
            return new MortalCombat(player1, player2);
        }

        protected override MortalCombatRound CteateRound(GamePlayer player1, GamePlayer player2)
        {
            RoundPlayer character1 = new RoundPlayer(player1);
            RoundPlayer character2 = new RoundPlayer(player1);
            return new MortalCombatRound(character1, character2);
        }
    }
}
