using EVOChampions.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVOChampions.Managers.AccountManagements
{
    public class TournamentUser : Account
    {
        public string UserName => ConvertToUser(Parent).UserName;

        protected TournamentUser(TournamentUser Player) : this(ConvertToUser(Player)) { }

        public TournamentUser(User user) : base(CheckNull(user)) { }

        protected static User ConvertToUser(Account tournamentUser)
        {
            if (tournamentUser == null)
                throw new ArgumentNullException(nameof(tournamentUser));

            return (User)tournamentUser.Parent;
        }
    }
}
