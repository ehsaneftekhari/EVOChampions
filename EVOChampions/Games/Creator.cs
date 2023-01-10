using EVOChampions.Managers.AccountManagements;

namespace EVOChampions.Games
{
    public abstract class Creator
    {
        public abstract Game CteateGame(User user1, User user2);
        public abstract Round CteateRound(Player player1, Player player2);
    }
}
