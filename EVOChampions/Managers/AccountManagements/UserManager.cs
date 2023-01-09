namespace EVOChampions.Managers.AccountManagements
{
    internal class UserManager
    {
        protected User[] Users;

        public UserManager(RegisterManager registerManager)
        {
            Users = registerManager.GetUsers();
        }
    }
}
