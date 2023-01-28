﻿using EVOChampions;
using EVOChampions.Brackets;
using EVOChampions.GameApps.MortalCombat;
using EVOChampions.GameApps.StreetFighter;
using EVOChampions.GameApps.Taken;
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
            new UserRegisterInfo(1000000006, "Playe6_Name", "Playe6_LastName", 1000, "Playe6"),
            new UserRegisterInfo(1000000007, "Playe7_Name", "Playe7_LastName", 1000, "Playe7"),
            new UserRegisterInfo(1000000008, "Playe8_Name", "Playe8_LastName", 1000, "Playe8"),
            new UserRegisterInfo(1000000009, "Playe9_Name", "Playe9_LastName", 1000, "Playe9"),
            new UserRegisterInfo(10000000010, "Playe10_Name", "Playe10_LastName", 1000, "Playe10"),
            new UserRegisterInfo(10000000010, "PlayeE1_Name", "PlayeE1_LastName", 1000, "PlayeE1"),
            new UserRegisterInfo(10000000102, "PlayeE2_Name", "PlayeE2_LastName", 1000, "Mohsen"),
            new UserRegisterInfo(10000000011, "Playe11_Name", "Playe11_LastName", 1000, "Playe11"),
            new UserRegisterInfo(10000000012, "Playe12_Name", "Playe12_LastName", 1000, "Playe12"),
            new UserRegisterInfo(10000000013, "Playe13_Name", "Playe13_LastName", 1000, "Playe13"),
            new UserRegisterInfo(10000000014, "Playe14_Name", "Playe14_LastName", 1000, "Playe14"),
            new UserRegisterInfo(10000000016, "Playe15_Name", "Playe15_LastName", 1000, "Playe15"),
            new UserRegisterInfo(10000000017, "Playe16_Name", "Playe16_LastName", 1000, "Playe16"),
            new UserRegisterInfo(10000000018, "Playe17_Name", "Playe17_LastName", 1000, "Playe17"),
            new UserRegisterInfo(10000000103, "PlayeE3_Name", "PlayeE3_LastName", 1000, "PlayeE3"),
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