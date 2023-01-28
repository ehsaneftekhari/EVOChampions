﻿using EVOChampions.Managers;

namespace EVOChampions.GameApps.MortalCombat
{
    internal class MortalCombatCreator : GameAppCreator
    {
        protected override MortalCombat CteateGame(TournamentPlayer user1, TournamentPlayer user2)
        {
            GameAppPlayer player1 = new GameAppPlayer(user1);
            GameAppPlayer player2 = new GameAppPlayer(user2);
            return new MortalCombat(player1, player2);
        }

        protected override MortalCombatRound CteateRound(GameAppPlayer player1, GameAppPlayer player2)
        {
            RoundPlayer character1 = new RoundPlayer(player1);
            RoundPlayer character2 = new RoundPlayer(player1);
            return new MortalCombatRound(character1, character2);
        }
    }
}
