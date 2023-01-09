using EVOChampions.Error;

namespace EVOChampions.Managers.AccountManagements
{
    internal class RegisterManager
    {
        int userIndex;
        int UserIdStart;
        protected User[] Users;
        GameList gameList;
        MessageGenerator messageGenerator;

        public RegisterManager(int mountOfUsers, GameList gameList, int UserIdStart = 1)
        {
            messageGenerator = new MessageGenerator();
            userIndex = -1;
            this.UserIdStart = UserIdStart;
            Users = new User[mountOfUsers];
            this.gameList = gameList;
        }

        public bool IsFull => NextUserIndex >= Users.Length || Users.Length == 0;

        private int NextUserIndex => userIndex + 1;

        private int NextId => NextUserIndex + UserIdStart;

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

        private int AddGamesForUser(User User, params string[] Games)
        {
            for (int i = 0; i < Games.Length; i++)
            {
                try
                {
                    AddGameForUser(User, Games[i]);
                }
                catch (ArithmeticException ex)
                {
                    return Games.Length - i;
                }
                catch
                {
                    return Games.Length - i;
                }
            }
            return 0;
        }

        private bool AddGameForUser(User users, string gameName)
        {
            if (users == null)
                throw new ArgumentNullException(messageGenerator.ArgumentNull("users", nameof(users)));

            if (gameName == null)
                throw new ArgumentNullException(messageGenerator.ArgumentNull("gameName", nameof(gameName)));

            try
            {
                long gamePrice = gameList.GetGamePrice(gameName);
                users.ReduceBalance(gamePrice);
                users.AddGames(gameName);
                return true;
            }
            catch (KeyNotFoundException ex)
            {
                //throw new ArgumentOutOfRangeException("the game" + gameName + "is not valid game", ex);
                throw ex;
            }
            catch (InvalidOperationException ex)
            {
                throw new ArithmeticException("the mount of balance is lower than the games price", ex);
            }
        }

        private User AddUser(Person persons, long Balance)
        {
            if (IsFull)
                throw new StackOverflowException("no empty space for new User");

            if (CheckNationalId(persons.NationalId))
                throw new Exception(string.Format("The nationalId of persons ({0}) has been registered before", nameof(persons)));

            int id = NextId;

            User newUser = new User(persons, id, Balance);

            Users[++userIndex] = newUser;

            return newUser;
        }

        public User GetUserById(int Id)
        {
            if (Id - UserIdStart >= Users.Length || Id < UserIdStart)
                throw new IndexOutOfRangeException(nameof(Id) + "is out of range");

            return Users[Id - UserIdStart];
        }

        public (int id, int gamesErrors) Register(Person persons, long Balance, params string[] Games)
        {
            try
            {
                (int id, int gamesErrors) result;

                User newUser = AddUser(persons, Balance);

                result.gamesErrors = AddGamesForUser(newUser, Games);
                result.id = newUser.Id;

                return result;
            }
            catch { throw; }
        }

        public User[] GetUsers()
        {
            return Users;
        }
    }
}
