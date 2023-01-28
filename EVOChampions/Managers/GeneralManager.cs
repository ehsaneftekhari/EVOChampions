using EVOChampions.Games;

namespace EVOChampions.Managers
{
    internal class GeneralManager
    {
        public RegisterManager RegisterManager { get; private set; }
        public Game[] Games { get; private set; }

        public GeneralManager(RegisterManager registerManager)
        {
            Games = registerManager.games;
            RegisterManager = registerManager;
        }

        public void FinishRegisteration() => RegisterManager.FinishRegisteration();

        public void Start()
        {
            foreach (Game game in Games)
            {
                try
                {
                    game.Start();
                }
                catch (Exception ex)
                {
                    PrintError(ex.Message);
                }
            }
        }

        private void PrintError(string ErrorMessage)
        {
            ConsoleColor lastColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ErrorMessage);
            Console.ForegroundColor = lastColor;
        }
    }
}
