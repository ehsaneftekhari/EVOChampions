namespace EVOChampions.Managers.ErrorManagements.ErrorDetectors.UserRegisterErrorDetectors
{
    public sealed class DuplicateNationalIdError : UserRegisterErrorDetector
    {
        public DuplicateNationalIdError(RegisterManager registerManager) : base(registerManager)
        {
        }

        protected override string Name => "DuplicateNationalIdError";

        protected override bool DoDetection(User newUser)
        {
            foreach (User user in registerManager.Users)
            {
                if (user == null)
                    return false;

                if (user.NationalId == newUser.NationalId)
                    return true;
            }
            return false;
        }
    }
}
