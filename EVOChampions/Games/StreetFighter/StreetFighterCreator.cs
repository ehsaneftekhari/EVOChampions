using EVOChampions.Managers;

namespace EVOChampions.Games.StreetFighter
{
    internal class StreetFighterCreator : GameCreator
    {
        protected override StreetFighter CteateGame(TournamentPlayer user1, TournamentPlayer user2)
        {
            GamePlayer player1 = new GamePlayer(user1);
            GamePlayer player2 = new GamePlayer(user2);
            return new StreetFighter(player1, player2);
        }

        protected override StreetFighterRound CteateRound(GamePlayer player1, GamePlayer player2)
        {
            RoundPlayer character1 = new RoundPlayer(player1);
            RoundPlayer character2 = new RoundPlayer(player1);
            return new StreetFighterRound(character1, character2);
        }
    }
}
