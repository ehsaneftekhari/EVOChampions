﻿using EVOChampions.Managers;

namespace EVOChampions.GameApps.StreetFighter
{
    internal class StreetFighterCreator : GameAppCreator
    {
        protected override StreetFighter CteateGame(TournamentPlayer user1, TournamentPlayer user2)
        {
            GameAppPlayer player1 = new GameAppPlayer(user1);
            GameAppPlayer player2 = new GameAppPlayer(user2);
            return new StreetFighter(player1, player2);
        }

        protected override StreetFighterRound CteateRound(GameAppPlayer player1, GameAppPlayer player2)
        {
            RoundPlayer character1 = new RoundPlayer(player1);
            RoundPlayer character2 = new RoundPlayer(player1);
            return new StreetFighterRound(character1, character2);
        }
    }
}
