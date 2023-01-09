using EVOChampions.Manager.AccountManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVOChampions.Game
{
    public class Player : User
    {
        public int health { get; private set; }
        public Player(User user) : base(user)
        {
            health = 100;
        }
    }
}
