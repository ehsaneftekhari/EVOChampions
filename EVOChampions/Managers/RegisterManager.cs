using EVOChampions.Managers.ErrorManagements;

namespace EVOChampions.Managers
{
    public class RegisterManager
    {
        int userIndex;
        int UserIdStart;
        TournamentOfficial tournamentOfficial;
        int[] tournamentsRemainingCapacitys;

        public RegisterManager(params Tournament[] tournaments)
        {
            InitialIndexAndId(-1,1);
            InitialTournament(tournaments);
            Initialcapacities(tournaments);
            InitialTournamentOfficial(this);
        }

        private int NextUserIndex => userIndex + 1;

        private int NextId => NextUserIndex + UserIdStart;

        public bool IsFull => NextUserIndex >= Users.Length || Users.Length == 0;

        public User[] Users { get; private set; }

        public int PlayersCapacity { get; private set; }

        public Tournament[] tournaments { get; private set; }

        public User GetUserById(int Id)
        {
            if (Id - UserIdStart >= Users.Length || Id < UserIdStart)
                throw new IndexOutOfRangeException(nameof(Id) + "is out of range");

            return Users[Id - UserIdStart];
        }

        public bool IsTournamentFull(string tournamentName)
        {
            int Capacity = GetTournamentRemainingCapacity(tournamentName);
            return Capacity <= 0;
        }

        private int GetTournamentRemainingCapacity(string tournamentName)
        {
            int index = GetIndexOfTournament(tournamentName);
            return tournamentsRemainingCapacitys[index];
        }

        private void DecreaseTournamentRemainingCapacity(string tournamentName)
        {
            int index = GetIndexOfTournament(tournamentName);
            tournamentsRemainingCapacitys[index] -= 1;
        }

        public User RegisterUser(UserRegisterInfo info, out User newUser)
        {
            newUser = CreateNextUser(info);

            if (tournamentOfficial.DitectRegisterError(newUser))
            {
                throw new Exception(tournamentOfficial.ReadAndCleanErrorsMessages());
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
                tournamentOfficial.InitialOccurredErrorsArray();
                return false;
            }
            else
            {
                DecreaseTournamentRemainingCapacity(tournamentName);
                Tournament tournament = GetTournament(tournamentName);
                user.AddTournament(tournament.Name);
                return true;
            }
        }

        public User[] GetUsersByTournamentName(string gameName)
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
            int index = GetIndexOfTournament(tournamentName);
            return tournaments[index];
        }

        private int GetIndexOfTournament(string tournamentName)
        {
            for(int i = 0; i < tournaments.Length; i++)
            {
                if (tournaments[i].Name == tournamentName)
                    return i;
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

        private void InitialIndexAndId(int userIndex = -1, int UserIdStart = 1)
        {
            this.userIndex = userIndex;
            this.UserIdStart = UserIdStart;
        }

        private void Initialcapacities(Tournament[] tournaments)
        {
            var capacities = CalculateCapacities(tournaments);
            Users = new User[capacities.capacity];
            tournamentsRemainingCapacitys = capacities.tournamentsCapacitys;
        }

        private void InitialTournamentOfficial(RegisterManager registerManager) => tournamentOfficial = new TournamentOfficial(registerManager);

        private void InitialTournament(Tournament[] tournaments) => this.tournaments = tournaments;

        private (int capacity, int[] tournamentsCapacitys) CalculateCapacities(Tournament[] tournaments)
        {
            int capacity = 0;
            tournamentsRemainingCapacitys = new int[tournaments.Length];
            for (int i = 0; i < tournaments.Length; i++)
            {
                tournamentsRemainingCapacitys[i] = tournaments[i].PlayersCapacity;
                capacity += tournaments[i].PlayersCapacity;
            }
            return (capacity, tournamentsRemainingCapacitys);
        }
    }
}
