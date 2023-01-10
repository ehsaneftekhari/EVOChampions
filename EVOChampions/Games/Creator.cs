using EVOChampions.Managers.AccountManagements;

namespace EVOChampions.Games
{
    public abstract class Creator
    {
        public abstract Game CteateGame(TournamentUser user1, TournamentUser user2);
        public abstract Round CteateRound(Player player1, Player player2);
    }
}
