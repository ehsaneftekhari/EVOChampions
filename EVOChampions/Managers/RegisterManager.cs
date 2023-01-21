namespace EVOChampions.Managers
{
    public class RegisterManager
    {
        int userIndex;
        int UserIdStart;

        public RegisterManager(int mountOfUsers, int UserIdStart = 1, params Tournament[] tournaments)
        {
            userIndex = -1;
            this.UserIdStart = UserIdStart;
            Users = new User[mountOfUsers];
            this.tournaments = tournaments;
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

        public User Register(UserRegisterInfo info)
        {
            try
            {
                if (CheckNationalId(info.NationalId))
                    throw new Exception(string.Format("The nationalId of persons ({0}) has registered before", nameof(info)));

                if (CheckUserName(info.UserName))
                    throw new Exception(string.Format("The username of persons ({0}) is in use", nameof(info)));

                User newUser = AddUser(info);

                return newUser;
            }
            catch { throw; }
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

                if (user.HasGame(gameName))
                {
                    result[index++] = user;
                }
            }
            return result;
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

        private bool CheckNationalId(long nationalId)
        {
            foreach (User user in Users)
            {
                if (user == null)
                    return false;

                if (user.NationalId == nationalId)
                    return true;
            }
            return false;
        }

        private bool CheckUserName(string username)
        {
            foreach (User user in Users)
            {
                if (user == null)
                    return false;

                if (user.UserName == username)
                    return true;
            }
            return false;
        }

        public void AddGamesForUser(User User, long payed, params string[] Games)
        {
            int i = 0;
            try
            {
                for (; i < Games.Length; i++)
                {
                    payed = AddGameForUser(User, Games[i], payed);
                }
            }
            catch (ArithmeticException ex)
            {
                throw ex;
            }
        }

        private long AddGameForUser(User user, string gameName, long payed)
        {
            foreach (Tournament tournament in tournaments)
            {
                if (tournament.Name == gameName && payed >= tournament.Salary)
                {
                    payed -= tournament.Salary;
                    user.AddGames(tournament.Name);
                }
            }
            return payed;
        }

        private User AddUser(UserRegisterInfo info)
        {
            if (IsFull)
                throw new StackOverflowException("no empty space for new User");

            int id = NextId;

            User newUser = new User(info, id);

            Users[++userIndex] = newUser;

            return newUser;
        }
    }
}
