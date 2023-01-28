using EVOChampions.Managers;

namespace EVOChampions
{
    internal class GeneralManager
    {
        public RegisterManager RegisterManager { get; private set; }
        public Game[] Tournaments { get; private set; }

        public GeneralManager(params Game[] games)
        {
            Tournaments = games;
            RegisterManager = new RegisterManager(Tournaments);
        }

        public void FinishRegisteration()
        {
            foreach (Game game in Tournaments)
            {
                string Name = game.Name;
                User[] users = RegisterManager.GetUsersByTournamentName(Name);
                game.SetUsers(users);
            }
        }

        public void Start()
        {
            foreach (Game game in Tournaments)
            {
                try
                {
                    game.Start();
                }
                catch (Exception ex)
                {
                    Program.PrintError(ex.Message);
                }
            }
        }

        public override string ToString()
        {
            string result = "";
            foreach (Game game in Tournaments)
            {
                result += string.Format("\n{0}\n", game.ToString());
            }
            return result;
        }
    }
}
