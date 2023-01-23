using EVOChampions.Managers;

namespace EVOChampions.ErrorManagements.ErrorDetectors.UserRegisterErrorDetectors
{
    public sealed class DuplicateUsernameError : UserRegisterErrorDetector
    {
        public DuplicateUsernameError(RegisterManager registerManager) : base(registerManager)
        {
        }

        protected override string Name => "DuplicateUsernameError";

        protected override bool DoDetection(User newUser)
        {
            foreach (User user in registerManager.Users)
            {
                if (user == null)
                    return false;

                if (user.UserName == newUser.UserName)
                    return true;
            }
            return false;
        }
    }
}
