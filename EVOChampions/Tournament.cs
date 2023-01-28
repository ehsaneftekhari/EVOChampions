using EVOChampions.Games.GameApps.MortalCombat;
using EVOChampions.Games.GameApps.StreetFighter;
using EVOChampions.Games.GameApps.Taken;
using EVOChampions.Games;
using EVOChampions.Managers;

namespace EVOChampions
{
    internal class Tournament
    {
        GeneralManager generalManager;

        Game[] games;

        public Tournament(RegisterManager registerManager)
        {
            generalManager = new(registerManager);
            games = registerManager.games;
        }

        public void Start()
        {
            generalManager.FinishRegisteration();

            generalManager.Start();

            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            string result = "";
            foreach (Game game in games)
            {
                result += string.Format("\n{0}\n", game.ToString());
            }
            return result;
        }
    }
}
