using EVOChampions.Error;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EVOChampions.Manager.AccountManagement
{
    internal class User : Person
    {
        char gamesSeparator;
        MessageGenerator messageGenerator;
        public User(Person person, int Id, long Balance = 0, params string[] RegisteredGames) : base(person)
        {
            messageGenerator = new MessageGenerator();
            if (person == null)
                throw new ArgumentNullException(messageGenerator.GetArgumentNullMessage("person", nameof(person)));

            this.Id = Id;
            this.Balance = Balance;
            gamesSeparator = '$';
        }

        public int Id { get; private set; }

        string? Games { get; set; }

        public long Balance { private set; get; }

        public void AddGames(params string[] games)
        {
            string sprator = "";

            if(Games != null)
                sprator = "$";

            foreach (string gameName in games)
            {
                Games += String.Format("{0}{1}", sprator, gameName);
                sprator = "$";
            }
        }

        public string[] GetGames()
        {
            if(Games == null)
                return new string[0];

            string[] result = Games.Split(gamesSeparator);
            return result;
        }

        public long AddBalance(long additionalBalance)
        {
            Balance += additionalBalance;
            return Balance;
        }

        public long ReduceBalance(long ReduceingBalance)
        {
            if(ReduceingBalance > Balance)
                throw new InvalidOperationException(nameof(ReduceingBalance) + "is more than this User’s Balance");

            Balance -= ReduceingBalance;
            return Balance;
        }
    }
}
