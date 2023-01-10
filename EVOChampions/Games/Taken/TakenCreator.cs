using EVOChampions.Managers.AccountManagements;

namespace EVOChampions.Games.Taken
{
    internal class TakenCreator : Creator
    {
        public override Taken CteateGame(User user1, User user2)
        {
            Player player1 = new Player(user1);
            Player player2 = new Player(user2);
            return new Taken(player1, player2);
        }

        public override TakenRound CteateRound(Player player1, Player player2)
        {
            Character character1 = new Character(player1);
            Character character2 = new Character(player1);
            return new TakenRound(character1, character2);
        }
    }
}
