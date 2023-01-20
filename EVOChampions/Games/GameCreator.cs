using EVOChampions.Managers.AccountManagements;
using System.Runtime.Intrinsics.X86;

namespace EVOChampions.Games
{
    public abstract class GameCreator
    {
        public Game CteateGameFor(TournamentPlayer user1, TournamentPlayer user2)
        {
            if(user1 is null)
                throw new ArgumentNullException(nameof(user1));

            if (user1 is null)
                throw new ArgumentNullException(nameof(user2));

            return CteateGame(user1, user2);
        }
        public Round CteateRoundFor(GamePlayer player1, GamePlayer player2)
        {
            if (player1 is null)
                throw new ArgumentNullException(nameof(player1));

            if (player2 is null)
                throw new ArgumentNullException(nameof(player2));

            return CteateRound(player1, player2);
        }

        protected abstract Game CteateGame(TournamentPlayer user1, TournamentPlayer user2);
        protected abstract Round CteateRound(GamePlayer player1, GamePlayer player2);
    }
}
