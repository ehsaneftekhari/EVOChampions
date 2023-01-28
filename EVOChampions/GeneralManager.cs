using EVOChampions.Managers;

namespace EVOChampions
{
    internal class GeneralManager
    {
        public RegisterManager RegisterManager { get; private set; }
        public Game[] Games { get; private set; }

        public GeneralManager(params Game[] games)
        {
            Games = games;
            RegisterManager = new RegisterManager(Games);
        }

        public void FinishRegisteration()
        {
            foreach (Game game in Games)
            {
                string Name = game.Name;
                User[] users = RegisterManager.GetUsersByGameName(Name);
                game.SetUsers(users);
            }
        }

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
                    Program.PrintError(ex.Message);
                }
            }
        }

        public override string ToString()
        {
            string result = "";
            foreach (Game game in Games)
            {
                result += string.Format("\n{0}\n", game.ToString());
            }
            return result;
        }
    }
}
