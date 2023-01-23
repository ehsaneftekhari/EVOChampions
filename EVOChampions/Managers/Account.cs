﻿namespace EVOChampions.Managers
{
    public abstract class Account
    {
        public Account(Account? account)
        {
            if (account != null)
            {
                Parent = account;
                account.AddChild(this);
            }
        }

        public Account[]? Children { get; private set; }

        public Account? Parent { get; private set; }

        protected static Account CheckNull(Account account)
        {
            if (account is null)
                throw new ArgumentNullException(nameof(account));

            return account;
        }

        protected void AddChild(Account account)
        {
            if (Children == null)
            {
                Children = new Account[1];
                Children[0] = account;
            }
            else
            {
                Children = ExtendArray(Children);
                Children[Children.Length - 1] = account;
            }
        }

        private Account[] ExtendArray(Account[] array)
        {
            Account[] NeArray = new Account[array.Length + 1];
            for (int i = 0; i < array.Length; i++)
            {
                NeArray[i] = array[i];
            }
            return NeArray;
        }

    }
}