using EVOChampions;
using EVOChampions.Brackets;
using EVOChampions.Games;
using EVOChampions.Games.Taken;
using EVOChampions.Managers.AccountManagements;

class Program
{
    static void Main()
    {
        //TestBracket();
        //TestTournament();

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
        Tournament TestTaken = new Tournament("TestTaken", users, takenCreator);
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