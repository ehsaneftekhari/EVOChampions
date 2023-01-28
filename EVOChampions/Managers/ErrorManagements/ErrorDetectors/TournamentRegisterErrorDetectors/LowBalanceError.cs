using EVOChampions.Managers;

namespace EVOChampions.Managers.ErrorManagements.ErrorDetectors.TournamentRegisterErrorDetectors
{
    public sealed class LowBalanceError : TournamentRegisterErrorDetector
    {
        public LowBalanceError(RegisterManager registerManager) : base(registerManager)
        {
        }

        protected override string Name => "LowBalanceError";

        protected override bool DoDetection(string gameNAME, long payed)
        {
            long salary = registerManager.GetTournamentSalary(gameNAME);
            if (payed != salary)
                return true;

            return false;
        }
    }
}
