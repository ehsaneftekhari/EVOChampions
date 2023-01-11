using EVOChampions.Managers.AccountManagements;

namespace EVOChampions.Games
{
    public abstract class Creator
    {
        public abstract Game CteateGame(TournamentPlayer user1, TournamentPlayer user2);
        public abstract Round CteateRound(GamePlayer player1, GamePlayer player2);
    }
}
