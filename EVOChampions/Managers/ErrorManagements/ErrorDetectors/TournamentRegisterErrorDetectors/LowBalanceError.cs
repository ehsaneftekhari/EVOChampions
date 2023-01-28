using EVOChampions.Managers;

namespace EVOChampions.Managers.ErrorManagements.ErrorDetectors.GameRegisterErrorDetectors
{
    public sealed class LowBalanceError : GameRegisterErrorDetector
    {
        public LowBalanceError(RegisterManager registerManager) : base(registerManager)
        {
        }

        protected override string Name => "LowBalanceError";

        protected override bool DoDetection(string gameNAME, long payed)
        {
            long salary = registerManager.GetGameSalary(gameNAME);
            if (payed != salary)
                return true;

            return false;
        }
    }
}
