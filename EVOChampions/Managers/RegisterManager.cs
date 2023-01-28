using EVOChampions.Managers.ErrorManagements;

namespace EVOChampions.Managers
{
    public class RegisterManager
    {
        int userIndex;
        int UserIdStart;
        TournamentOfficial gameOfficial;
        int[] gamesRemainingCapacitys;

        public RegisterManager(params Game[] games)
        {
            InitialIndexAndId(-1,1);
            InitialTournament(games);
            Initialcapacities(games);
            InitialTournamentOfficial(this);
        }

        private int NextUserIndex => userIndex + 1;

        private int NextId => NextUserIndex + UserIdStart;

        public bool IsFull => NextUserIndex >= Users.Length || Users.Length == 0;

        public User[] Users { get; private set; }

        public int PlayersCapacity { get; private set; }

        public Game[] games { get; private set; }

        public User GetUserById(int Id)
        {
            if (Id - UserIdStart >= Users.Length || Id < UserIdStart)
                throw new IndexOutOfRangeException(nameof(Id) + "is out of range");

            return Users[Id - UserIdStart];
        }

        public bool IsTournamentFull(string gameName)
        {
            int Capacity = GetTournamentRemainingCapacity(gameName);
            return Capacity <= 0;
        }

        private int GetTournamentRemainingCapacity(string gameName)
        {
            int index = GetIndexOfTournament(gameName);
            return gamesRemainingCapacitys[index];
        }

        private void DecreaseTournamentRemainingCapacity(string gameName)
        {
            int index = GetIndexOfTournament(gameName);
            gamesRemainingCapacitys[index] -= 1;
        }

        public User RegisterUser(UserRegisterInfo info, out User newUser)
        {
            newUser = CreateNextUser(info);

            if (gameOfficial.DitectRegisterError(newUser))
            {
                throw new Exception(gameOfficial.ReadAndCleanErrorsMessages());
            }
            else
            {
                AddUser(newUser);
                return newUser;
            }
        }

        public bool RegisterTournament(User user, string gameName, long payed)
        {
            if (gameOfficial.DitectTournamentRegisterError(gameName, payed))
            {
                gameOfficial.PrintErrors();
                gameOfficial.InitialOccurredErrorsArray();
                return false;
            }
            else
            {
                DecreaseTournamentRemainingCapacity(gameName);
                Game game = GetTournament(gameName);
                user.AddTournament(game.Name);
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

        internal bool ContainsTournament(string gameName)
        {
            if (gameName is null)
                throw new ArgumentNullException(nameof(gameName));

            if (gameName.Length == 0)
                throw new ArgumentException(nameof(gameName));

            foreach (Game game in games)
            {
                if (game.Name == gameName)
                    return true;
            }
            return false;
        }

        internal long GetTournamentSalary(string gameName)
        {
            if (gameName is null)
                throw new ArgumentNullException(nameof(gameName));

            if (gameName.Length == 0)
                throw new ArgumentException(nameof(gameName));

            foreach (Game game in games)
            {
                if (game.Name == gameName)
                    return game.Salary;
            }

            return 0;
        }

        internal Game GetTournament(string gameName)
        {
            int index = GetIndexOfTournament(gameName);
            return games[index];
        }

        private int GetIndexOfTournament(string gameName)
        {
            for(int i = 0; i < games.Length; i++)
            {
                if (games[i].Name == gameName)
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

        private void Initialcapacities(Game[] games)
        {
            var capacities = CalculateCapacities(games);
            Users = new User[capacities.capacity];
            gamesRemainingCapacitys = capacities.gamesCapacitys;
        }

        private void InitialTournamentOfficial(RegisterManager registerManager) => gameOfficial = new TournamentOfficial(registerManager);

        private void InitialTournament(Game[] games) => this.games = games;

        private (int capacity, int[] gamesCapacitys) CalculateCapacities(Game[] games)
        {
            int capacity = 0;
            gamesRemainingCapacitys = new int[games.Length];
            for (int i = 0; i < games.Length; i++)
            {
                gamesRemainingCapacitys[i] = games[i].PlayersCapacity;
                capacity += games[i].PlayersCapacity;
            }
            return (capacity, gamesRemainingCapacitys);
        }
    }
}
