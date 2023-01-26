using EVOChampions.Managers;
using EVOChampions.Managers.ErrorManagements.ErrorDetectors;
using EVOChampions.Managers.ErrorManagements.ErrorDetectors.TournamentRegisterErrorDetectors;
using EVOChampions.Managers.ErrorManagements.ErrorDetectors.UserRegisterErrorDetectors;

namespace EVOChampions.Managers.ErrorManagements
{
    public class TournamentOfficial
    {
        UserRegisterErrorDetector[] userRegisterError;
        TournamentRegisterErrorDetector[] tournamentRegisterError;

        string[] occurredErrorsMessages;
        int index;

        public TournamentOfficial(RegisterManager registerManager)
        {
            userRegisterError = new UserRegisterErrorDetector[]{
                new DuplicateNationalIdError(registerManager),
                new DuplicateUsernameError(registerManager),
                new UsernameFormatError(registerManager),

                new NationalIdFormatError(registerManager)
            };

            tournamentRegisterError = new TournamentRegisterErrorDetector[]{
                new InvalidTournamentError(registerManager),
                new LowBalanceError(registerManager)
            };

            ResetOccurredErrors();
        }

        public bool DitectRegisterError(User newUser)
        {
            bool result = false;
            foreach (UserRegisterErrorDetector errorDetector in userRegisterError)
            {
                bool tempResult = errorDetector.Detect(newUser);
                if (tempResult)
                {
                    AddToOccurredErrors(errorDetector);
                    result = true;
                }
            }
            return result;
        }

        public bool DitectTournamentRegisterError(string tournamentNAME, long payed)
        {
            bool result = false;
            foreach (TournamentRegisterErrorDetector errorDetector in tournamentRegisterError)
            {
                bool tempResult = errorDetector.Detect(tournamentNAME, payed);
                if (tempResult)
                {
                    AddToOccurredErrors(errorDetector);
                    result = true;
                }
            }
            return result;
        }

        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < index; i += 2)
            {
                result += string.Format("Error code: {0} _ Error Message: {1}\n", occurredErrorsMessages[i], occurredErrorsMessages[i + 1]);
            }
            return result;
        }

        public void PrintErrors()
        {
            ConsoleColor lastColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ToString());
            Console.ForegroundColor = lastColor;
        }

        public void ResetOccurredErrors()
        {
            occurredErrorsMessages = new string[(userRegisterError.Length + tournamentRegisterError.Length) * 2];
            index = 0;
        }

        private void AddToOccurredErrors(ErrorDetector errorDetector)
        {
            if (index >= occurredErrorsMessages.Length)
                throw new StackOverflowException();

            occurredErrorsMessages[index] = errorDetector.ErrorCode.ToString();
            occurredErrorsMessages[index + 1] = errorDetector.ErrorMessage;

            index += 2;
        }
    }
}
