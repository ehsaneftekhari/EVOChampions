namespace EVOChampions.Managers
{
    public abstract class ParentChildrenKeeper
    {
        public ParentChildrenKeeper(ParentChildrenKeeper? account)
        {
            if (account != null)
            {
                Parent = account;
                account.AddChild(this);
            }
        }

        public ParentChildrenKeeper[]? Children { get; private set; }

        public ParentChildrenKeeper? Parent { get; private set; }

        protected static ParentChildrenKeeper CheckNull(ParentChildrenKeeper account)
        {
            if (account is null)
                throw new ArgumentNullException(nameof(account));

            return account;
        }

        protected void AddChild(ParentChildrenKeeper account)
        {
            if (Children == null)
            {
                Children = new ParentChildrenKeeper[1];
                Children[0] = account;
            }
            else
            {
                Children = ExtendArray(Children);
                Children[Children.Length - 1] = account;
            }
        }

        private ParentChildrenKeeper[] ExtendArray(ParentChildrenKeeper[] array)
        {
            ParentChildrenKeeper[] NeArray = new ParentChildrenKeeper[array.Length + 1];
            for (int i = 0; i < array.Length; i++)
            {
                NeArray[i] = array[i];
            }
            return NeArray;
        }

    }
}
