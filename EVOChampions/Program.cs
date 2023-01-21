using EVOChampions;
using EVOChampions.Brackets;
using EVOChampions.Games;
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

        UserRegisterInfo[] array = GenerateURE();

        RegisterManager registerManager = generalManager.RegisterManager;

        var user1 = registerManager.Register(array[0]);
        generalManager.RegisterManager.AddGamesForUser(user1, 10, "Taken");

        var user2 = registerManager.Register(array[1]);
        generalManager.RegisterManager.AddGamesForUser(user2, 20, "Taken");

        var user3 = registerManager.Register(array[2]);
        generalManager.RegisterManager.AddGamesForUser(user3, 20, "Taken");

        var user4 = registerManager.Register(array[3]);
        generalManager.RegisterManager.AddGamesForUser(user4, 20, "Taken");

        var user5 = registerManager.Register(array[4]);
        generalManager.RegisterManager.AddGamesForUser(user5, 20, "Taken");

        var user6 = registerManager.Register(array[5]);
        generalManager.RegisterManager.AddGamesForUser(user6, 20, "Taken");

        var user7 = registerManager.Register(array[6]);
        generalManager.RegisterManager.AddGamesForUser(user7, 20, "Taken");

        var user8 = registerManager.Register(array[7]);
        generalManager.RegisterManager.AddGamesForUser(user8, 20, "Taken");

        var user9 = registerManager.Register(array[8]);
        generalManager.RegisterManager.AddGamesForUser(user9, 20, "Taken");

        generalManager.FinishRegisteration();
        generalManager.Start();

        Console.WriteLine(generalManager.Tournaments[0].Podium1.UserName);
        Console.WriteLine(generalManager.Tournaments[0].Podium2.UserName);
        Console.WriteLine(generalManager.Tournaments[0].Podium3.UserName);
    }

    public static UserRegisterInfo[] GenerateURE()
    {
        UserRegisterInfo[] array = new UserRegisterInfo[9];
        array[0] = new UserRegisterInfo(1, "Ehsan", "Eftekhari", 1000, "Ehsan");
        array[1] = new UserRegisterInfo(2, "Mohamad", "Eftekhari", 1000, "Mohamad");
        array[2] = new UserRegisterInfo(21665990, "Javad", "Eftekhari", 1000, "Javad");
        array[3] = new UserRegisterInfo(3, "Reza", "Eftekhari", 1000, "Reza");
        array[4] = new UserRegisterInfo(4, "Ariyan", "Eftekhari", 1000, "Ariyan");
        array[5] = new UserRegisterInfo(5, "Mohsen", "Eftekhari", 1000, "Mohsen");
        array[6] = new UserRegisterInfo(6, "Hasan", "Eftekhari", 1000, "Hasan");
        array[7] = new UserRegisterInfo(8, "Hasan", "Eftekhari", 1000, "Hasan2");
        array[8] = new UserRegisterInfo(9, "Hasan", "Eftekhari", 1000, "Hasan3");

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