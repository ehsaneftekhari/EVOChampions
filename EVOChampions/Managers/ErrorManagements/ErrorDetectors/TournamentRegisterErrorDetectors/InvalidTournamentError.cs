using EVOChampions.Managers;

namespace EVOChampions.Managers.ErrorManagements.ErrorDetectors.TournamentRegisterErrorDetectors
{
    public sealed class InvalidTournamentError : TournamentRegisterErrorDetector
    {
        public InvalidTournamentError(RegisterManager registerManager) : base(registerManager)
        {
        }

        protected override string Name => "InvalidTournamentError";

        protected override bool DoDetection(string gameNAME, long payed)
        {
            if (!registerManager.ContainsTournament(gameNAME))
                return true;
            else
                return false;

        }
    }
}
