using EVOChampions.Manager.AccountManagement;

class Program
{
    static void Main()
    {
        GameList gameList = new GameList(new string[] { "MortalCombat", "Taken", "StreetFighter" }, new long[] { 100, 200, 300 });
        RegisterManager registerManager = new RegisterManager(9, gameList);

        Person Ehsan = new Person(1, "Ehsan", "Eftekhari", 1000);
        Person Mohamad = new Person(2, "Mohamad", "Eftekhari", 1000);
        Person Javad = new Person(21665990, "Javad", "Eftekhari", 1000);
        Person Reza = new Person(3, "Reza", "Eftekhari", 1000);
        Person Ariyan = new Person(4, "Ariyan", "Eftekhari", 1000);
        Person Mohsen = new Person(5, "Mohsen", "Eftekhari", 1000);
        Person Hasan = new Person(6, "Hasan", "Eftekhari", 1000);
        Person Hadi = new Person(8, "Hasan", "Eftekhari", 1000);
        Person Ali = new Person(9, "Hasan", "Eftekhari", 1000);

        registerManager.Register(Ehsan, 500, gameList.GetSubList(1, 2));
        registerManager.Register(Mohamad, 500, gameList.GetSubList(1));
        registerManager.Register(Javad, 500, gameList.GetSubList(1, 2));
        (int id, int gamesErrors) test1 = registerManager.Register(Reza, 700, "MortalCombat", "Taken", "StreetFighter", "tset");
        (int id, int gamesErrors) test = registerManager.Register(Ariyan, 600, "MortalCombat", "Taken", "StreetFighter");
        registerManager.Register(Mohsen, 500, gameList.GetSubList(1, 2));
        registerManager.Register(Hasan, 500, gameList.GetSubList(1, 2));
        registerManager.Register(Hadi, 500, gameList.GetSubList(1, 2));
        registerManager.Register(Ali, 500, gameList.GetSubList(1, 2));

        string[] g = registerManager.GetUserById(3).GetGames();
        Console.WriteLine(g);
    }
}