using EVOChampions.Managers;

namespace EVOChampions.Managers.ErrorManagements.ErrorDetectors.TournamentRegisterErrorDetectors
{
    public sealed class InvalidTournamentError : TournamentRegisterErrorDetector
    {
        public InvalidTournamentError(RegisterManager registerManager) : base(registerManager)
        {
        }

        protected override string Name => "InvalidTournamentError";

        protected override bool DoDetection(string tournamentNAME, long payed)
        {
            if (!registerManager.ContainsTournament(tournamentNAME))
                return true;
            else
                return false;

        }
    }
}
