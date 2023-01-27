using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVOChampions.Managers.ErrorManagements.ErrorDetectors.TournamentRegisterErrorDetectors
{
    internal class TournamentCapacityIsFullError : TournamentRegisterErrorDetector
    {
        public TournamentCapacityIsFullError(RegisterManager registerManager) : base(registerManager)
        {
        }

        protected override string Name => "TournamentCapacityIsFullError";

        protected override bool DoDetection(string tournamentNAME, long payed)
        {
            if (registerManager.IsTournamentFull(tournamentNAME))
                return true;

            return false;
        }
    }
}
