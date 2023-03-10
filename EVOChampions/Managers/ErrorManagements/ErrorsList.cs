namespace EVOChampions.Managers.ErrorManagements
{
    internal static class ErrorsList
    {
        private static object[] List =
        {
        "DuplicateNationalIdError","the national Id you entered has registered before",
        "NationalIdFormatError","the national Id you entered is in the wrong format",
        "DuplicateUsernameError","the Username you entered is in use",
        "UsernameFormatError","the Username you entered is in the wrong format",
        "LowBalanceError","The Amount of your payment is more or less than value it should be",
        "InvalidGameError","the game name you entered is invalid",
        "GameCapacityIsFullError", "The capacity of game is full"
        };
        public static int GetIndexByName(string name)
        {
            for (int i = 0; i < List.Length; i += 2)
            {
                if ((string)List[i] == name)
                    return i / 2;
            }
            throw new Exception();
        }
        public static string GetMessageByName(string name)
        {
            for (int i = 0; i < List.Length; i += 2)
            {
                if ((string)List[i] == name)
                    return (string)List[i + 1];
            }
            throw new Exception();
        }
    }
}
