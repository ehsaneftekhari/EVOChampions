using EVOChampions.Error;

namespace EVOChampions.Managers.AccountManagements
{
    internal class GameList
    {
        string[] GamesNames;
        long[] GamesPrices;
        MessageGenerator messageGenerator;

        public GameList(string[] GamesNames, long[] GamesPrices)
        {
            messageGenerator = new MessageGenerator();
            if (GamesNames.Length != GamesPrices.Length)
                throw new ArgumentException();

            this.GamesNames = GamesNames;
            this.GamesPrices = GamesPrices;
        }

        public int length => GamesNames.Length;

        public bool CheckGame(string gameName)
        {
            try
            {
                GetGamePrice(gameName);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public long GetGamePrice(string gameName)
        {
            for (int i = 0; i < GamesNames.Length; i++)
            {
                if (GamesNames[i] == gameName)
                    return GetGamePrice(i);
            }
            throw new KeyNotFoundException("the game" + gameName + "could not be found");
        }

        public long GetGamePrice(int index)
        {
            if (index < 0 || index > GamesPrices.Length)
                throw new IndexOutOfRangeException(messageGenerator.IndexOutOfRange("index", nameof(index)));

            return GamesPrices[index];
        }

        public string GetGameName(int index)
        {
            if (index < 0 || index >= GamesNames.Length)
                throw new IndexOutOfRangeException(messageGenerator.IndexOutOfRange("index", nameof(index)));

            return GamesNames[index];
        }

        public string[] GetSubList(params int[] indexes)
        {
            if (indexes == null)
                throw new ArgumentNullException(messageGenerator.ArgumentNull("indexes", nameof(indexes)));
            string[] subList = new string[indexes.Length];

            for (int i = 0; i < indexes.Length; i++)
            {
                if (indexes[i] < 0 || indexes[i] >= length)
                    throw new IndexOutOfRangeException(nameof(indexes));

                subList[i] = GetGameName(indexes[i]);
            }
            return subList;
        }
    }
}
