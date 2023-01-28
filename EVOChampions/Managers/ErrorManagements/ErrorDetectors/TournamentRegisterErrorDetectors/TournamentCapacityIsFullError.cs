using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVOChampions.Managers.ErrorManagements.ErrorDetectors.GameRegisterErrorDetectors
{
    internal class GameCapacityIsFullError : GameRegisterErrorDetector
    {
        public GameCapacityIsFullError(RegisterManager registerManager) : base(registerManager)
        {
        }

        protected override string Name => "GameCapacityIsFullError";

        protected override bool DoDetection(string gameNAME, long payed)
        {
            if (registerManager.IsGameFull(gameNAME))
                return true;

            return false;
        }
    }
}
