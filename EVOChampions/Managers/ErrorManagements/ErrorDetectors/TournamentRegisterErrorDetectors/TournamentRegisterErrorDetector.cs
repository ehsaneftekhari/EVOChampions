using EVOChampions.Managers;

namespace EVOChampions.Managers.ErrorManagements.ErrorDetectors.GameRegisterErrorDetectors
{
    public abstract class GameRegisterErrorDetector : ErrorDetector
    {
        protected GameRegisterErrorDetector(RegisterManager registerManager) : base(registerManager)
        {
        }

        public bool Detect(string gameName, long payed)
        {
            if (gameName == null)
            {
                throw new ArgumentNullException(nameof(gameName));
            }

            if (gameName.Length == 0)
            {
                throw new Exception(nameof(gameName) + "can not be empty");
            }

            if (payed < 0)
            {
                throw new Exception(nameof(payed) + "can not be less than 0");
            }

            return DoDetection(gameName, payed);
        }

        protected abstract bool DoDetection(string gameNAME, long payed);
    }
}
