using EVOChampions.Managers;

namespace EVOChampions.Managers.ErrorManagements.ErrorDetectors.UserRegisterErrorDetectors
{
    public sealed class UsernameFormatError : UserRegisterErrorDetector
    {
        public UsernameFormatError(RegisterManager registerManager) : base(registerManager)
        {
        }

        protected override string Name => "UsernameFormatError";

        protected override bool DoDetection(User newUser)
        {
            return newUser.UserName.Contains(' ');
        }
    }
}
