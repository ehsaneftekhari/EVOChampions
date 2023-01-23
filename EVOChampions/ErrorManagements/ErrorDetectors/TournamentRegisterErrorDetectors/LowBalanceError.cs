using EVOChampions.Managers;

namespace EVOChampions.ErrorManagements.ErrorDetectors.TournamentRegisterErrorDetectors
{
    public sealed class LowBalanceError : TournamentRegisterErrorDetector
    {
        public LowBalanceError(RegisterManager registerManager) : base(registerManager)
        {
        }

        protected override string Name => "LowBalanceError";

        protected override bool DoDetection(string tournamentNAME, long payed)
        {
            long salary = registerManager.GetTournamentSalary(tournamentNAME);
            if(payed != salary)
                return true;

            return false;
        }
    }
}
