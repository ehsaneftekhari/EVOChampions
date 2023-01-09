using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVOChampions.Manager.AccountManagement
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
