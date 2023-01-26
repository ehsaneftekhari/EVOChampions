﻿using EVOChampions.Managers;

namespace EVOChampions
{
    internal class GeneralManager
    {
        public RegisterManager RegisterManager { get; private set; }
        public Tournament[] Tournaments { get; private set; }

        public GeneralManager(int mountOfUsers, params Tournament[] tournaments)
        {
            Tournaments = tournaments;

            RegisterManager = new RegisterManager(mountOfUsers, 1, Tournaments);
        }

        public void FinishRegisteration()
        {
            foreach (Tournament tournament in Tournaments)
            {
                string Name = tournament.Name;
                User[] users = RegisterManager.GetUsers(Name);
                tournament.SetUsers(users);
            }
        }

        public void Start()
        {
            foreach (Tournament tournament in Tournaments)
            {
                try
                {
                    tournament.Start();
                }
                catch (Exception e) { }
            }
        }

        public override string ToString()
        {
            string result = "";
            foreach (Tournament tournament in Tournaments)
            {
                result += string.Format("\n{0}\n", tournament.ToString());
            }
            return result;
        }
    }
}
