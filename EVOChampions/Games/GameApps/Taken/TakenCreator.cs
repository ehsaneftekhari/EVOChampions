using EVOChampions.Games;

namespace EVOChampions.Games.GameApps.Taken
{
    internal class TakenCreator : GameAppCreator
    {
        protected override Taken CteateGame(GamePlayer user1, GamePlayer user2)
        {
            GameAppPlayer player1 = new GameAppPlayer(user1);
            GameAppPlayer player2 = new GameAppPlayer(user2);
            return new Taken(player1, player2);
        }

        protected override TakenRound CteateRound(GameAppPlayer player1, GameAppPlayer player2)
        {
            RoundPlayer character1 = new RoundPlayer(player1);
            RoundPlayer character2 = new RoundPlayer(player2);
            return new TakenRound(character1, character2);
        }
    }
}
