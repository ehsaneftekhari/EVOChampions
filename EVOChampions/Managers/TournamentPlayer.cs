using EVOChampions.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVOChampions.Managers
{
    public sealed class TournamentPlayer : Account
    {
        public string UserName => ((User)Parent!).UserName;

        public TournamentPlayer(User user) : base(CheckNull(user)) { }
    }
}
