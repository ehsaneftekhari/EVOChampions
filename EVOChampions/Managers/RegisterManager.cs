using EVOChampions.Managers.ErrorManagements;

namespace EVOChampions.Managers
{
    public class RegisterManager
    {
        int userIndex;
        int UserIdStart;
        GameOfficial gameOfficial;
        int[] gamesRemainingCapacitys;

        public RegisterManager(params Game[] games)
        {
            InitialIndexAndId(-1,1);
            InitialGame(games);
            Initialcapacities(games);
            InitialGameOfficial(this);
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

        public bool IsGameFull(string gameName)
        {
            int Capacity = GetGameRemainingCapacity(gameName);
            return Capacity <= 0;
        }

        private int GetGameRemainingCapacity(string gameName)
        {
            int index = GetIndexOfGame(gameName);
            return gamesRemainingCapacitys[index];
        }

        private void DecreaseGameRemainingCapacity(string gameName)
        {
            int index = GetIndexOfGame(gameName);
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

        public bool RegisterGame(User user, string gameName, long payed)
        {
            if (gameOfficial.DitectGameRegisterError(gameName, payed))
            {
                gameOfficial.PrintErrors();
                gameOfficial.InitialOccurredErrorsArray();
                return false;
            }
            else
            {
                DecreaseGameRemainingCapacity(gameName);
                Game game = GetGame(gameName);
                user.AddGame(game.Name);
                return true;
            }
        }

        public User[] GetUsersByGameName(string gameName)
        {
            int count = CountUsers(gameName);
            User[] result = new User[count];
            int index = 0;
            foreach (User user in Users)
            {
                if (user is null)
                    break;

                if (user.HasGame(gameName))
                {
                    result[index++] = user;
                }
            }
            return result;
        }

        internal bool ContainsGame(string gameName)
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

        internal long GetGameSalary(string gameName)
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

        internal Game GetGame(string gameName)
        {
            int index = GetIndexOfGame(gameName);
            return games[index];
        }

        private int GetIndexOfGame(string gameName)
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

                if (user.HasGame(gameName))
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

        private void InitialGameOfficial(RegisterManager registerManager) => gameOfficial = new GameOfficial(registerManager);

        private void InitialGame(Game[] games) => this.games = games;

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
