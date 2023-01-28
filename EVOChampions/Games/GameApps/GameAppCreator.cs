using EVOChampions.Games;

namespace EVOChampions.Games.GameApps
{
    public abstract class GameAppCreator
    {
        public GameApp CteateGameFor(GamePlayer user1, GamePlayer user2)
        {
            if (user1 is null)
                throw new ArgumentNullException(nameof(user1));

            if (user1 is null)
                throw new ArgumentNullException(nameof(user2));

            return CteateGame(user1, user2);
        }
        public Round CteateRoundFor(GameAppPlayer player1, GameAppPlayer player2)
        {
            if (player1 is null)
                throw new ArgumentNullException(nameof(player1));

            if (player2 is null)
                throw new ArgumentNullException(nameof(player2));

            return CteateRound(player1, player2);
        }

        protected abstract GameApp CteateGame(GamePlayer user1, GamePlayer user2);
        protected abstract Round CteateRound(GameAppPlayer player1, GameAppPlayer player2);
    }
}
