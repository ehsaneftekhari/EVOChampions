using EVOChampions.Brackets;
using EVOChampions.Games.GameApps.MortalCombat;
using EVOChampions.Games.GameApps.StreetFighter;
using EVOChampions.Games;
using EVOChampions.Games.GameApps.Taken;
using EVOChampions.Managers;

class Program
{
    static void Main()
    {
        //TestBracket();
        //TestGame();
        Run();
    }

    public static void Run()
    {
        Game takenGame = new("Taken", 20, 21, new TakenCreator());
        Game mortalCombatGame = new("Mortal Combat", 30, 21, new MortalCombatCreator());
        Game streetFighter = new("Street Fighter", 20, 21, new StreetFighterCreator());

        GeneralManager generalManager = new GeneralManager(takenGame, mortalCombatGame, streetFighter);

        RegisterManager registerManager = generalManager.RegisterManager;

        UserRegisterInfo[] array = GenerateURE();
        foreach (UserRegisterInfo userRegisterInfo in array)
        {
            try
            {
                User newUser = registerManager.RegisterUser(userRegisterInfo, out newUser);
                registerManager.RegisterGame(newUser, "Taken", 20);
                registerManager.RegisterGame(newUser, "Mortal Combat", 30);
                registerManager.RegisterGame(newUser, "Street Fighter", 20);
            }
            catch (Exception ex)
            {
                PrintError(ex.Message);
            }
        }

        generalManager.FinishRegisteration();

        generalManager.Start();

        Console.WriteLine(generalManager.ToString());
    }

    public static void PrintError(string rrrorMessage)
    {
        ConsoleColor lastColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(rrrorMessage);
        Console.ForegroundColor = lastColor;
    }

    public static UserRegisterInfo[] GenerateURE()
    {
        UserRegisterInfo[] array = new UserRegisterInfo[] {
            new UserRegisterInfo(1000000000, "Ehsan",   "Eftekhari", 1000, "Ehsan"),
            new UserRegisterInfo(1000000001, "Mohamad", "Eftekhari", 1000, "Mohamad"),
            new UserRegisterInfo(1000000002, "Javad", "Eftekhari", 1000, "Javad"),
            new UserRegisterInfo(1000000003, "Reza", "Eftekhari", 1000, "Reza"),
            new UserRegisterInfo(1000000004, "Ariyan", "Eftekhari", 1000, "Ariyan"),
            new UserRegisterInfo(1000000005, "Mohsen", "Eftekhari", 1000, "Mohsen"),
            new UserRegisterInfo(1000000006, "Player6_Name", "Player6_LastName", 1000, "Player6"),
            new UserRegisterInfo(1000000007, "Player7_Name", "Player7_LastName", 1000, "Player7"),
            new UserRegisterInfo(1000000008, "Player8_Name", "Player8_LastName", 1000, "Player8"),
            new UserRegisterInfo(1000000009, "Player9_Name", "Player9_LastName", 1000, "Player9"),
            new UserRegisterInfo(10000000010, "Player10_Name", "Player10_LastName", 1000, "Player10"),
            new UserRegisterInfo(10000000010, "PlayeE1_Name", "PlayerE1_LastName", 1000, "PlayerE1"),
            new UserRegisterInfo(10000000102, "PlayerE2_Name", "PlayerE2_LastName", 1000, "Mohsen"),
            new UserRegisterInfo(10000000011, "Player11_Name", "Player11_LastName", 1000, "Player11"),
            new UserRegisterInfo(10000000012, "Player12_Name", "Player12_LastName", 1000, "Player12"),
            new UserRegisterInfo(10000000013, "Player13_Name", "Player13_LastName", 1000, "Player13"),
            new UserRegisterInfo(10000000014, "Player14_Name", "Player14_LastName", 1000, "Player14"),
            new UserRegisterInfo(10000000016, "Player15_Name", "Player15_LastName", 1000, "Player15"),
            new UserRegisterInfo(10000000017, "Player16_Name", "Player16_LastName", 1000, "Player16"),
            new UserRegisterInfo(10000000018, "Player17_Name", "Player17_LastName", 1000, "Player17"),
            new UserRegisterInfo(10000000103, "PlayerE3_Name", "PlayerE3_LastName", 1000, "PlayerE3"),
        };
        return array;
    }

    private static User[] CreateUser(UserRegisterInfo[] array)
    {
        User[] users = new User[array.Length];
        for (int i = 0; i < users.Length; i++)
        {
            users[i] = new User(array[i], i);
        }
        return users;
    }

    private static GamePlayer[] CreateTP(UserRegisterInfo[] array)
    {
        GamePlayer[] gameUsers = new GamePlayer[array.Length];
        for (int i = 0; i < gameUsers.Length; i++)
        {
            User user = new User(array[i], i);
            gameUsers[i] = new GamePlayer(user);
        }
        return gameUsers;
    }

    public static void TestGame()
    {
        UserRegisterInfo[] array = GenerateURE();
        User[] users = CreateUser(array);
        TakenCreator takenCreator = new TakenCreator();
        Game TestTaken = new Game("TestTaken", 1000, 16, takenCreator);
        TestTaken.SetUsers(users);
        TestTaken.Start();
        int x = 0;
    }

    public static void TestBracket()
    {
        UserRegisterInfo[] array = GenerateURE();
        GamePlayer[] gameUsers = CreateTP(array);

        Bracket bracket = new Bracket(gameUsers);
        int x = 0;
    }
}