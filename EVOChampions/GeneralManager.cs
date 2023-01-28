using EVOChampions.Managers;

namespace EVOChampions
{
    internal class GeneralManager
    {
        public RegisterManager RegisterManager { get; private set; }
        public Game[] Tournaments { get; private set; }

        public GeneralManager(params Game[] tournaments)
        {
            Tournaments = tournaments;
            RegisterManager = new RegisterManager(Tournaments);
        }

        public void FinishRegisteration()
        {
            foreach (Game tournament in Tournaments)
            {
                string Name = tournament.Name;
                User[] users = RegisterManager.GetUsersByTournamentName(Name);
                tournament.SetUsers(users);
            }
        }

        public void Start()
        {
            foreach (Game tournament in Tournaments)
            {
                try
                {
                    tournament.Start();
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
            foreach (Game tournament in Tournaments)
            {
                result += string.Format("\n{0}\n", tournament.ToString());
            }
            return result;
        }
    }
}
