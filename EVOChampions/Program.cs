using EVOChampions;
using EVOChampions.Brackets;
using EVOChampions.Games.MortalCombat;
using EVOChampions.Games.StreetFighter;
using EVOChampions.Games.Taken;
using EVOChampions.Managers;

class Program
{
    static void Main()
    {
        //TestBracket();
        //TestTournament();
        Run();
    }

    public static void Run()
    {
        Tournament takenTournament = new("Taken", 20, new TakenCreator());
        Tournament mortalCombatTournament = new("Mortal Combat", 30, new MortalCombatCreator());
        Tournament streetFighter = new("Street Fighter", 20, new StreetFighterCreator());

        GeneralManager generalManager = new GeneralManager(16, takenTournament, mortalCombatTournament, streetFighter);

        RegisterManager registerManager = generalManager.RegisterManager;

        UserRegisterInfo[] array = GenerateURE();
        foreach (UserRegisterInfo userRegisterInfo in array)
        {
            try
            {
                User newUser = registerManager.RegisterUser(userRegisterInfo, out newUser);
                registerManager.RegisterTournament(newUser, "Taken", 20);
                registerManager.RegisterTournament(newUser, "Mortal Combat", 30);
                registerManager.RegisterTournament(newUser, "Street Fighter", 20);
            }
            catch(Exception ex)
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
        UserRegisterInfo[] array = new UserRegisterInfo[16];
        array[0] = new UserRegisterInfo(1000000000, "Ehsan", "Eftekhari", 1000, "Ehsan");
        array[1] = new UserRegisterInfo(1000000001, "Mohamad", "Eftekhari", 1000, "Mohamad");
        array[2] = new UserRegisterInfo(1000000002, "Javad", "Eftekhari", 1000, "Javad");
        array[3] = new UserRegisterInfo(1000000003, "Reza", "Eftekhari", 1000, "Reza");
        array[4] = new UserRegisterInfo(1000000004, "Ariyan", "Eftekhari", 1000, "Ariyan");
        array[5] = new UserRegisterInfo(1000000005, "Mohsen", "Eftekhari", 1000, "Mohsen");
        array[6] = new UserRegisterInfo(1000000006, "Hasan", "Eftekhari", 1000, "Hasan");
        array[7] = new UserRegisterInfo(1000000007, "Hasan", "Shahbazi", 1000, "Shahbazi");
        array[8] = new UserRegisterInfo(1000000008, "Hesam", "Eftekhari", 1000, "Hasan2");
        array[9] = new UserRegisterInfo(1000000009, "Hesam", "Eftekhari", 1000, "Hasan3");
        array[10] = new UserRegisterInfo(10000000010, "Hesam", "Eftekhari", 1000, "Hasan4");
        array[11] = new UserRegisterInfo(10000000011, "Hesam", "Eftekhari", 1000, "Hasan5");
        array[12] = new UserRegisterInfo(10000000012, "Hesam", "Eftekhari", 1000, "Hasan6");
        array[13] = new UserRegisterInfo(10000000013, "Hesam", "Eftekhari", 1000, "Hasan7");
        array[14] = new UserRegisterInfo(10000000014, "Hesam", "Eftekhari", 1000, "Hasan8");
        array[15] = new UserRegisterInfo(10000000015, "Hesam", "Eftekhari", 1000, "Hasan9");
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

    private static TournamentPlayer[] CreateTP(UserRegisterInfo[] array)
    {
        TournamentPlayer[] tournamentUsers = new TournamentPlayer[array.Length];
        for (int i = 0; i < tournamentUsers.Length; i++)
        {
            User user = new User(array[i], i);
            tournamentUsers[i] = new TournamentPlayer(user);
        }
        return tournamentUsers;
    }

    public static void TestTournament()
    {
        UserRegisterInfo[] array = GenerateURE();
        User[] users = CreateUser(array);
        TakenCreator takenCreator = new TakenCreator();
        Tournament TestTaken = new Tournament("TestTaken", 1000, takenCreator);
        TestTaken.SetUsers(users);
        TestTaken.Start();
        int x = 0;
    }

    public static void TestBracket()
    {
        UserRegisterInfo[] array = GenerateURE();
        TournamentPlayer[] tournamentUsers = CreateTP(array);

        Bracket bracket = new Bracket(tournamentUsers);
        int x = 0;
    }
}