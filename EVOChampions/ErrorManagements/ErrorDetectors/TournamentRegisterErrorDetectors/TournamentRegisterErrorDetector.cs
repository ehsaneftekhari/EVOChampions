using EVOChampions.Managers;

namespace EVOChampions.ErrorManagements.ErrorDetectors.TournamentRegisterErrorDetectors
{
    public abstract class TournamentRegisterErrorDetector : ErrorDetector
    {
        protected TournamentRegisterErrorDetector(RegisterManager registerManager) : base(registerManager)
        {
        }

        public bool Detect(string tournamentNAME, long payed)
        {
            if (tournamentNAME == null)
            {
                throw new ArgumentNullException(nameof(tournamentNAME));
            }

            if (tournamentNAME.Length == 0)
            {
                throw new Exception(nameof(tournamentNAME) + "can not be empty");
            }

            if (payed < 0)
            {
                throw new Exception(nameof(payed) + "can not be less than 0");
            }

            return DoDetection(tournamentNAME, payed);
        }

        protected abstract bool DoDetection(string tournamentNAME, long payed);
    }
}
