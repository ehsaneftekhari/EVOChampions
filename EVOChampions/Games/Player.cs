using EVOChampions.Managers.AccountManagements;
using System.Numerics;
using System.Security.Principal;

namespace EVOChampions.Games
{
    public class Player : Account
    {
        public string UserName => ConvertToUser(Parent).UserName;

        protected Player(Player Player) : this(ConvertToUser(Player)) { }
        public Player(User user) : base(CheckNull(user)) { }

        private static User ConvertToUser(Account player)
        {
            if (player == null)
                throw new ArgumentNullException(nameof(player));

            return (User)player.Parent;
        }
    }
}
