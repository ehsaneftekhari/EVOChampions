using EVOChampions.Managers.AccountManagements;

namespace EVOChampions.Games.StreetFighter
{
    internal class StreetFighterCreator : Creator
    {
        public override StreetFighter CteateGame(TournamentUser user1, TournamentUser user2)
        {
            Player player1 = new Player(user1);
            Player player2 = new Player(user2);
            return new StreetFighter(player1, player2);
        }

        public override StreetFighterRound CteateRound(Player player1, Player player2)
        {
            Character character1 = new Character(player1);
            Character character2 = new Character(player1);
            return new StreetFighterRound(character1, character2);
        }
    }
}
