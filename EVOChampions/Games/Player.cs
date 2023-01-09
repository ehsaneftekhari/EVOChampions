using EVOChampions.Managers.AccountManagements;

namespace EVOChampions.Games
{
    public class Player : User
    {
        public int health { get; private set; }
        public Player(User user) : base(user)
        {
            health = 100;
        }
    }
}
