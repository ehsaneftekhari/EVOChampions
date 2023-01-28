using EVOChampions.Managers;

namespace EVOChampions.Managers.ErrorManagements.ErrorDetectors.GameRegisterErrorDetectors
{
    public sealed class InvalidGameError : GameRegisterErrorDetector
    {
        public InvalidGameError(RegisterManager registerManager) : base(registerManager)
        {
        }

        protected override string Name => "InvalidGameError";

        protected override bool DoDetection(string gameNAME, long payed)
        {
            if (!registerManager.ContainsGame(gameNAME))
                return true;
            else
                return false;

        }
    }
}
