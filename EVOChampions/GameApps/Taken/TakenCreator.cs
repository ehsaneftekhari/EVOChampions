using EVOChampions.Managers;

namespace EVOChampions.GameApps.Taken
{
    internal class TakenCreator : GameCreator
    {
        protected override Taken CteateGame(TournamentPlayer user1, TournamentPlayer user2)
        {
            GamePlayer player1 = new GamePlayer(user1);
            GamePlayer player2 = new GamePlayer(user2);
            return new Taken(player1, player2);
        }

        protected override TakenRound CteateRound(GamePlayer player1, GamePlayer player2)
        {
            RoundPlayer character1 = new RoundPlayer(player1);
            RoundPlayer character2 = new RoundPlayer(player2);
            return new TakenRound(character1, character2);
        }
    }
}
