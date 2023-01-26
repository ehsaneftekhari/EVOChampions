using EVOChampions.Managers.ErrorManagements;

namespace EVOChampions.Managers
{
    public class RegisterManager
    {
        int userIndex;
        int UserIdStart;
        TournamentOfficial tournamentOfficial;

        public RegisterManager(int mountOfUsers, params Tournament[] tournaments)
        {
            userIndex = -1;
            UserIdStart = 1;
            Users = new User[mountOfUsers];
            this.tournaments = tournaments;
            tournamentOfficial = new TournamentOfficial(this);
        }

        private int NextUserIndex => userIndex + 1;

        private int NextId => NextUserIndex + UserIdStart;

        public bool IsFull => NextUserIndex >= Users.Length || Users.Length == 0;

        public User[] Users { get; private set; }

        public Tournament[] tournaments { get; private set; }

        public User GetUserById(int Id)
        {
            if (Id - UserIdStart >= Users.Length || Id < UserIdStart)
                throw new IndexOutOfRangeException(nameof(Id) + "is out of range");

            return Users[Id - UserIdStart];
        }

        public User RegisterUser(UserRegisterInfo info, out User newUser)
        {
            newUser = CreateNextUser(info);

            if (tournamentOfficial.DitectRegisterError(newUser))
            {
                tournamentOfficial.ResetOccurredErrors();
                throw new Exception(tournamentOfficial.ToString());
            }
            else
            {
                AddUser(newUser);
                return newUser;
            }
        }

        public bool RegisterTournament(User user, string tournamentName, long payed)
        {
            if (tournamentOfficial.DitectTournamentRegisterError(tournamentName, payed))
            {
                tournamentOfficial.PrintErrors();
                tournamentOfficial.ResetOccurredErrors();
                return false;
            }
            else
            {
                Tournament tournament = GetTournament(tournamentName);
                user.AddTournament(tournament.Name);
                return true;
            }
        }

        public User[] GetUsers(string gameName)
        {
            int count = CountUsers(gameName);
            User[] result = new User[count];
            int index = 0;
            foreach (User user in Users)
            {
                if (user is null)
                    break;

                if (user.HasTournament(gameName))
                {
                    result[index++] = user;
                }
            }
            return result;
        }

        internal bool ContainsTournament(string tournamentName)
        {
            if (tournamentName is null)
                throw new ArgumentNullException(nameof(tournamentName));

            if (tournamentName.Length == 0)
                throw new ArgumentException(nameof(tournamentName));

            foreach (Tournament tournament in tournaments)
            {
                if (tournament.Name == tournamentName)
                    return true;
            }
            return false;
        }

        internal long GetTournamentSalary(string tournamentName)
        {
            if (tournamentName is null)
                throw new ArgumentNullException(nameof(tournamentName));

            if (tournamentName.Length == 0)
                throw new ArgumentException(nameof(tournamentName));

            foreach (Tournament tournament in tournaments)
            {
                if (tournament.Name == tournamentName)
                    return tournament.Salary;
            }

            return 0;
        }

        internal Tournament GetTournament(string tournamentName)
        {
            foreach (Tournament tournament in tournaments)
            {
                if (tournament.Name == tournamentName)
                    return tournament;
            }
            throw new Exception();
        }

        private int CountUsers(string gameName)
        {
            int count = 0;
            foreach (User user in Users)
            {
                if (user is null)
                    break;

                if (user.HasTournament(gameName))
                    count++;
            }
            return count;
        }

        private void AddUser(User user)
        {
            if (IsFull)
                throw new StackOverflowException("no empty space for new User");

            Users[++userIndex] = user;
        }

        private User CreateNextUser(UserRegisterInfo info)
        {
            int id = NextId;

            User newUser = new User(info, id);

            return newUser;
        }
    }
}
