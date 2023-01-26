using EVOChampions.Managers;

namespace EVOChampions.Managers.ErrorManagements.ErrorDetectors.UserRegisterErrorDetectors
{
    public sealed class NationalIdFormatError : UserRegisterErrorDetector
    {
        public NationalIdFormatError(RegisterManager registerManager) : base(registerManager)
        {
        }

        protected override string Name => "NationalIdFormatError";

        protected override bool DoDetection(User newUser)
        {
            if (newUser.UserName.Length < 10)
                return false;

            return true;
        }
    }
}
