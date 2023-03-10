using EVOChampions.Managers;

namespace EVOChampions.Managers.ErrorManagements.ErrorDetectors
{
    public abstract class ErrorDetector
    {
        protected RegisterManager registerManager;

        protected ErrorDetector(RegisterManager registerManager)
        {
            this.registerManager = registerManager;
        }

        protected abstract string Name { get; }

        public int ErrorCode
        {
            get
            {
                try
                {
                    return ErrorsList.GetIndexByName(Name) + 2;
                }
                catch
                {
                    return 1;
                }
            }
        }

        public string ErrorMessage
        {
            get
            {
                try
                {
                    return ErrorsList.GetMessageByName(Name);
                }
                catch
                {
                    return "an Error happened!, but the Error Message did not found!";
                }
            }
        }
    }
}
